#pragma once
#include <raymath.h>
#include "Component.h"
class Movement : Component
{
public:
	void SetVelocity(Vector2 velocity) { velocity = velocity; }
	Vector2 GetVelocity() { return velocity; }
	void AddForce(Vector2 force) { force = Vector2Add(force, force); }
	Vector2 velocity = { 0, 0 };
	Vector2 force = { 0, 0 };
	float maxVelocity;
};

