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
	obj.m_force = { 0, 0 };
	for (int i = 0; i < m_behaviourList.size(); i++)
	{
		// The force calculated by the behaviour’s update will be added to m_force
		m_behaviourList[i]->Update(this, deltaTime);
	}
	obj.m_velocity = (Vector2Add(obj.m_velocity, Vector2Scale(obj.m_force, deltaTime)));
	obj.m_position = (Vector2Add(obj.m_position, Vector2Scale(obj.m_velocity, deltaTime)));
}

// Add a behaviour to the agent
void Agent::AddBehaviour(Behaviour* behaviour)
{
	m_behaviourList.push_back(behaviour);
}