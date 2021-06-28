#pragma once
#include "GameObject.h"
class Component
{
public:

	/// <summary>
	/// Override this with whatever component inherits
	/// </summary>
	/// <param name="obj"></param>
	/// <param name="deltaTime"></param>
	virtual void Update(GameObject obj, float deltaTime) = 0;
	virtual void Draw(GameObject obj) = 0;
};
