//
//  Screen_Browse.cpp
//  Que Client
//
//  Created by Mathias Hansen on 23/08/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#include <iostream>
#include <math.h>
#include "Parser.h"
#include "Screen_Browse.h"
#include "QueException.h"
#include "RectangleShape.h"
#include "RoundedRectangleShape.hpp"

void Screen_Browse::LoadPlaylists()
{
	putInQueueOverlay = false;
	selectedTrack = NULL;
    isLoaded = false;
    
    int maxSongsInPlaylist = 60;
	int maxSongsPerTexture = 24;
    
	this->playlists = Parser::GetPlaylists();

    // Font
    sf::Font DeliciousFont;
    if (!DeliciousFont.loadFromFile(DEFAULT_FONT))
    {
        std::cout << "Missing font" << std::endl;
    }
    
    // Pre render rendertextures
    int x = 0;
    int y = 0;

    for (int playlistNo = 0; playlistNo < playlists->getPlaylists().size(); playlistNo++)
    {
        x = 0;
        y = 0;
        
        Playlist *playlist = playlists->getPlaylists()[playlistNo];
		int tracksCount = ((int)playlist->getTracks().size() > maxSongsInPlaylist) ? maxSongsInPlaylist : (int)playlist->getTracks().size();
		playlistHeights.push_back(tracksCount * 82);
		playlistTextures.push_back(std::vector<sf::Texture>());

		int texturesCount = ceil((double)tracksCount / (double)maxSongsPerTexture);
		int trackNo = 0;

		for (int textureNo = 0; textureNo < texturesCount; textureNo++)
		{
			y = 0;
			sf::RenderTexture renderTexture;
			int rest = tracksCount - trackNo;
			int textureSongsCount = (tracksCount > maxSongsPerTexture ? maxSongsPerTexture : tracksCount);
			textureSongsCount = (textureSongsCount > rest) ? rest : textureSongsCount;

			int height = textureSongsCount * 82;
			renderTexture.create(PLAYLIST_WIDTH, height);
            
			sf::RectangleShape backgroundShape;
			backgroundShape.setPosition(0, 0);
			backgroundShape.setSize(sf::Vector2f(PLAYLIST_WIDTH, height));
			backgroundShape.setFillColor(sf::Color::Black);
			renderTexture.draw(backgroundShape);

			for (int textureTrackNo = 0; textureTrackNo < textureSongsCount; textureTrackNo++)
			{
				Track *track = playlist->getTracks()[trackNo];

				sf::Texture albumCover = track->getAlbumCoverImage();
            
				sf::Sprite AlbumCoverSprite;
				AlbumCoverSprite.setTexture(albumCover);
				AlbumCoverSprite.setPosition(x, y);
				AlbumCoverSprite.setScale(0.25, 0.25);
				renderTexture.draw(AlbumCoverSprite);
             
				sf::Text TrackTitle(track->getTitle().substr(0, 35));
				TrackTitle.setFont(DeliciousFont);
				TrackTitle.setCharacterSize(25);
				TrackTitle.setPosition(x + 85, y);
				TrackTitle.setColor(sf::Color::White);
				renderTexture.draw(TrackTitle);
				y += 37;
            
				sf::Text TrackArtist(track->getArtists().substr(0, 35));
				TrackArtist.setFont(DeliciousFont);
				TrackArtist.setCharacterSize(21);
				TrackArtist.setPosition(x + 85, y);
				TrackArtist.setColor(sf::Color::White);
				renderTexture.draw(TrackArtist);
				y += 45;
            
				trackNo++;
			}

			renderTexture.display();
			playlistTextures[playlistNo].push_back(renderTexture.getTexture());
		}
    }
    
    isLoaded = true;
}

