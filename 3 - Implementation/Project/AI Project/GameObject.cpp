#include "GameObject.h"
#include "Component.h"

#include <typeindex>
#include <iterator>

void GameObject::UpdateComponents(float deltaTime)
{
	// Get an iterator pointing to begining of map
	std::map<std::string, ComponentPtr>::iterator it = components.begin();
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
	std::map<std::string, ComponentPtr>::iterator it = components.begin();
	// Iterate over the map using iterator
	while (it != components.end())
	{
		it->second->Draw(*this);
		it++;
	}
}

GameObject::ComponentPtr GameObject::GetComponent(std::string name)
{
	return components[name];
}

void GameObject::AddComponent(std::string componentName, const ComponentPtr& component)
{
	components.insert(std::make_pair(componentName, component));
}



void GameObject::Update(float deltaTime)
{
	UpdateComponents(deltaTime);
}

void GameObject::Draw()
{
	DrawComponents();
}

