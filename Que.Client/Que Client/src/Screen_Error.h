//
//  Screen_Error.h
//  Que Client
//
//  Created by Mathias Hansen on 28/08/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#ifndef Que_Client_Screen_Error_h
#define Que_Client_Screen_Error_h

#include <cstdio>
#include <SFML/Graphics.hpp>
#include "Screen.h"

class Screen_Error : public Screen
{
public:
    Screen_Error() {}
    virtual ~Screen_Error() {}
	virtual int Run(sf::RenderWindow &App);
protected:
private:
};

#endif