int Screen_Browse::Run(sf::RenderWindow &App)
{
    currentBrowseState = BROWSE;
    
    // Define colors
    sf::Color darkColor = sf::Color(20, 20, 20);
    sf::Color grayColor = sf::Color(120, 120, 120);
    sf::Color gradientColor1 = sf::Color(33, 115, 222);
    sf::Color gradientColor2 = sf::Color(46, 59, 82);
    
    // Background
    sf::RectangleShape background;
	background.setPosition(0, 0);
	background.setSize(sf::Vector2f(App.getSize().x, App.getSize().y));
	background.setFillColor(sf::Color::White);

	// TODO: Gradient
	/*
    background.setPointColor(0, darkColor);
    background.setPointColor(1, darkColor);
    background.setPointColor(2, grayColor);
    background.setPointColor(3, grayColor);*/
    
    // Search field graphics
    sf::Texture searchFieldTexture;
    if (!searchFieldTexture.loadFromFile("searchfield_background.png"))
    {
        std::cout << "Missing searchfield background image" << std::endl;
    }
    sf::Sprite searchFieldSprite(searchFieldTexture);
    searchFieldSprite.setPosition(App.getSize().x / 2 - searchFieldTexture.getSize().x / 2, 50);
    
    sf::Texture searchFieldClearTexture;
    if (!searchFieldClearTexture.loadFromFile("searchfield_clear.png"))
    {
        std::cout << "Missing searchfield clear image" << std::endl;
    }
    sf::Sprite searchFieldClearSprite(searchFieldClearTexture);
    searchFieldClearSprite.setPosition(searchFieldSprite.getPosition().x + searchFieldTexture.getSize().x - 70, searchFieldSprite.getPosition().y + (searchFieldTexture.getSize().y / 2 - searchFieldClearTexture.getSize().y / 2));
    
    // Font
    sf::Font DeliciousFont;
    if (!DeliciousFont.loadFromFile(DEFAULT_FONT))
    {
        std::cout << "Missing font" << std::endl;
    }

	// Back button
	sf::Texture backButtonImage;
	if (!backButtonImage.loadFromFile("back.png"))
	{
		std::cout << "Missing back.png" << std::endl;
	}
	sf::Sprite backButtonSprite(backButtonImage);
	backButtonSprite.setPosition(60, 40);
	sf::IntRect backButtonRect = sf::IntRect(60, 40, 64, 64);

	// Left arrow
	sf::Texture arrowLeftButtonImage;
	if (!arrowLeftButtonImage.loadFromFile("arrow_left.png"))
	{
		std::cout << "Missing arrow_left.png" << std::endl;
	}
	sf::Sprite arrowLeftButtonSprite(arrowLeftButtonImage);
	arrowLeftButtonSprite.setPosition(PLAYLIST_MARGIN / 2, PLAYLISTS_Y - 75);
	sf::IntRect arrowLeftButtonRect = sf::IntRect(arrowLeftButtonSprite.getPosition().x, arrowLeftButtonSprite.getPosition().y, 64, 64);

	// Right arrow
	sf::Texture arrowRightButtonImage;
	if (!arrowRightButtonImage.loadFromFile("arrow_right.png"))
	{
		std::cout << "Missing arrow_right.png" << std::endl;
	}
	sf::Sprite arrowRightButtonSprite(arrowRightButtonImage);
	arrowRightButtonSprite.setPosition(App.getSize().x - (PLAYLIST_MARGIN / 2) - 64, PLAYLISTS_Y - 75);
	sf::IntRect arrowRightButtonRect = sf::IntRect(arrowRightButtonSprite.getPosition().x, arrowRightButtonSprite.getPosition().y, 64, 64);
    
    // Init views    
    std::vector<int> verticalOffsets;
	std::vector<double> verticalVelocities;
    for (int i = 0; i < playlists->getPlaylists().size(); i++)
    {
        verticalOffsets.push_back(0);
		verticalVelocities.push_back(0.0);
    }
    
    int fadeToBlackValue = 1;
    
    // Main loop
    bool running = true;
    
    int playlistsAnimationStep = 0;
    
    sf::Clock VerticalBarBlinkTimer;
    sf::IntRect mouseRect = sf::IntRect(); // Keep the current mouse rects
    bool mousePressed = false;
	bool mouseReleased = false;
    bool mouseOverButton = false;
    std::string searchQuery;
    std::vector<Track*> searchResults;
    int keyboardSmoothStep = 0;
	int lastScrollTime = 0;

	sf::IntRect cancelOverlayRect;
	sf::IntRect acceptOverlayRect;
	std::string overlayError = "";
	int lastMouseY = -1;
	int lastScrolledColumn = -1;
	bool isScrolling = false;
	deltaPlaylistX = 0;
    
    while (running)
    {
        //printf("FPS: %f\n", 1000.0 / App.getFrameTime());

		mouseReleased = false;
        if (!mousePressed)
            mouseRect = sf::IntRect(); // Reset the mouse position
        
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

			if (!putInQueueOverlay)
			{
				if (Event.type == sf::Event::MouseButtonPressed)
				{
					mousePressed = true;
					mouseRect = sf::IntRect(Event.mouseButton.x, Event.mouseButton.y, 1, 1);
				}

				if (Event.type == sf::Event::MouseMoved)
				{
					mouseRect = sf::IntRect(Event.mouseMove.x, Event.mouseMove.y, 1, 1);
					
					int currentMouseY = Event.mouseMove.y;

					if (lastMouseY == -1)
						lastMouseY = currentMouseY;

					int deltaY = currentMouseY - lastMouseY;

					if (currentBrowseState == BROWSE && mousePressed)
					{
						if (deltaY != 0)
						{
							int columnNo = 0;

							for (int i = 0; i < verticalOffsets.size(); i++)
							{
								if (Event.mouseMove.x >= this->getPlaylistX(i) && Event.mouseMove.x <= this->getPlaylistX(i + 1))
								{
									columnNo = i;
								}
							}

							lastScrolledColumn = columnNo;
							verticalOffsets[columnNo] -= deltaY;
							verticalVelocities[columnNo] = deltaY;
							isScrolling = true;
							lastScrollTime = time((time_t)NULL);
							
							// Limit offsets
							if (verticalOffsets[columnNo] <= 0)
							{
								verticalOffsets[columnNo] = 0;
							}

							if (verticalOffsets[columnNo] > playlistHeights[columnNo] - (int)App.getSize().y + PLAYLISTS_Y + 52)
							{
								verticalOffsets[columnNo] = playlistHeights[columnNo] - (int)App.getSize().y + PLAYLISTS_Y + 52;
							}
						}
					}

					lastMouseY = currentMouseY;
				}
            
				if (Event.type == sf::Event::MouseButtonReleased)
				{
					mousePressed = false;
					mouseReleased = true;
					mouseRect = sf::IntRect(Event.mouseButton.x, Event.mouseButton.y, 1, 1);
                
					if (!isScrolling)
					{
						if (currentBrowseState == BROWSE)
						{
							if (mouseRect.intersects(arrowLeftButtonRect))
							{
								int current_page = ceil((double)abs(deltaPlaylistX) / App.getSize().x) + 1;
								int max_pages = ceil(playlists->getPlaylists().size() / (double)PLAYLIST_PER_SCREEN);

								if (current_page > 1)
								{
									deltaPlaylistX += App.getSize().x;
								}
							}

							if (mouseRect.intersects(arrowRightButtonRect))
							{
								int current_page = ceil((double)abs(deltaPlaylistX) / App.getSize().x) + 1;
								int max_pages = ceil(playlists->getPlaylists().size() / (double)PLAYLIST_PER_SCREEN);

								if (current_page < max_pages)
								{
									deltaPlaylistX -= App.getSize().x;
								}
							}
						}

						if (currentBrowseState == BROWSE || currentBrowseState == SHOWING_SEARCH)
						{
							// Clicked on search field?
							if (mouseRect.intersects(sf::IntRect(searchFieldSprite.getPosition().x, searchFieldSprite.getPosition().y, searchFieldTexture.getSize().x - searchFieldClearTexture.getSize().x, searchFieldTexture.getSize().y)))
							{
								if (currentBrowseState == SHOWING_SEARCH)
								{
									currentBrowseState = TYPING_SEARCH;
									keyboardSmoothStep = 0;
								}
								else
								{
									currentBrowseState = ANIMATING_TO_SEARCH;
								}
							}
						}
						if (currentBrowseState == TYPING_SEARCH || currentBrowseState == SHOWING_SEARCH)
						{
							// Clicked on "clear field" button?
							if (mouseRect.intersects(sf::IntRect(searchFieldClearSprite.getPosition().x, searchFieldClearSprite.getPosition().y, searchFieldClearTexture.getSize().x, searchFieldClearTexture.getSize().y)))
							{
								searchQuery = "";

								if (currentBrowseState == SHOWING_SEARCH)
								{
									currentBrowseState = TYPING_SEARCH;
									keyboardSmoothStep = 0;
								}
							}
						}
					}
					else
					{
						isScrolling = false;
						lastScrollTime = time((time_t)NULL);
					}
				}
			}
			else
			{
				if (Event.type == sf::Event::MouseButtonReleased)
				{
					mouseRect = sf::IntRect(Event.mouseButton.x, Event.mouseButton.y, 1, 1);
					
					if (mouseRect.intersects(cancelOverlayRect) && overlayError.length() <= 0)
					{
						selectedTrack = NULL;
						putInQueueOverlay = false;
					}
					
					if (mouseRect.intersects(acceptOverlayRect))
					{
						if (overlayError.length() == 0)
						{
							overlayError = Parser::Enqueue(selectedTrack);

							if (overlayError == "OK")
							{
								overlayError = "";
								selectedTrack = NULL;
								putInQueueOverlay = false;
								return 1;
							}
						}
						else
						{
							overlayError = "";
							selectedTrack = NULL;
							putInQueueOverlay = false;
						}
					}
				}
			}
		}

		for (int i = 0; i < playlists->getPlaylists().size(); i++)
		{
			if (lastScrolledColumn == i && isScrolling)
			{
			}
			else if (verticalVelocities[i] != 0.0)
			{
				//  Limit velocities
				if (verticalVelocities[i] > 0.0)
					verticalVelocities[i] -= 0.1;
				else
					verticalVelocities[i] += 0.1;

				if (abs(verticalVelocities[i]) <= 0.2)
					verticalVelocities[i] = 0.0;

				// Set new offset
				verticalOffsets[i] -= verticalVelocities[i];

				// Limit offsets
				if (verticalOffsets[i] <= 0)
				{
					verticalOffsets[i] = 0;
				}

				if (verticalOffsets[i] > playlistHeights[i] - (int)App.getSize().y + PLAYLISTS_Y + 52)
				{
					verticalOffsets[i] = playlistHeights[i] - (int)App.getSize().y + PLAYLISTS_Y + 52;
				}
			}
		}

		if (mouseReleased && backButtonRect.intersects(mouseRect))
		{
			if (currentBrowseState >= TYPING_SEARCH)
			{
				currentBrowseState = BROWSE;
			}
			else
			{
				return 1;
			}
		}

        App.draw(background);
		App.draw(backButtonSprite);

		if (currentBrowseState == BROWSE)
		{
			App.draw(arrowLeftButtonSprite);
			App.draw(arrowRightButtonSprite);
		}
        
        if (currentBrowseState >= LOADING_SEARCH)
        {
            int x = SmoothStep(App.getSize().x, 85, 50, keyboardSmoothStep, EASE_IN);
            int y = 200;
            
            for (int i = 0; i < searchResults.size(); i++)
            {
                Track *track = searchResults[i];
                
                sf::IntRect buttonRect = sf::IntRect(x, y, 390 - 85, 82);
                
                if (buttonRect.intersects(mouseRect))
                {
                    if (mousePressed)
                    {
						sf::RectangleShape buttonOverlay;
						buttonOverlay.setPosition(x, y);
						buttonOverlay.setSize(sf::Vector2f(380 - 85, 75));
						buttonOverlay.setFillColor(sf::Color(150, 150, 150));
                        App.draw(buttonOverlay);
                    }
                    else if (mouseReleased)
                    {
						putInQueueOverlay = true;
						selectedTrack = track;
                    }
                }
                
                /*sf::Texture albumCover = track->getAlbumCoverImage();
                
                sf::Sprite AlbumCoverSprite;
                AlbumCoverSprite.setTexture(albumCover);
                AlbumCoverSprite.setPosition(x, y);
                AlbumCoverSprite.setScale(0.25, 0.25);
                App.draw(AlbumCoverSprite);*/
                
                sf::Text TrackTitle(track->getTitle().substr(0, 25));
                TrackTitle.setFont(DeliciousFont);
                TrackTitle.setCharacterSize(25);
                TrackTitle.setPosition(x/* + 85*/, y);
                TrackTitle.setColor(sf::Color::White);
                App.draw(TrackTitle);
                y += 37;
                
                sf::Text TrackArtist(track->getArtists().substr(0, 25));
                TrackArtist.setFont(DeliciousFont);
                TrackArtist.setCharacterSize(21);
                TrackArtist.setPosition(x/* + 85*/, y);
                TrackArtist.setColor(sf::Color::White);
                App.draw(TrackArtist);
                y += 45;
                
                if (y > 200 + (82 * 9))
                {
                    x += 390 - 85;
                    y = 200;
                }
            }
        }
        
        if (currentBrowseState >= TYPING_SEARCH && currentBrowseState != SHOWING_SEARCH)
        {
            // Keyboard
            sf::Color keyboardButtonColor1 = sf::Color(226, 226, 226);
            sf::Color keyboardButtonColor2 = sf::Color::White;
            sf::Color keyboardButtonColorOver1 = sf::Color(176, 176, 176);
            sf::Color keyboardButtonColorOver2 = sf::Color(226, 226, 226);
            
            sf::Color keyboardButtonAltColor1 = sf::Color(keyboardButtonColor1.r - 100, keyboardButtonColor1.g - 100, keyboardButtonColor1.b - 100);
            sf::Color keyboardButtonAltColor2 = sf::Color(keyboardButtonColor2.r - 100, keyboardButtonColor2.g - 100, keyboardButtonColor2.b - 100);
            sf::Color keyboardButtonAltColorOver1 = sf::Color(keyboardButtonColorOver1.r - 100, keyboardButtonColorOver1.g - 100, keyboardButtonColorOver1.b - 100);
            sf::Color keyboardButtonAltColorOver2 = sf::Color(keyboardButtonColorOver2.r - 100, keyboardButtonColorOver2.g - 100, keyboardButtonColorOver2.b - 100);
            
            sf::Color keyboardButtonBorderColor = sf::Color(200, 200, 200);
            
            // Letters
            char letters[] = "QWERTYUIOPÅ\nASDFGHJKLÆØ\n/-ZXCVBNM.:\n";
            int startX = App.getSize().x / 2 - 1450 / 2;
            int startY = App.getSize().y - (80 * 4) - 30;
            
            if (currentBrowseState == LOADING_SEARCH)
            {
                startY = SmoothStep(App.getSize().y - (80 * 4) - 30, App.getSize().y, 50, keyboardSmoothStep, EASE_IN);
                keyboardSmoothStep++;
                
                if (keyboardSmoothStep > 50)
                {
                    currentBrowseState = SHOWING_SEARCH;
                }
            }
            
            int x = startX;
            int y = startY;
            for (int i = 0; i < sizeof(letters); i++)
            {
                if (letters[i] == '\0')
                {
                    continue;
                }
                if (letters[i] == '\n')
                {
                    x = startX;
                    y += 80;
                }
                else
                {
                    sf::IntRect buttonRect = sf::IntRect(x, y, 90, 70);
                    
                    if (buttonRect.intersects(mouseRect))
                    {
                        if (mousePressed)
                        {
                            mouseOverButton = true;
                        }
                        else if (mouseReleased)
                        {
                            searchQuery += tolower(letters[i]);
                        }
                    }
                    
					sf::RoundedRectangleShape button;
					button.setPosition(x, y);
					button.setSize(sf::Vector2f(90, 70));
					button.setCornersRadius(10);
					button.setFillColor((mouseOverButton) ? keyboardButtonColorOver1 : keyboardButtonColor1);
					button.setOutlineThickness(2);
					button.setOutlineColor(keyboardButtonBorderColor);
                    App.draw(button);
                    mouseOverButton = false;
                    
                    sf::Text buttonText;
                    buttonText.setFont(DeliciousFont);
                    buttonText.setString(letters[i]);
                    buttonText.setColor(sf::Color::Black);
                    buttonText.setCharacterSize(60);
					buttonText.setPosition(x - (buttonText.getLocalBounds().width / 2 - 90 / 2), y - (buttonText.getLocalBounds().height / 2 - 70 / 2) - 10);
                    App.draw(buttonText);
                    
                    x += 100;
                }
            }
            
            // Space button
            x = startX + 200;
            sf::IntRect buttonRect = sf::IntRect(x + 20, y, 700 - 50, 70);
            
            if (buttonRect.intersects(mouseRect))
            {
                if (mousePressed)
                {
                    mouseOverButton = true;
                }
                else if (mouseReleased)
                {
                    if (searchQuery.substr(searchQuery.length() - 1, 1) != " ")
                    {
                        searchQuery += " ";
                    }
                }
            }
            
			sf::RoundedRectangleShape spaceButton;
			spaceButton.setPosition(x + 20, y);
			spaceButton.setSize(sf::Vector2f(700 - 50, 70));
			spaceButton.setCornersRadius(10);
			spaceButton.setFillColor((mouseOverButton) ? keyboardButtonColorOver1 : keyboardButtonColor1);
			spaceButton.setOutlineThickness(2);
			spaceButton.setOutlineColor(keyboardButtonBorderColor);
            App.draw(spaceButton);
            mouseOverButton = false;
            
            // Backspace button
            x = startX + 900;
            
            buttonRect = sf::IntRect(x, y, 90, 70);
            
            if (buttonRect.intersects(mouseRect))
            {
                if (mousePressed)
                {
                    mouseOverButton = true;
                }
                else if (mouseReleased)
                {
                    if (searchQuery.size() > 0)
                    {
                        searchQuery = searchQuery.substr(0, searchQuery.size() - 1);
                    }
                }
            }
            
			sf::RoundedRectangleShape backspaceButton;
			backspaceButton.setPosition(x, y);
			backspaceButton.setSize(sf::Vector2f(90, 70));
			backspaceButton.setCornersRadius(10);
			backspaceButton.setFillColor((mouseOverButton) ? keyboardButtonColorOver1 : keyboardButtonColor1);
			backspaceButton.setOutlineThickness(2);
			backspaceButton.setOutlineColor(keyboardButtonBorderColor);
            App.draw(backspaceButton);
            mouseOverButton = false;
            
            sf::Text buttonText;
            buttonText.setFont(DeliciousFont);
            buttonText.setString("<-");
            buttonText.setColor(sf::Color::Black);
            buttonText.setCharacterSize(60);
			buttonText.setPosition(x - (buttonText.getLocalBounds().width / 2 - 90 / 2), y - (buttonText.getLocalBounds().height / 2 - 70 / 2) - 10);
            App.draw(buttonText);
            x += 100;
            
            // Search/Go button
            buttonRect = sf::IntRect(x, y, 90, 70);
            
            if (buttonRect.intersects(mouseRect))
            {
                if (mousePressed)
                {
                    mouseOverButton = true;
                }
                else if (mouseReleased)
                {
                    searchResults = Parser::Search(searchQuery);
                    currentBrowseState = LOADING_SEARCH;
                }
            }

			sf::RoundedRectangleShape searchButton;
			searchButton.setPosition(x, y);
			searchButton.setSize(sf::Vector2f(90, 70));
			searchButton.setCornersRadius(10);
			searchButton.setFillColor((mouseOverButton) ? keyboardButtonColorOver1 : keyboardButtonColor1);
			searchButton.setOutlineThickness(2);
			searchButton.setOutlineColor(keyboardButtonBorderColor);
            App.draw(searchButton);

            mouseOverButton = false;
            
            buttonText.setFont(DeliciousFont);
            buttonText.setString("Go");
            buttonText.setColor(sf::Color::White);
            buttonText.setCharacterSize(40);
            buttonText.setPosition(x - (buttonText.getLocalBounds().width / 2 - 90 / 2), y - (buttonText.getLocalBounds().height / 2 - 70 / 2) - 10);
            App.draw(buttonText);
            
            App.draw(spaceButton);
            mouseOverButton = false;
            
            x = startX + 1350;
            y = startY;
            
            // Num pad
            for (int i = 9; i > 0; i--)
            {
                std::stringstream number;
                number << i;
                
                sf::IntRect buttonRect = sf::IntRect(x, y, 90, 70);
                
                if (buttonRect.intersects(mouseRect))
                {
                    if (mousePressed)
                    {
                        mouseOverButton = true;
                    }
                    else if (mouseReleased)
                    {
                        searchQuery += number.str();
                    }
                }

				sf::RoundedRectangleShape button;
				button.setPosition(x, y);
				button.setSize(sf::Vector2f(90, 70));
				button.setCornersRadius(10);
				button.setFillColor((mouseOverButton) ? keyboardButtonColorOver1 : keyboardButtonColor1);
				button.setOutlineThickness(2);
				button.setOutlineColor(keyboardButtonBorderColor);
				App.draw(button);
                mouseOverButton = false;
                
                sf::Text buttonText;
                buttonText.setFont(DeliciousFont);
                buttonText.setString(number.str());
                buttonText.setColor(sf::Color::Black);
                buttonText.setCharacterSize(60);
                buttonText.setPosition(x - (buttonText.getLocalBounds().width / 2 - 90 / 2), y - (buttonText.getLocalBounds().height / 2 - 70 / 2) - 10);
                App.draw(buttonText);
                
                x -= 100;
                
                if ((i - 1) % 3 == 0)
                {
                    x = startX + 1350;
                    y += 80;
                }
            }
            
            // Zero button
            x = startX + 1150;
            
            buttonRect = sf::IntRect(x, y, 190, 70);
            
            if (buttonRect.intersects(mouseRect))
            {
                if (mousePressed)
                {
                    mouseOverButton = true;
                }
                else if (mouseReleased)
                {
                    searchQuery += "0";
                }
            }
            
			sf::RoundedRectangleShape zeroButton;
			zeroButton.setPosition(x, y);
			zeroButton.setSize(sf::Vector2f(190, 70));
			zeroButton.setCornersRadius(10);
			zeroButton.setFillColor((mouseOverButton) ? keyboardButtonColorOver1 : keyboardButtonColor1);
			zeroButton.setOutlineThickness(2);
			zeroButton.setOutlineColor(keyboardButtonBorderColor);
            App.draw(zeroButton);
            mouseOverButton = false;
            
            buttonText.setFont(DeliciousFont);
            buttonText.setString("0");
            buttonText.setColor(sf::Color::Black);
            buttonText.setCharacterSize(60);
			buttonText.setPosition(x - (buttonText.getLocalBounds().width / 2 - 190 / 2), y - (buttonText.getLocalBounds().height / 2 - 70 / 2) - 10);
            App.draw(buttonText);
            x += 200;
            
            // Comma button
            buttonRect = sf::IntRect(x, y, 90, 70);
            
            if (buttonRect.intersects(mouseRect))
            {
                if (mousePressed)
                {
                    mouseOverButton = true;
                }
                else if (mouseReleased)
                {
                    searchQuery += ",";
                }
            }
            
            sf::RoundedRectangleShape commaButton;
			commaButton.setPosition(x, y);
			commaButton.setSize(sf::Vector2f(90, 70));
			commaButton.setCornersRadius(10);
			commaButton.setFillColor((mouseOverButton) ? keyboardButtonColorOver1 : keyboardButtonColor1);
			commaButton.setOutlineThickness(2);
			commaButton.setOutlineColor(keyboardButtonBorderColor);
            App.draw(commaButton);
            mouseOverButton = false;
            
            buttonText.setFont(DeliciousFont);
            buttonText.setString(",");
            buttonText.setColor(sf::Color::Black);
            buttonText.setCharacterSize(60);
            buttonText.setPosition(x - (buttonText.getLocalBounds().width / 2 - 90 / 2), y - (buttonText.getLocalBounds().height / 2 - 70 / 2) - 10);
            App.draw(buttonText);
            
            if (searchQuery.size() > 25)
                searchQuery = searchQuery.substr(0, 25);
        }
        
        if (currentBrowseState == ANIMATING_TO_SEARCH || currentBrowseState == BROWSE)
        {
            int y = PLAYLISTS_Y;
            
            if (currentBrowseState == ANIMATING_TO_SEARCH)
            {
                int totalSteps = 20;
                
                y = SmoothStep(PLAYLISTS_Y, App.getSize().y + PLAYLISTS_Y, totalSteps, playlistsAnimationStep, EASE_IN);
                
                if (playlistsAnimationStep >= totalSteps)
                {
                    currentBrowseState = TYPING_SEARCH;
                }
                
                playlistsAnimationStep++;
            }
            
			int boxX = 0;
			int boxY = 0;

			for (int i = 0; i < playlistTextures.size(); i++)
            {
				Playlist *playlist = playlists->getPlaylists()[i];

			    sf::Text PlaylistName(playlist->getName().substr(0, 25));
				PlaylistName.setFont(DeliciousFont);
				PlaylistName.setCharacterSize(30);
				PlaylistName.setPosition(this->getPlaylistX(i), y);
				PlaylistName.setColor(sf::Color::White);
				App.draw(PlaylistName);

				int textureY = (y + 52);
				int clipY = verticalOffsets[i];
				int offset = 0;

				bool shown;
				int notClip = 0;
				for (int textureNo = 0; textureNo < playlistTextures[i].size(); textureNo++)
				{
					unsigned int height = playlistTextures[i][textureNo].getSize().y;
					
					int currentX = this->getPlaylistX(i);
					int currentY = textureY;

					int top;
					if (textureNo == 0 || !shown) // Determine if the current texture is the first texture which is actually visible
					{
						top = clipY - notClip;
					}
					else if (currentY < 0)
					{
						top = abs(currentY);
						currentY = (currentY + 52);
					}
					else
					{
						top = 0;
					}

					shown = (top < height);

					if (shown)
					{
						sf::Sprite sprite;
						sprite.setTexture(playlistTextures[i][textureNo]);
						sprite.setPosition(currentX, currentY);
						sprite.setTextureRect(sf::IntRect(0, top, playlistTextures[i][textureNo].getSize().x, playlistTextures[i][textureNo].getSize().y));
						App.draw(sprite);
						
						textureY += playlistTextures[i][textureNo].getSize().y - top;
					}
					else
					{
						notClip += playlistTextures[i][textureNo].getSize().y;
					}
				}
				
				if (!isScrolling && (time((time_t)NULL) - lastScrollTime) >= 1)
				{
					for (int ii = 0; ii < playlist->getTracks().size(); ii++)
					{
						Track *track = playlist->getTracks()[ii];

						boxX = this->getPlaylistX(i);
						boxY = (y + 52) + (82 * ii) - verticalOffsets[i];

						sf::IntRect buttonRect = sf::IntRect(boxX, boxY, 390, 82);
                
						if (buttonRect.intersects(mouseRect) && boxY > (y + 52))
						{
							if (mousePressed)
							{
								sf::RectangleShape overlayBox;
								overlayBox.setOrigin(boxX, boxY);
								overlayBox.setSize(sf::Vector2f(PLAYLIST_WIDTH, 75));
								overlayBox.setFillColor(sf::Color(150, 150, 150, 100));
								App.draw(overlayBox);
							}
							else if (mouseReleased)
							{
								putInQueueOverlay = true;
								selectedTrack = track;
							}
						}
					}
				}
            }
        }
        
        App.draw(searchFieldSprite);
        App.draw(searchFieldClearSprite);
        
        if (currentBrowseState >= ANIMATING_TO_SEARCH)
        {
            // Search query text
            sf::Text searchQueryText;
            searchQueryText.setFont(DeliciousFont);
            searchQueryText.setCharacterSize(75);
            searchQueryText.setColor(sf::Color::Black);
            searchQueryText.setPosition(searchFieldSprite.getPosition().x + 85, searchFieldSprite.getPosition().y - 12);
            searchQueryText.setString(searchQuery);
            App.draw(searchQueryText);
            
            // Vertical bar
			if (currentBrowseState <= TYPING_SEARCH)
			{
				if (VerticalBarBlinkTimer.getElapsedTime().asMilliseconds() > 1000)
				{
					VerticalBarBlinkTimer.restart();
				}
            
				if (VerticalBarBlinkTimer.getElapsedTime().asMilliseconds() > 500)
				{
					sf::RectangleShape verticalBar;
					verticalBar.setPosition(searchQueryText.getLocalBounds().left + searchQueryText.getLocalBounds().width,
						searchFieldSprite.getPosition().y + 10);
					verticalBar.setSize(sf::Vector2f(2, searchFieldTexture.getSize().y - 20));
					verticalBar.setFillColor(sf::Color::Black);
					App.draw(verticalBar);
				}
			}
        }

		if (putInQueueOverlay)
		{
			int w = 800;
			int h = 200;
			int x = App.getSize().x / 2 - w / 2;
			int y = App.getSize().y / 2 - h / 2;

			sf::RoundedRectangleShape overlayBackground;
			overlayBackground.setPosition(x, y);
			overlayBackground.setSize(sf::Vector2f(w, h));
			overlayBackground.setCornersRadius(10);
			overlayBackground.setFillColor(sf::Color(200, 200, 200));
			overlayBackground.setOutlineThickness(2);
			overlayBackground.setOutlineColor(sf::Color::White);
			App.draw(overlayBackground);
			
			std::stringstream question;

			if (overlayError.length() > 0)
			{
				question << overlayError;
			}
			else
			{
				question << "Put '" << selectedTrack->getTitle().substr(0, 20) << "' in the queue?";
			}

			sf::Text overlayText;
            overlayText.setFont(DeliciousFont);
            overlayText.setCharacterSize(25);
            overlayText.setColor(sf::Color::Black);
			overlayText.setString(question.str());

			int textX = App.getSize().x / 2 - overlayText.getLocalBounds().width / 2;
			int textY = y + 30;

			overlayText.setPosition(textX, textY);
            App.draw(overlayText);

			// Cancel button
			int buttonX = x + 20;
			int buttonY = y + h - 60 - 20;

			if (overlayError.length() <= 0)
			{
				sf::RoundedRectangleShape buttonCancel;
				buttonCancel.setPosition(buttonX, buttonY);
				buttonCancel.setSize(sf::Vector2f(180, 60));
				buttonCancel.setCornersRadius(5);
				buttonCancel.setFillColor(sf::Color(255, 87, 87));
				buttonCancel.setOutlineThickness(2);
				buttonCancel.setOutlineColor(sf::Color::White);
				App.draw(buttonCancel);
				cancelOverlayRect = sf::IntRect(buttonX, buttonY, 180, 60);

				sf::Text cancelText;
				cancelText.setFont(DeliciousFont);
				cancelText.setCharacterSize(40);
				cancelText.setColor(sf::Color::Black);
				cancelText.setString("No");
				cancelText.setPosition(buttonX + (180 / 2 - cancelText.getLocalBounds().width / 2),
					buttonY + (60 / 2 - cancelText.getLocalBounds().height / 2));
				App.draw(cancelText);
			}

			// Accept button
			buttonX = x + w - 180 - 20;
			buttonY = y + h - 60 - 20;
			sf::RoundedRectangleShape buttonAccept;
			buttonAccept.setPosition(buttonX, buttonY);
			buttonAccept.setSize(sf::Vector2f(180, 60));
			buttonAccept.setCornersRadius(5);
			buttonAccept.setFillColor(sf::Color(104, 205, 84));
			buttonAccept.setOutlineThickness(2);
			buttonAccept.setOutlineColor(sf::Color::White);
			App.draw(buttonAccept);

			App.draw(buttonAccept);
			acceptOverlayRect = sf::IntRect(buttonX, buttonY, 180, 60);

			sf::Text okText;
            okText.setFont(DeliciousFont);
            okText.setCharacterSize(40);
            okText.setColor(sf::Color::Black);
			okText.setString((overlayError.length() > 0) ? "OK" : "Yes!");
			okText.setPosition(buttonX + (180 / 2 - okText.getLocalBounds().width / 2),
				buttonY + (60 / 2 - okText.getLocalBounds().height / 2));
			App.draw(okText);
		}
        
        if (fadeToBlackValue > 0)
        {
            sf::Color fadeColor = sf::Color(0, 0, 0, SmoothStep(255, 0, 20, fadeToBlackValue, EASE_IN));
			sf::RectangleShape blackOverlay;
			blackOverlay.setPosition(0, 0);
			blackOverlay.setSize(sf::Vector2f(App.getSize().x, App.getSize().y));
			blackOverlay.setFillColor(fadeColor);
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