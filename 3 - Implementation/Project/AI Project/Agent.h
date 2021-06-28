#pragma once
#include "Component.h"
#include <vector>

class Behaviour;

class Agent : public Component
{
public:
	Agent();
	virtual ~Agent();

	void Update(GameObject obj, float deltaTime) override;

	// Add a behaviour to the agent
	void AddBehaviour(Behaviour* behaviour);
	
protected:
	std::vector<Behaviour*> behaviourList;

};