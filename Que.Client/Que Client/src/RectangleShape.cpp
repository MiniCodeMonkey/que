#include "RectangleShape.h"

void RectangleShape::SetPointPosition(unsigned int i, const sf::Vector2f& position)
{
    myVertices[i].position = position;
}

void RectangleShape::SetPointColor(unsigned int i, const sf::Color& color)
{
    myVertices[i].color = color;
}

void RectangleShape::Draw(sf::RenderTarget& target, sf::RenderStates states) const
{
    states.transform *= getTransform();
    target.draw(myVertices, 4, sf::Quads, states);
}
