#include "AlbumCoverDownloadThread.h"
#include "AlbumCoverCacheManager.h"

void AlbumCoverDownloadThread::Run()
{
#ifdef DEBUG_CACHE
	std::cout << "Download thread started" << std::endl;
#endif

	while (true)
	{
		if (downloadQueue.size() > 0)
		{
			// Pick first track
			Track *track = downloadQueue[0];
			downloadQueue.erase(downloadQueue.begin()); // Remove it from the queue

			AlbumCoverCacheManager::GetInstance()->DownloadImage(track);
		}
		else
		{
			sf::sleep(sf::seconds(1.0f)); // Sleep
		}
	}
}

void AlbumCoverDownloadThread::AddToDownloadQueue(Track *track)
{
	// Is track already in queue?
	if (std::find(downloadQueue.begin(), downloadQueue.end(), track) != downloadQueue.end())
	{
#ifdef DEBUG_CACHE
		std::cout << "Putting " << track->getAlbum() << " in download queue" << std::endl;
#endif
		downloadQueue.push_back(track);
	}
}
