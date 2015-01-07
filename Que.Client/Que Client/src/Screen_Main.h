//
//  Screen_Main.h
//  Que Client
//
//  Created by Mathias Hansen on 23/08/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#ifndef Que_Client_Screen_Main_h
#define Que_Client_Screen_Main_h

#include <cstdio>
#include <SFML/Graphics.hpp>
#include "Parser.h"
#include "Screen.h"

class Screen_Main : public Screen
{
public:
    Screen_Main() {}
    virtual ~Screen_Main() {}
	virtual int Run(sf::RenderWindow &App);
protected:
private:
    bool TrackQueuesEqual(std::vector<Track*>queue1, std::vector<Track*>queue2);
};

#endif
