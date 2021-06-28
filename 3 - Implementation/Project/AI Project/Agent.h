#include "raymath.h"
#include "Component.h"
#include <vector>
#pragma once
class Behaviour;
class Agent : public Component
{
public:
	Agent();
	virtual ~Agent();

	void Update(GameObject obj, float deltaTime);

	// Add a behaviour to the agent
	void AddBehaviour(Behaviour* behaviour);
	
protected:
	std::vector<Behaviour*> m_behaviourList;

};