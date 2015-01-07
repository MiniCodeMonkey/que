//
//  Screen.cpp
//  Que Client
//
//  Created by Mathias Hansen on 23/08/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#include <iostream>
#include "Screen.h"

/* Ported from javascript method http://www.hesido.com/web.php?page=javascriptanimation */
int Screen::SmoothStep(float minValue, float maxValue, float totalSteps, float currentStep, EaseMode easeMode)  
{  
	// Ease In/Out
    int delta = maxValue - minValue; 
    float stepp = minValue + (pow(((1.0 / totalSteps) * currentStep), easeMode) * delta);
    return ceil(stepp);

	// Linear
	/*double percent = currentStep / totalSteps;
	int val = maxValue - minValue;
	int res = (percent * val) + minValue;
	return res;*/
}