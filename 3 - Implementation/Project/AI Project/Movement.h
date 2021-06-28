#pragma once
#include <raymath.h>
#include "Component.h"
class Movement : public Component
{
public:
	Movement();
	void Update(GameObject obj, float deltaTime) override;
	void Draw(GameObject obj) override;
	void SetVelocity(Vector2 velocity) { velocity = velocity; }
	Vector2 GetVelocity() { return velocity; }
	void AddForce(Vector2 force) { force = Vector2Add(force, force); }
	Vector2 velocity = { 0, 0 };
	Vector2 force = { 0, 0 };
	float maxVelocity;
};

