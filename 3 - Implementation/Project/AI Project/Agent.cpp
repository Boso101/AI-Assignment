#include "Agent.h"
#include "Behaviour.h"
Agent::Agent()
{}
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
	obj.force = { 0, 0 };
	for (int i = 0; i < behaviourList.size(); i++)
	{
		// The force calculated by the behaviour’s update will be added to m_force
		behaviourList[i]->Update(this, deltaTime);
	}
	obj.velocity = (Vector2Add(obj.velocity, Vector2Scale(obj.force, deltaTime)));
	obj.position = (Vector2Add(obj.position, Vector2Scale(obj.velocity, deltaTime)));
}

// Add a behaviour to the agent
void Agent::AddBehaviour(Behaviour* behaviour)
{
	behaviourList.push_back(behaviour);
}