#include "SteeringForce.h"
#pragma once
typedef std::shared_ptr<SteeringForce> SteeringForcePtr;

class SteeringBehaviour : public SteeringForce
{

	void AddSteeringForce(SteeringForcePtr forcePtr);

protected:
	std::vector<SteeringForcePtr> forces;
};

