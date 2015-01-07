//
//  Screen_Browse.h
//  Que Client
//
//  Created by Mathias Hansen on 23/08/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#ifndef Que_Client_Screen_Browse_h
#define Que_Client_Screen_Browse_h

#include <cstdio>
#include <SFML/Graphics.hpp>
#include "Screen.h"
#include "Playlists.h"

#define PLAYLIST_PER_SCREEN	3
#define PLAYLIST_MARGIN		100
#define PLAYLIST_WIDTH		(1920 / PLAYLIST_PER_SCREEN) - PLAYLIST_MARGIN
#define PLAYLISTS_Y			220

typedef enum
{
    BROWSE,
    ANIMATING_TO_SEARCH,
    TYPING_SEARCH,
    LOADING_SEARCH,
    SHOWING_SEARCH
} BrowseState;

class Screen_Browse : public Screen
{
public:
    Screen_Browse() {}
    virtual ~Screen_Browse() {}
	virtual int Run(sf::RenderWindow &App);
    void LoadPlaylists();
    bool IsLoaded() { return isLoaded; }
protected:
private:
    Playlists *playlists;
	std::vector< std::vector<sf::Texture> > playlistTextures;
	std::vector<int> playlistHeights;
    bool isLoaded;
    BrowseState currentBrowseState;
	bool putInQueueOverlay;
	Track *selectedTrack;
	int deltaPlaylistX;
	int getPlaylistX(int i)
	{
		int x = deltaPlaylistX + (i * (PLAYLIST_WIDTH + PLAYLIST_MARGIN)) + (PLAYLIST_MARGIN / 2);

		return x;
	}
};

#endif
