//
//  Playlists.h
//  Que Client
//
//  Created by Mathias Hansen on 25/08/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#ifndef Que_Client_Playlists_h
#define Que_Client_Playlists_h

#include "Playlist.h"

class Playlists
{
private:
    std::vector<Playlist*> playlists;

public:
    std::vector<Playlist*>getPlaylists() { return playlists; }
    void setPlaylists(std::vector<Playlist*> playlists) { this->playlists = playlists; }
};

#endif
