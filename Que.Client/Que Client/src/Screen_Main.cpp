//
//  Screen_Main.cpp
//  Que Client
//
//  Created by Mathias Hansen on 23/08/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#include <iostream>
#include "Screen_Main.h"
#include "RectangleShape.h"

int Screen_Main::Run(sf::RenderWindow &App)
{
    // Define colors
    sf::Color darkColor = sf::Color(20, 20, 20);
    sf::Color grayColor = sf::Color(120, 120, 120);
    sf::Color gradientColor1 = sf::Color(33, 115, 222);
    sf::Color gradientColor2 = sf::Color(46, 59, 82);
    
    // Background
	sf::RectangleShape background = sf::RectangleShape(sf::Vector2f(0, 0));
	background.setSize(sf::Vector2f(App.getSize().x, App.getSize().y));
	background.setFillColor(darkColor); // TODO: Make this a gradient
    
    // Now playing data
    NowPlaying *nowPlaying = Parser::GetNowPlaying();
    
    std::vector<Track*> queueTracks = Parser::GetQueue();
    
    // Album cover
    sf::Texture albumCoverImage;
    
    if (nowPlaying->getPlaying())
    {
        albumCoverImage = nowPlaying->getTrack()->getAlbumCoverImage();
    }
    
    sf::Sprite albumCoverImageSprite(albumCoverImage);
    albumCoverImageSprite.setPosition(40, 40);
    albumCoverImageSprite.setScale(2.0, 2.0);
    
    std::string oldTrackLink = "";
    
    if (nowPlaying->getPlaying())
    {
        oldTrackLink = nowPlaying->getTrack()->getLink();
    }
    
    // Font
    sf::Font DeliciousFont;
    
    if (!DeliciousFont.loadFromFile(DEFAULT_FONT))
    {
        std::cout << "Missing font" << std::endl;
    }
    
    sf::Clock NowPlayingTimer;
    sf::Clock QueueShiftTimer;
    
    int queueAnimationStartX = 735;
    int queueAnimationX = queueAnimationStartX;
    int queueAnimationMin = queueAnimationStartX;
    int queueAnimationMax = queueAnimationStartX;
    int queueAnimationTotalSteps = 50;
    int queueAnimationCurrentStep = queueAnimationTotalSteps;
    
    int fadeToBlackValue = 0;
    
    // Main loop
    bool running = true;
    
	while (running)
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
            
            if (Event.type == sf::Event::MouseButtonPressed && fadeToBlackValue <= 0)
            {
                fadeToBlackValue = 1;
            }
		}
        
		if (NowPlayingTimer.getElapsedTime().asMilliseconds() >= 1000)
        {
            nowPlaying = Parser::GetNowPlaying();
            std::vector<Track*> tempQueueTracks = Parser::GetQueue();
            
            if (!TrackQueuesEqual(queueTracks, tempQueueTracks))
            {
                queueTracks = tempQueueTracks;
            }
            
            // Update album cover image if needed
			if (nowPlaying->getPlaying() && (oldTrackLink != nowPlaying->getTrack()->getLink() || albumCoverImage.getSize().x == 0))
            {
                albumCoverImage = nowPlaying->getTrack()->getAlbumCoverImage();
                albumCoverImageSprite.setTexture(albumCoverImage);
				albumCoverImageSprite.setPosition(40, 40);
                albumCoverImageSprite.setScale(2.0, 2.0);
                
                oldTrackLink = nowPlaying->getTrack()->getLink();
            }
            
			NowPlayingTimer.restart();
        }
        
		if (QueueShiftTimer.getElapsedTime().asMilliseconds() >= 15000)
        {
            // Do we have more queue items left?
            int queueRows = ceil(queueTracks.size() / 5.0);
            int currentRows = floor(1 + (abs(queueAnimationX) + queueAnimationStartX) / 1800.0);
            
            if (currentRows >= queueRows)
            {
                queueAnimationMin = queueAnimationX;
                queueAnimationMax = queueAnimationStartX;
                queueAnimationCurrentStep = 0;
            }            
            else
            {
                queueAnimationMin = queueAnimationX;
                queueAnimationMax = queueAnimationX - 1800;
                queueAnimationCurrentStep = 0;
            }
            
            QueueShiftTimer.restart();
        }
        
		App.draw(background);
            
        // Queue data
        int y = albumCoverImageSprite.getPosition().y;
        
        sf::Text QueueTitle("Queue");
        QueueTitle.setFont(DeliciousFont);
        QueueTitle.setCharacterSize(65);
        QueueTitle.setPosition(800, y);
        QueueTitle.setColor(sf::Color::White);
        App.draw(QueueTitle);
        y += 110;
        
        if (queueTracks.size() <= 0)
        {
            sf::Text EmptyQueue("The queue is empty\n\nTouch the screen to request your favorite song.");
            EmptyQueue.setFont(DeliciousFont);
            EmptyQueue.setCharacterSize(34);
            EmptyQueue.setPosition(800, y);
            EmptyQueue.setColor(sf::Color::White);
            App.draw(EmptyQueue);
        }
        else
        {
            std::vector<Track*>::iterator itr;
            int queuePosition = 1;
            int x = queueAnimationX;
            int startY = y;
            
            for (itr = queueTracks.begin(); itr != queueTracks.end(); ++itr)
            {
                Track *track = *itr;
                
                sf::Texture albumCover = track->getAlbumCoverImage();
                
                sf::Sprite AlbumCoverSprite;
                AlbumCoverSprite.setTexture(albumCover);
                AlbumCoverSprite.setPosition(x + 95, y);
                AlbumCoverSprite.setScale(0.4, 0.4);
                App.draw(AlbumCoverSprite);
                
                std::stringstream queuePositionStream;
                queuePositionStream << queuePosition;
                
                sf::Text QueuePositionText(queuePositionStream.str());
                QueuePositionText.setFont(DeliciousFont);
                QueuePositionText.setCharacterSize(100);
                QueuePositionText.setPosition(x, y - 22);
                QueuePositionText.setColor(sf::Color::White);
                App.draw(QueuePositionText);
                
                sf::Text TrackTitle(track->getTitle().substr(0, 42));
                TrackTitle.setFont(DeliciousFont);
                TrackTitle.setCharacterSize(40);
                TrackTitle.setPosition(x + 245, y);
                TrackTitle.setColor(sf::Color::White);
                App.draw(TrackTitle);
                y += 65;
                
                sf::Text TrackArtist(track->getArtists().substr(0, 42));
                TrackArtist.setFont(DeliciousFont);
                TrackArtist.setCharacterSize(36);
                TrackArtist.setPosition(x + 245, y);
                TrackArtist.setColor(sf::Color::White);
                App.draw(TrackArtist);
                y += 80;
                
                if ((queuePosition % 5) == 0)
                {
                    x += 1800;
                    y = startY;
                }
                
                queuePosition++;
            }
        }
        
        sf::Text BottomText("Touch the screen to start enjoying your favorite music!");
        BottomText.setFont(DeliciousFont);
        BottomText.setCharacterSize(34);
		BottomText.setPosition(App.getSize().x / 2 - BottomText.getLocalBounds().width / 2, 1080 - 90);
        BottomText.setColor(sf::Color::White);
        App.draw(BottomText);

		// Now playing
		if (nowPlaying->getPlaying())
        {
            App.draw(albumCoverImageSprite);
            
            // Playing progress bar
			sf::RectangleShape progressBackground = sf::RectangleShape(sf::Vector2f(albumCoverImage.getSize().x * albumCoverImageSprite.getScale().x, 40));
			progressBackground.setPosition(sf::Vector2f(
				albumCoverImageSprite.getPosition().x,
				albumCoverImage.getSize().y * albumCoverImageSprite.getScale().y + albumCoverImageSprite.getPosition().y + 20
			));
			progressBackground.setFillColor(grayColor);
            App.draw(progressBackground);
            
			sf::RectangleShape progressForeground = sf::RectangleShape(sf::Vector2f(
				((float)nowPlaying->getElapsed() / (float)nowPlaying->getTrack()->getDuration()) * (albumCoverImage.getSize().x * albumCoverImageSprite.getScale().x),
                40
			));

			progressForeground.setPosition(sf::Vector2f(
				albumCoverImageSprite.getPosition().x,
				albumCoverImage.getSize().y * albumCoverImageSprite.getScale().y + albumCoverImageSprite.getPosition().y + 20
			));

			progressForeground.setFillColor(sf::Color::Black);

			// TODO: Should be gradient
			/*
            progressForeground.setPointColor(0, gradientColor1);
            progressForeground.setPointColor(1, gradientColor1);
            progressForeground.setPointColor(2, gradientColor2);
            progressForeground.setPointColor(3, gradientColor2);*/
            
            App.draw(progressForeground);
            
            // Track info
            sf::Text TrackTitle(nowPlaying->getTrack()->getTitle().substr(0, 30).substr(0, 28));
            TrackTitle.setFont(DeliciousFont);
            TrackTitle.setCharacterSize(50);
            TrackTitle.setPosition(albumCoverImageSprite.getPosition().x, albumCoverImage.getSize().y * albumCoverImageSprite.getScale().y + albumCoverImageSprite.getPosition().y + 110);
            TrackTitle.setColor(sf::Color::White);
            App.draw(TrackTitle);
            
            sf::Text TrackArtist(nowPlaying->getTrack()->getArtists().substr(0, 32));
            TrackArtist.setFont(DeliciousFont);
            TrackArtist.setCharacterSize(40);
            TrackArtist.setPosition(TrackTitle.getPosition().x, TrackTitle.getPosition().y + 70);
            TrackArtist.setColor(sf::Color::White);
            App.draw(TrackArtist);
            
            sf::Text TrackAlbum(nowPlaying->getTrack()->getAlbum().substr(0, 32));
            TrackAlbum.setFont(DeliciousFont);
            TrackAlbum.setCharacterSize(40);
			TrackAlbum.setPosition(TrackArtist.getLocalBounds().width, TrackArtist.getLocalBounds().height + 60);
            TrackAlbum.setColor(sf::Color::White);
            App.draw(TrackAlbum);
        }
        
        if (fadeToBlackValue > 0)
        {
            sf::Color fadeColor = sf::Color(0, 0, 0, SmoothStep(0, 255, 30, fadeToBlackValue, EASE_IN));
			sf::RectangleShape blackOverlay = sf::RectangleShape(sf::Vector2f(0, 0));
			blackOverlay.setSize(sf::Vector2f(App.getSize().x, App.getSize().y));
			blackOverlay.setFillColor(fadeColor);
            
            App.draw(blackOverlay);
            
            if (fadeToBlackValue >= 30)
            {
                fadeToBlackValue = 0;
                
                return 2; // Go to browse screen
            }
            else
            {
                fadeToBlackValue++;
            }
        }
        
		App.display();
        
        queueAnimationCurrentStep++;
        
        if (queueAnimationCurrentStep < queueAnimationTotalSteps)
        {
            queueAnimationX = SmoothStep(queueAnimationMin, queueAnimationMax, queueAnimationTotalSteps, queueAnimationCurrentStep, EASE_IN);
        }
        else
        {
            queueAnimationX = queueAnimationMax;
        }
	}
    
    return 0;
}

bool Screen_Main::TrackQueuesEqual(std::vector<Track*>queue1, std::vector<Track*>queue2)
{
    if (queue1.size() != queue2.size())
        return false;
    
    int i = 0;
    std::vector<Track*>::iterator itr;
    for (itr = queue1.begin(); itr != queue1.end(); ++itr)
    {
        Track *track1 = *itr;
        Track *track2 = queue2[i];
        
        if (track1->getTitle() != track2->getTitle())
            return false;
        
        i++;
    }
    
    return  true;
}
