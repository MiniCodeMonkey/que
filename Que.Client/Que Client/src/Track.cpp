//
//  Track.cpp
//  Que Client
//
//  Created by Mathias Hansen on 23/08/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#include <iostream>
#include "Track.h"
#include "Parser.h"
#include "Cache.h"
#include "AlbumCoverCacheManager.h"

sf::Texture Track::getAlbumCoverImage()
{
	return AlbumCoverCacheManager::GetInstance()->GetAlbumCoverImageSync(this);
}