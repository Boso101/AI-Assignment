#pragma once
#include "Component.h"
class Sprite : public Component
{
	void Update(GameObject obj, float deltaTime) override;
	void Draw(GameObject obj) override;
};

