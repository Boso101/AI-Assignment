#include "GameObject.h"
#include <typeindex>
#include <iterator>

void GameObject::UpdateComponents(float deltaTime)
{
	// Get an iterator pointing to begining of map
	std::unordered_map<std::string, ComponentPtr>::iterator it = components.begin();
	// Iterate over the map using iterator
	while (it != components.end())
	{
		it->second->Update(*this, deltaTime);
		it++;
	}
}

void GameObject::DrawComponents()
{
	// Get an iterator pointing to begining of map
	std::unordered_map<std::string, ComponentPtr>::iterator it = components.begin();
	// Iterate over the map using iterator
	while (it != components.end())
	{
		it->second->Draw(*this);
		it++;
	}
}

ComponentPtr GameObject::GetComponent(std::string name)
{
	return components[name];
}

void GameObject::AddComponent(std::string componentName, ComponentPtr component)
{
	 components[componentName] = component;
}



void GameObject::Update(float deltaTime)
{
	UpdateComponents(deltaTime);
}

void GameObject::Draw()
{
	DrawComponents();
}

