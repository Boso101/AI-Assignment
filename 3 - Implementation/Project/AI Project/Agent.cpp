#include "Agent.h"
#include "Behaviour.h"
Agent::Agent()
{


}
Agent::~Agent()
{}
// Update the agent and its behaviours
void Agent::Update(GameObject obj, float deltaTime)
{
	// Force is equal to zero
	// For each Behaviour in Behaviour list
	// Call the Behaviour’s Update function which will add a value to Force
	// Add Force multiplied by delta time to Velocity
	// Add Velocity multiplied by delta time to Position

	//Only try this stuff if we have a Movement Component
	if (movement)
	{


		movement->force = { 0, 0 };
	for (int i = 0; i < behaviourList.size(); i++)
	{
		// The force calculated by the behaviour’s update will be added to m_force
		behaviourList[i]->Update(this, deltaTime);
	}
	movement->velocity = (Vector2Add(movement->velocity, Vector2Scale(movement->force, deltaTime)));
	obj.position = (Vector2Add(obj.position, Vector2Scale(movement->velocity, deltaTime)));
}
}

void Agent::Draw(GameObject obj) 
{

}

// Add a behaviour to the agent
void Agent::AddBehaviour(Behaviour* behaviour)
{
	behaviourList.push_back(behaviour);
}

MovementPtr& Agent::GetMovementComponent()
{
	return movement;
}
