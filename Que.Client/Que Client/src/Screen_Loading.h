//
//  Screen_Loading.h
//  Que Client
//
//  Created by Mathias Hansen on 28/08/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#ifndef Que_Client_Screen_Loading_h
#define Que_Client_Screen_Loading_h

#include <cstdio>
#include <SFML/Graphics.hpp>
#include "Screen.h"
#include "Screen_Browse.h"

class Screen_Loading : public Screen
{
public:
    Screen_Loading() {}
    virtual ~Screen_Loading() {}
	virtual int Run(sf::RenderWindow &App);
    void SetScreenBrowse(Screen_Browse *screenBrowse) { this->screenBrowse = screenBrowse; }
protected:
private:
    Screen_Browse *screenBrowse;
};

#endif
