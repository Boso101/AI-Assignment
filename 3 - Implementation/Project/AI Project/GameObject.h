#pragma once

#include <raymath.h>
#include <iostream>
#include <vector>
#include <map>

class Component;

// ComponentPtris a smart-pointer wrapping shared Components
class GameObject
{
	typedef std::shared_ptr<Component> ComponentPtr;


public:

	//Movement stuff
	//TODO: Move it into its own class
	Vector2 position = { 0, 0 };
	


	// Movement functions
	void SetPosition(Vector2 position) { position = position; }
	Vector2 GetPosition() { return position; }



	// Update the GameObject and its behaviours
	virtual void Update(float deltaTime);

	// Draw the GameObject
	virtual void Draw();


	
	

	void AddComponent(std::string componentName, const ComponentPtr& component);
	void UpdateComponents(float deltaTime);
	void DrawComponents();
	
	ComponentPtr GetComponent(std::string name);

protected:

	std::map<std::string, ComponentPtr> components;



};