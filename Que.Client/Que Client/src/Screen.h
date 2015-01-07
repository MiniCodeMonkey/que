//
//  Screen.h
//  Que Client
//
//  Created by Mathias Hansen on 23/08/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#ifndef Que_Client_Screen_h
#define Que_Client_Screen_h

#include <SFML/Graphics.hpp>

typedef enum
{
    EASE_IN = 2,
    LINEAR = 1,
    EASE_OUT = 0
} EaseMode;

class Screen
{
public:
    virtual int Run(sf::RenderWindow &App) = 0;
protected:
    int SmoothStep(float minValue, float maxValue, float totalSteps, float currentStep, EaseMode easeMode);
};

#endif
