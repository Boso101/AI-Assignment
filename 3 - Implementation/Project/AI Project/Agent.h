#pragma once
#include "raymath.h"
#include <vector>
class Behaviour;
class Agent
{
public:
	Agent();
	virtual ~Agent();

	// Add a behaviour to the agent
	void AddBehaviour(Behaviour* behaviour);
	
protected:
	std::vector<Behaviour*> m_behaviourList;

};