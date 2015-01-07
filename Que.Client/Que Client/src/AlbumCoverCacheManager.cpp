#include <cstddef>
#include "AlbumCoverCacheManager.h"
#include "Cache.h"

AlbumCoverCacheManager *AlbumCoverCacheManager::pAlbumCoverCacheManager = NULL;

AlbumCoverCacheManager *AlbumCoverCacheManager::GetInstance()
{
	if (pAlbumCoverCacheManager == NULL) {
		pAlbumCoverCacheManager = new AlbumCoverCacheManager();
	}

	return pAlbumCoverCacheManager;
}

AlbumCoverCacheManager::AlbumCoverCacheManager()
{
	// Initialize download thread
	downloadThread = new AlbumCoverDownloadThread();
	sf::Thread Thread(&AlbumCoverDownloadThread::Run, downloadThread);
	//Thread.Launch();

	// Load default cover texture
	if (!defaultTexture.loadFromFile("default_cover.png"))
	{
		std::cout << "Could not load default cover" << std::endl;
	}
}

sf::Texture AlbumCoverCacheManager::GetAlbumCoverImageAsync(Track *track)
{
	// Try to load from memory
	std::map<std::string, CacheItem*>::iterator iter;
	iter = images.find(track->getAlbumCoverId());

	if (iter != images.end())
	{
#ifdef DEBUG_CACHE
		std::cout << "Returning " << track->getAlbum() << " from memory" << std::endl;
#endif
		CacheItem *cacheItem = iter->second;
		return cacheItem->GetImage();
	}
	else
	{
		// Try to load from file cache
		sf::Texture image = Cache::GetImage(track->getAlbumCoverId());
		if (image.getSize().x == 0 && image.getSize().y == 0)
		{
			downloadThread->AddToDownloadQueue(track);
			return defaultTexture;
		}
		else
		{
			CacheItem *cacheItem = new CacheItem();
			cacheItem->SetImage(image);
			images.insert(std::make_pair(track->getAlbumCoverId(), cacheItem));
#ifdef DEBUG_CACHE
			std::cout << "Returning " << track->getAlbum() << " from file" << std::endl;
			std::cout << "Cache size: %d" << images.size() << std::endl;
#endif
			return image;
		}
	}
}

sf::Texture AlbumCoverCacheManager::GetAlbumCoverImageSync(Track *track)
{
	// Return default texture if no valid album cover id was given
	if (track->getAlbumCoverId().size() <= 5)
	{
		return defaultTexture;
	}

	// Try to load from memory
	std::map<std::string, CacheItem*>::iterator iter;
	iter = images.find(track->getAlbumCoverId());

	if (iter != images.end())
	{
#ifdef DEBUG_CACHE
		std::cout << "Returning " << track->getAlbum() << " from memory" << std::endl;
#endif
		CacheItem *cacheItem = iter->second;
		return cacheItem->GetImage();
	}
	else
	{
		// Try to load from file cache
		sf::Texture image = Cache::GetImage(track->getAlbumCoverId());
		if (image.getSize().x == 0 && image.getSize().y == 0)
		{
			image = this->DownloadImage(track);
			return image;
		}
		else
		{
#ifdef DEBUG_CACHE
			std::cout << "Returning " << track->getAlbum() << " from file" << std::endl;
#endif
			return image;
		}
	}
}
sf::Texture AlbumCoverCacheManager::DownloadImage(Track *track)
{
#ifdef DEBUG_CACHE
	std::cout << "Downloading " << track->getAlbum() << " from webservice" << std::endl;
#endif

	sf::Texture image;
	std::string action = "/Image/";
	std::string url = action + track->getAlbumCoverId();
        
	// Send it and get the response returned by the server
	sf::Http::Response Page = Parser::RequestBody(url);        
        
	if (!image.loadFromMemory(Page.getBody().c_str(), Page.getBody().size()))
	{
		std::cout << "Could not load image for " << track->getAlbum();
	}
	else
	{
#ifdef DEBUG_CACHE
		std::cout << track->getAlbum() << " loaded from webservice" << std::endl;
#endif
	}
        
	Cache::SaveImage(Page.getBody(), track->getAlbumCoverId());

	return image;
}