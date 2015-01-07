#ifndef __RECTANGLESHAPE_H__
#define __RECTANGLESHAPE_H__

#include <SFML/Graphics.hpp>

class RectangleShape : public sf::Drawable, public sf::Transformable
{
public:
	void SetPointPosition(unsigned int i, const sf::Vector2f& position);
	void SetPointColor(unsigned int i, const sf::Color& color);

private:
	virtual void Draw(sf::RenderTarget& target, sf::RenderStates states) const;
	sf::Vertex myVertices[4];
};

#endif