#pragma once
#include "Component.h"
class Sensor : public Component
{
public:
	Sensor();


protected:
	void CheckForTarget();
	GameObject* target;
	float radius; // Radius of sensor circle
};

