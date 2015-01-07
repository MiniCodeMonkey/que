//
//  Request.h
//  Que Client
//
//  Created by Mathias Hansen on 23/08/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#ifndef Que_Client_Request_h
#define Que_Client_Request_h

#include <vector>
#include <SFML/Network.hpp>
#include "ticpp.h"
#include "NowPlaying.h"
#include "Playlists.h"
#include "Defines.h"

class Parser
{
public:
    static void SetServer(std::string hostname, int port);
    static NowPlaying *GetNowPlaying();
    static std::vector<Track*> GetQueue();
    static Playlists *GetPlaylists();
    static std::vector<Track*> Search(std::string query);
	static std::string Enqueue(Track *track);
    static std::string Request(std::string url);
    static sf::Http::Response RequestBody(std::string url);
	
	static std::string urlencode(const std::string &c);
	static std::string char2hex(char dec);
private:
    static std::string ServerHostname;
    static int ServerPort;
};

#endif
