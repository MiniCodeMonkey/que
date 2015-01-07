//
//  Screen_Loading.cpp
//  Que Client
//
//  Created by Mathias Hansen on 28/08/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#include <iostream>
#include "Screen_Loading.h"
#include "Parser.h"

int Screen_Loading::Run(sf::RenderWindow &App)
{
    // Define colors
    sf::Color darkColor = sf::Color(30, 30, 30);
    sf::Color greenColor = sf::Color(104, 205, 84);
    sf::Color redColor = sf::Color(255, 87, 87);
    
    // Font
    sf::Font DeliciousFont;
    if (!DeliciousFont.loadFromFile(DEFAULT_FONT))
    {
        std::cout << "Missing font" << std::endl;
    }
    
    // Loading image
    sf::Texture LoadingImage;
    if (!LoadingImage.loadFromFile("loading_bottom.png"))
    {
        std::cout << "Missing loading_bottom.png" << std::endl;
    }
    LoadingImage.setSmooth(false);
    
    sf::Sprite LoadingImageSprite(LoadingImage);
    LoadingImageSprite.setPosition(App.getSize().x / 2 - LoadingImage.getSize().x / 2, App.getSize().y - LoadingImage.getSize().y);
    
    int fadeToBlackValue = 1;
    
    sf::Text LoadingText;
    LoadingText.setFont(DeliciousFont);
    LoadingText.setColor(greenColor);
    LoadingText.setString("Retreiving information from jukebox");
    LoadingText.setCharacterSize(80.0f);
    LoadingText.setPosition(App.getSize().x / 2 - LoadingText.getLocalBounds().width / 2, App.getSize().y / 2 - LoadingText.getLocalBounds().height / 2);
    
    sf::Clock RetryTimer;
    
	int loadingIndicatorFrame = 0;
    while (App.isOpen())
    {
        sf::Event Event;
        while (App.pollEvent(Event))
        {
			if (Event.type == sf::Event::Closed ||
				(
					Event.type == sf::Event::MouseButtonPressed &&
					Event.mouseButton.x > App.getSize().x - 40 &&
					Event.mouseButton.y > App.getSize().y - 40)
				)
            {
                return -1;
            }
            
			if (Event.type == sf::Event::KeyPressed)
			{
				switch (Event.key.code)
				{
					case sf::Keyboard::Escape:
					{
						return -1;
						break;
					}
                        
					default:
						break;
				}
			}
		}
        App.clear(darkColor);
        App.draw(LoadingImageSprite);
        App.draw(LoadingText);
        
        if (RetryTimer.getElapsedTime().asMilliseconds() > 500)
        {
            RetryTimer.restart();
            
            if (screenBrowse->IsLoaded())
            {
                return 1; // Go to main screen
            }

			switch (loadingIndicatorFrame)
			{
				case 0:
					LoadingText.setString("Retreiving information from jukebox");
					break;

				case 1:
					LoadingText.setString("Retreiving information from jukebox.");
					break;

				case 2:
					LoadingText.setString("Retreiving information from jukebox..");
					break;

				case 3:
					LoadingText.setString("Retreiving information from jukebox...");
					break;

				default:
					break;
			}

			
			loadingIndicatorFrame++;
			if (loadingIndicatorFrame > 3)
			{
				loadingIndicatorFrame = 0;
			}
        }
        
        if (fadeToBlackValue > 0)
        {
            sf::Color fadeColor = sf::Color(0, 0, 0, SmoothStep(255, 0, 20, fadeToBlackValue, EASE_IN));
            
            sf::RectangleShape blackOverlay;
            blackOverlay.setSize(sf::Vector2f(App.getSize().x, App.getSize().y));
            blackOverlay.setFillColor(fadeColor);
            blackOverlay.setPosition(0, 0);
            
            App.draw(blackOverlay);
            
            if (fadeToBlackValue >= 20)
            {
                fadeToBlackValue = 0;
            }
            else
            {
                fadeToBlackValue++;
            }
        }
        
		App.display();
	}
    
    return 0;
}