//
//  Track.h
//  Que Client
//
//  Created by Mathias Hansen on 23/08/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#ifndef Que_Client_Track_h
#define Que_Client_Track_h

#include <SFML/System.hpp>
#include <SFML/Graphics.hpp>
#include <iterator>

class Track
{
private:
    std::string title;
    std::string artists;
    std::string album;
    int popularity;
    std::string link;
    std::string albumCoverId;
    int duration;
    
public:
	Track() { this->albumCoverId = ""; }

    std::string getTitle() { return title; }
    void setTitle(std::string title)
	{
        std::string encodedStr;
        encodedStr.reserve(title.length() + 1);
        sf::Utf8::toLatin1(title.begin(), title.end(), std::back_inserter(encodedStr));
        this->title = encodedStr;
    }
    
    std::string getArtists() { return artists; }
    void setArtists(std::string artists)
	{
	    std::string encodedStr;
        encodedStr.reserve(artists.length() + 1);
        sf::Utf8::toLatin1(artists.begin(), artists.end(), std::back_inserter(encodedStr));
        this->artists = encodedStr;
	}
    
    std::string getAlbum() { return album; }
    void setAlbum(std::string album)
	{
	    std::string encodedStr;
        encodedStr.reserve(album.length() + 1);
        sf::Utf8::toLatin1(album.begin(), album.end(), std::back_inserter(encodedStr));
        this->album = encodedStr;
	}
    
    int getPopularity() { return popularity; }
    void setPopularity(int popularity) { this->popularity = popularity; }
    
    std::string getLink() { return link; }
    void setLink(std::string link) { this->link = link; }
    
    std::string getAlbumCoverId() { return albumCoverId; }
    void setAlbumCoverId(std::string albumCoverId) { this->albumCoverId = albumCoverId; };
    
    int getDuration() { return duration; }
    void setDuration(int duration) { this->duration = duration; };
    
    sf::Texture getAlbumCoverImage();
};

#endif
