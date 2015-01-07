#ifndef ALBUM_COVER_DOWNLOAD_THREAD_H
#define ALBUM_COVER_DOWNLOAD_THREAD_H

#include <SFML/System.hpp>
#include <vector>
#include "Track.h"

class AlbumCoverDownloadThread
{
public:
	void AddToDownloadQueue(Track *track);
	void Run();
	
private:
	std::vector<Track*> downloadQueue;
};

#endif