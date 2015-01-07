//
//  NowPlaying.h
//  Que Client
//
//  Created by Mathias Hansen on 23/08/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#ifndef Que_Client_NowPlaying_h
#define Que_Client_NowPlaying_h

#include "Track.h"

class NowPlaying
{
private:
    bool playing;
    int elapsed;
    Track *track;
    
public:
    bool getPlaying() { return playing; }
    void setPlaying(bool playing) { this->playing = playing; }
    int getElapsed() { return elapsed; }
    void setElapsed(int elapsed) { this->elapsed = elapsed; }
    Track *getTrack() { return track; }
    void setTrack(Track *track) { this->track = track; }
};

#endif
