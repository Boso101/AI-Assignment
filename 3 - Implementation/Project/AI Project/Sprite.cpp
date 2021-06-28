#include "Sprite.h"

void Sprite::Update(GameObject obj, float deltaTime)
{
	
}

void Sprite::Draw(GameObject obj)
{
	//TODO: Don't hardcode
	DrawCircle(obj.position.x, obj.position.y, 10, RED);
}