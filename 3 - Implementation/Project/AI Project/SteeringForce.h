#include <raymath.h>
#include "Agent.h"

#pragma once
class SteeringForce
{
public:
	virtual Vector2 GetForce(Agent* agent) = 0;
	float GetWeight();
	void SetWeight(float newWeight);
protected:
	float weight;
};

