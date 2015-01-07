//
//  Request.cpp
//  Que Client
//
//  Created by Mathias Hansen on 23/08/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#include <iostream>
#include "Parser.h"
#include "QueException.h"

std::string Parser::urlencode(const std::string &c)
{
    
    std::string escaped="";
    int max = c.length();
    for(int i=0; i<max; i++)
    {
        if ( (48 <= c[i] && c[i] <= 57) ||//0-9
             (65 <= c[i] && c[i] <= 90) ||//abc...xyz
             (97 <= c[i] && c[i] <= 122) || //ABC...xYZ
             (c[i]=='~' || c[i]=='!' || c[i]=='*' || c[i]=='(' || c[i]==')' || c[i]=='\'')
        )
        {
            escaped.append( &c[i], 1);
        }
        else
        {
            escaped.append("%");
            escaped.append( Parser::char2hex(c[i]) );//converts char 255 to string "ff"
        }
    }
    return escaped;
}

std::string Parser::char2hex( char dec )
{
    char dig1 = (dec&0xF0)>>4;
    char dig2 = (dec&0x0F);
    if ( 0<= dig1 && dig1<= 9) dig1+=48;    //0,48inascii
    if (10<= dig1 && dig1<=15) dig1+=97-10; //a,97inascii
    if ( 0<= dig2 && dig2<= 9) dig2+=48;
    if (10<= dig2 && dig2<=15) dig2+=97-10;

    std::string r;
    r.append( &dig1, 1);
    r.append( &dig2, 1);
    return r;
}

std::string Parser::ServerHostname = "";
int Parser::ServerPort = 7879;

void Parser::SetServer(std::string hostname, int port)
{
    Parser::ServerHostname = hostname;
    Parser::ServerPort = port;
}

NowPlaying *Parser::GetNowPlaying()
{
    NowPlaying *nowPlaying = new NowPlaying();
    
    // first load the xml file
    ticpp::Document doc;
    
    try
    {
        doc.Parse(Parser::Request("/NowPlaying"));
    }
    catch (ticpp::Exception)
    {
        throw QueException("Parser error");
    }
        
    ticpp::Element *statusElement = doc.FirstChildElement()->FirstChildElement();
    if (statusElement->GetAttribute("Playing") == "true")
    {
        nowPlaying->setPlaying(true);
    }
    else
    {
        nowPlaying->setPlaying(false);
    }
    
    nowPlaying->setElapsed(atoi(statusElement->GetAttribute("Elapsed").c_str()));
    
    if (nowPlaying->getPlaying())
    {
        ticpp::Element *trackElement = statusElement->FirstChildElement();
        
        Track *track = new Track();
        
        // Loop through track info
        ticpp::Iterator<ticpp::Element> child;
        for(child = child.begin(trackElement); child != child.end(); child++)
        {
            std::string childName;
            child->GetValue(&childName);
            
            std::string childValue = "";
			try
			{
				childValue = child->GetText();
			}
			catch (const ticpp::Exception&)
			{
				childValue = "";
			}

            if (childName == "Title")
            {
                track->setTitle(childValue);
            }
            else if (childName == "Artists")
            {
                track->setArtists(childValue);
            }
            else if (childName == "Album")
            {
                track->setAlbum(childValue);
            }
            else if (childName == "Popularity")
            {
                track->setPopularity(atoi(childValue.c_str()));
            }
            else if (childName == "Link")
            {
                track->setLink(childValue);
            }
            else if (childName == "AlbumCoverId")
            {
                track->setAlbumCoverId(childValue);
            }
            else if (childName == "Duration")
            {
                track->setDuration(atoi(childValue.c_str()));
            }
        }
        
        nowPlaying->setTrack(track);
    }
    
    return nowPlaying;
}

std::vector<Track*> Parser::GetQueue()
{
    std::vector<Track*> tracks;
    
    // first load the xml file
    ticpp::Document doc;
    try
    {
        doc.Parse(Parser::Request("/Queue"));
    }
    catch (ticpp::Exception)
    {
        throw QueException("Parser error");
    }
    
    ticpp::Iterator<ticpp::Element> trackElement;
    for (trackElement = trackElement.begin(doc.FirstChildElement()->FirstChildElement()); trackElement != trackElement.end(); trackElement++)
    {
        Track *track = new Track();
        
        ticpp::Node *child = 0;
        while ((child = trackElement->IterateChildren(child)))
        {
            std::string childName;
            child->GetValue(&childName);
            
            std::string childValue = "";
			try
			{
				childValue = child->ToElement()->GetText();
			}
			catch (const ticpp::Exception&)
			{
				childValue = "";
			}
            
            if (childName == "Title")
            {
                track->setTitle(childValue);
            }
            else if (childName == "Artists")
            {
                track->setArtists(childValue);
            }
            else if (childName == "Album")
            {
                track->setAlbum(childValue);
            }
            else if (childName == "Popularity")
            {
                track->setPopularity(atoi(childValue.c_str()));
            }
            else if (childName == "Link")
            {
                track->setLink(childValue);
            }
            else if (childName == "AlbumCoverId")
            {
                track->setAlbumCoverId(childValue);
            }
            else if (childName == "Duration")
            {
                track->setDuration(atoi(childValue.c_str()));
            }
        }
        
        tracks.push_back(track);
    }
    
    return tracks;
}

