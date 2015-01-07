//
//  Cache.h
//  Que Client
//
//  Created by Mathias Hansen on 25/08/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#ifndef Que_Client_Cache_h
#define Que_Client_Cache_h

#include <SFML/Graphics.hpp>
#ifdef __APPLE___
#include <fstream.h>
#else
#include <fstream>
#endif
class Cache
{
public:
    static sf::Texture GetImage(std::string imageId);
    static void SaveImage(std::string data, std::string imageId);
    
private:
    static bool FileExists(char *filename);
};

#endif
