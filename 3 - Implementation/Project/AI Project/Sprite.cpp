#include "Sprite.h"

void Sprite::Draw(GameObject obj)
{
	//TODO: Don't hardcode
	DrawCircle(obj.m_position.x, obj.m_position.y, 10, RED);
}