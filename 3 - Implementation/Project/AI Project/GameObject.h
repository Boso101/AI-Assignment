#pragma once
#include <raymath.h>
class GameObject
{

public:
	// Update the GameObject and its behaviours
	virtual void Update(float deltaTime);

	// Draw the GameObject
	virtual void Draw();

	// Movement functions
	void SetPosition(Vector2 position) { m_position = position; }
	Vector2 GetPosition() { return m_position; }
	void SetVelocity(Vector2 velocity) { m_velocity = velocity; }
	Vector2 GetVelocity() { return m_velocity; }
	void AddForce(Vector2 force) { m_force = Vector2Add(force, m_force); }

protected:
	Vector2 m_position = { 0, 0 };
	Vector2 m_velocity = { 0, 0 };
	Vector2 m_force = { 0, 0 };



};