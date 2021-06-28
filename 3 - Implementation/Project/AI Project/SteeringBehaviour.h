#pragma once
#include "SteeringForce.h"
typedef std::shared_ptr<SteeringForce> SteeringForcePtr;

class SteeringBehaviour : public SteeringForce
{

	void AddSteeringForce(SteeringForcePtr forcePtr);

protected:
	std::vector<SteeringForcePtr> forces;
};

