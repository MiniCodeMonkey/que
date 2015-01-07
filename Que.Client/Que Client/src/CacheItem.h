#ifndef CACHE_ITEM_H
#define CACHE_ITEM_H

#include <SFML/Graphics.hpp>
#include <time.h>

class CacheItem {
private:
	sf::Texture image;
	int lastTouch;

public:
	CacheItem() { lastTouch = time((time_t)NULL); }
	void SetImage(sf::Texture image) { this->image = image; lastTouch = time((time_t)NULL); }
	sf::Texture GetImage() { lastTouch = time((time_t)NULL); return this->image; }
	bool Expired() { return (time((time_t)NULL) - lastTouch) > 3600; }
};

#endif