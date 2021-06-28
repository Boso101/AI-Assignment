#include "Component.h"
#pragma once
class Sensor : public Component
{
public:



protected:
	void CheckForTarget();
	float radius; // Radius of sensor circle
};

