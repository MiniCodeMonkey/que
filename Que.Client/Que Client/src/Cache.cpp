//
//  Cache.cpp
//  Que Client
//
//  Created by Mathias Hansen on 25/08/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#include "Cache.h"
#include <iostream>
#include <sys/stat.h>
#include <sys/types.h>

sf::Texture Cache::GetImage(std::string imageId)
{
    // Create cache dir if it doesn't exists
    if (!FileExists((char*)"cache"))
    {
#ifdef __APPLE__
        mkdir("cache", 0777);
#else
		system("mkdir cache");
#endif
    }
    
    // Try to load image
    sf::Texture cachedImage;
    if (!cachedImage.loadFromFile("cache/" + imageId + ".jpg"))
	{
		cachedImage.create(0, 0);
	}
    
#ifdef DEBUG_CACHE
    std::cout << "Tried to load " << imageId << " from cache" << std::endl;
#endif
    return cachedImage;
}

void Cache::SaveImage(std::string data, std::string imageId)
{
    // Create cache dir if it doesn't exists
    if (!FileExists((char*)"cache"))
    {
#ifdef __APPLE__
        mkdir("cache", 0777);
#else
		system("mkdir cache");
#endif
    }
    
    std::string imageLocation = "cache/" + imageId + ".jpg";
    
    // Save image
    if (!FileExists((char*)imageLocation.c_str()))
    {
#ifdef DEBUG_CACHE
        std::cout << imageId << " saving to cache" << std::endl;
#endif
        std::ofstream filestream;
		filestream.open(imageLocation.c_str(), std::ofstream::binary);
        filestream << data;
        filestream << std::flush;
        filestream.close();
        
#ifdef DEBUG_CACHE
        std::cout << imageId << " saved to cache" << std::endl;
#endif
    }
}

bool Cache::FileExists(char *filename)
{
    struct stat   buffer;   
    return (stat (filename, &buffer) == 0);
}