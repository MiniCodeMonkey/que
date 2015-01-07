#ifndef AlbumCoverCacheManager_h
#define AlbumCoverCacheManager_h

#include <map>
#include <iostream>
#include <SFML/System.hpp>
#include <SFML/Graphics.hpp>
#include <SFML/Network.hpp>
#include "Track.h"
#include "Parser.h"
#include "CacheItem.h"
#include "AlbumCoverDownloadThread.h"

class AlbumCoverCacheManager {
public:
	static AlbumCoverCacheManager *GetInstance();
	sf::Texture GetAlbumCoverImageAsync(Track *track);
	sf::Texture GetAlbumCoverImageSync(Track *track);
	sf::Texture DownloadImage(Track *track);
private:
	AlbumCoverCacheManager();
	static AlbumCoverCacheManager *pAlbumCoverCacheManager;
	sf::Texture defaultTexture;
	std::map<std::string, CacheItem*> images;
	AlbumCoverDownloadThread *downloadThread;
};

#endif