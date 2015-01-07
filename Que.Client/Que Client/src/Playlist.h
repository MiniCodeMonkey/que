//
//  Playlist.h
//  Que Client
//
//  Created by Mathias Hansen on 25/08/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#ifndef Que_Client_Playlist_h
#define Que_Client_Playlist_h

#include "Track.h"

class Playlist
{
private:
    std::string name;
    std::string link;
    std::vector<Track*> tracks;
    
public:
    std::string getName() { return name; }
    void setName(std::string name) { this->name = name; }
    std::string getLink() { return link; }
    void setLink(std::string link) { this->link = link; }
    std::vector<Track*>getTracks() { return tracks; }
    void setTracks(std::vector<Track*> tracks) { this->tracks = tracks; }
};

#endif