Playlists *Parser::GetPlaylists()
{
    std::vector<Playlist*> playlistObjs;
    
    // first load the xml file
    ticpp::Document doc;
    try
    {
        doc.Parse(Parser::Request("/Playlists"));
    }
    catch (ticpp::Exception)
    {
        throw QueException("Parser error");
    }
    
    ticpp::Iterator<ticpp::Element> playlistElement;
    for (playlistElement = playlistElement.begin(doc.FirstChildElement()->FirstChildElement()); playlistElement != playlistElement.end(); playlistElement++)
    {
        Playlist *playlist = new Playlist();
        
        ticpp::Node *playlistChild = 0;
        while ((playlistChild = playlistElement->IterateChildren(playlistChild)))
        {
            std::string playlistChildName;
            playlistChild->GetValue(&playlistChildName);

			std::string childValue = "";
			try
			{
				childValue = playlistChild->ToElement()->GetText();
			}
			catch (const ticpp::Exception&)
			{
				childValue = "";
			}

            if (playlistChildName == "Name")
            {
                playlist->setName(childValue);
            }
            else if (playlistChildName == "Link")
            {
				playlist->setLink(childValue);
            }
            else if (playlistChildName == "Tracks")
            {
                std::vector<Track*> tracks;
                
                ticpp::Node *trackElement = 0;
                while ((trackElement = playlistChild->IterateChildren(trackElement)))
                {
                    Track *track = new Track();
                    
                    ticpp::Node *child = 0;
                    while ((child = trackElement->IterateChildren(child)))
                    {
                        std::string childName;
                        child->GetValue(&childName);
                        
                       childValue = "";
						try
						{
							childValue = child->ToElement()->GetText();
						}
						catch (const ticpp::Exception&)
						{
							childValue = "";
						}
                        
                        if (childName == "Title")
                        {
                            track->setTitle(childValue);
                        }
                        else if (childName == "Artists")
                        {
                            track->setArtists(childValue);
                        }
                        else if (childName == "Album")
                        {
                            track->setAlbum(childValue);
                        }
                        else if (childName == "Popularity")
                        {
                            track->setPopularity(atoi(childValue.c_str()));
                        }
                        else if (childName == "Link")
                        {
                            track->setLink(childValue);
                        }
                        else if (childName == "AlbumCoverId")
                        {
                            track->setAlbumCoverId(childValue);
                        }
                        else if (childName == "Duration")
                        {
                            track->setDuration(atoi(childValue.c_str()));
                        }
                    }
                    
                    tracks.push_back(track);
                }
                
                playlist->setTracks(tracks);
            }
        }
        
		// Skip playlists without tracks
		if (playlist->getTracks().size() > 0)
		{
			playlistObjs.push_back(playlist);
		}
    }
    
    Playlists *playlists = new Playlists();
    playlists->setPlaylists(playlistObjs);
    
    return playlists;
}

std::vector<Track*> Parser::Search(std::string query)
{
    std::vector<Track*> tracks;
    
    // first load the xml file
    ticpp::Document doc;
    try
    {
        std::string path = "/Search/";
		path += Parser::urlencode(query);
        
        doc.Parse(Parser::Request(path));
    }
    catch (ticpp::Exception)
    {
        throw QueException("Parser error");
    }
    
    ticpp::Iterator<ticpp::Element> trackElement;
    for (trackElement = trackElement.begin(doc.FirstChildElement()->FirstChildElement()); trackElement != trackElement.end(); trackElement++)
    {
        Track *track = new Track();
        
        ticpp::Node *child = 0;
        while ((child = trackElement->IterateChildren(child)))
        {
            std::string childName;
            child->GetValue(&childName);
            
            std::string childValue = "";
			try
			{
				childValue = child->ToElement()->GetText();
			}
			catch (const ticpp::Exception&)
			{
				childValue = "";
			}
            
            if (childName == "Title")
            {
                track->setTitle(childValue);
            }
            else if (childName == "Artists")
            {
                track->setArtists(childValue);
            }
            else if (childName == "Album")
            {
                track->setAlbum(childValue);
            }
            else if (childName == "Popularity")
            {
                track->setPopularity(atoi(childValue.c_str()));
            }
            else if (childName == "Link")
            {
                track->setLink(childValue);
            }
            else if (childName == "AlbumCoverId")
            {
                track->setAlbumCoverId(childValue);
            }
            else if (childName == "Duration")
            {
                track->setDuration(atoi(childValue.c_str()));
            }
        }
        
        tracks.push_back(track);
    }
    
    return tracks;
}

std::string Parser::Enqueue(Track *track)
{
    // first load the xml file
    ticpp::Document doc;
    
    try
    {
		std::string path = "/Enqueue/";
		path += track->getLink();

		doc.Parse(Parser::Request(path));
    }
    catch (ticpp::Exception)
    {
        throw QueException("Parser error");
    }
        
    ticpp::Element *messageElement = doc.FirstChildElement()->FirstChildElement()->FirstChildElement();

	std::string message = "";
	try
	{
		message = messageElement->GetText();
	}
	catch (const ticpp::Exception&)
	{
		message = "";
	}

	return message;
}

std::string Parser::Request(std::string url)
{
	std::cout << "Requesting " << url << std::endl;

    sf::Http::Response Page = Parser::RequestBody(url);
    
	if (Page.getStatus() != sf::Http::Response::Status::Ok)
    {
        throw QueException("Connection error");
    }

    return Page.getBody();
}

sf::Http::Response Parser::RequestBody(std::string url)
{
    // Create a HTTP client
    sf::Http Http;
    
    // Connect to jukebox server
    Http.setHost(ServerHostname, ServerPort);
    
    // Prepare a request to retrieve the index page
    sf::Http::Request Request;
    Request.setMethod(sf::Http::Request::Get);
    Request.setUri(url);
    Request.setBody("");
    Request.setHttpVersion(1, 0);
    
    // Send it and get the response returned by the server
	sf::Http::Response Page = Http.sendRequest(Request, sf::milliseconds(5000));
    
    return Page;
}