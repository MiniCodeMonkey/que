//
//  Screen_Error.cpp
//  Que Client
//
//  Created by Mathias Hansen on 28/08/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#include <iostream>
#include "Screen_Error.h"
#include "Parser.h"
#include "QueException.h"

int Screen_Error::Run(sf::RenderWindow &App)
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
    LoadingText.setString("Just a couple more minutes in the microwave...");
    LoadingText.setCharacterSize(80.0f);
    LoadingText.setPosition(App.getSize().x / 2 - LoadingText.getLocalBounds().width / 2, App.getSize().y / 2 - LoadingText.getLocalBounds().height / 2);
    
    sf::Clock Timer;
    sf::Clock RetryTimer;
    
    while (App.isOpen())
    {
        sf::Event Event;
        while (App.pollEvent(Event))
        {
			if (Event.type == sf::Event::Closed ||
				(
					Event.type == sf::Event::MouseButtonPressed &&
					Event.mouseButton.x > App.getSize().x - 40 &&
					Event.mouseButton.y > App.getSize().y - 40
                )
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
        
        if (Timer.getElapsedTime().asMilliseconds() > 25000)
        {
            LoadingText.setColor(redColor);
            LoadingText.setString("I give up :(");
            LoadingText.setPosition(App.getSize().x / 2 - LoadingText.getLocalBounds().width / 2, App.getSize().y / 2 - LoadingText.getLocalBounds().height / 2);
        }
        else if (Timer.getElapsedTime().asMilliseconds() > 17000)
        {
            LoadingText.setColor(redColor);
            LoadingText.setString("Oh noes! Something seems broken..");
            LoadingText.setPosition(App.getSize().x / 2 - LoadingText.getLocalBounds().width / 2, App.getSize().y / 2 - LoadingText.getLocalBounds().height / 2);
        }
        else if (Timer.getElapsedTime().asMilliseconds() > 12000)
        {
            LoadingText.setString("Hmm...");
            LoadingText.setPosition(App.getSize().x / 2 - LoadingText.getLocalBounds().width / 2, App.getSize().y / 2 - LoadingText.getLocalBounds().height / 2);
        }
        else if (Timer.getElapsedTime().asMilliseconds() > 8000)
        {
            LoadingText.setString("Om nom nom nom...");
            LoadingText.setPosition(App.getSize().x / 2 - LoadingText.getLocalBounds().width / 2, App.getSize().y / 2 - LoadingText.getLocalBounds().height / 2);
        }
        else if (Timer.getElapsedTime().asMilliseconds() > 4000)
        {
            LoadingText.setString("All those delicious playlists...");
            LoadingText.setPosition(App.getSize().x / 2 - LoadingText.getLocalBounds().width / 2, App.getSize().y / 2 - LoadingText.getLocalBounds().height / 2);
        }
        
        if (RetryTimer.getElapsedTime().asMilliseconds() > 1000)
        {
            RetryTimer.restart();
            try
            {
				std::cout << "Trying..." << std::endl;
                Parser::GetNowPlaying();
                
                return 1; // Go to main screen
            }
            catch (QueException e)
            {
                // Still an error :/
                std::cout << "Still an error :/" << std::endl;
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