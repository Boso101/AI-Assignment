#pragma once
#include "Component.h"
#include <vector>
#include "Movement.h"

class Behaviour;
typedef std::shared_ptr<Movement> MovementPtr;

class Agent : public Component
{
public:
	Agent();
	virtual ~Agent();

	void Update(GameObject obj, float deltaTime) override;
	void Draw(GameObject obj) override;

	// Add a behaviour to the agent
	void AddBehaviour(Behaviour* behaviour);

	MovementPtr& GetMovementComponent();
	
protected:
	std::vector<Behaviour*> behaviourList;
	
	//Cache movement
	MovementPtr movement;

};