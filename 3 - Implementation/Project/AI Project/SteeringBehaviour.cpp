#include "SteeringBehaviour.h"


void SteeringBehaviour::AddSteeringForce(SteeringForcePtr steeringForce)
	{
		forces.push_back(steeringForce);
	}

