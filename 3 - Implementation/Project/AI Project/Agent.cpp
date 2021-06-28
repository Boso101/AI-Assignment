#include "Agent.h"
#include "Behaviour.h"
Agent::Agent()
{}
Agent::~Agent()
{}
// Update the agent and its behaviours
void Agent::Update(float deltaTime)
{
	// Force is equal to zero
	// For each Behaviour in Behaviour list
	// Call the Behaviour’s Update function which will add a value to Force
	// Add Force multiplied by delta time to Velocity
	// Add Velocity multiplied by delta time to Position
	m_force = { 0, 0 };
	for (int i = 0; i < m_behaviourList.size(); i++)
	{
		// The force calculated by the behaviour’s update will be added to m_force
		m_behaviourList[i]->Update(this, deltaTime);
	}
	m_velocity = (Vector2Add(m_velocity, Vector2Scale(m_force, deltaTime)));
	m_position = (Vector2Add(m_position, Vector2Scale(m_velocity, deltaTime)));
}
// Draw the agent
void Agent::Draw()
{
	DrawRectangle(m_position.x, m_position.y, 10, 10, RED);
}
// Add a behaviour to the agent
void Agent::AddBehaviour(Behaviour* behaviour)
{
	m_behaviourList.push_back(behaviour);
}