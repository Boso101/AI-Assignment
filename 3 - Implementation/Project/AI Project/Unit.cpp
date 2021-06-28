#include "Unit.h"
#include "Sprite.h"
#include "Agent.h"
#include "Movement.h"

Unit::Unit()
{
	// First add Sprite
	AddComponent("Sprite", std::make_shared<Sprite>());
	// Then Movement so that our agent can find it 
	AddComponent("Movement", std::make_shared<Movement>());
	AddComponent("Agent", std::make_shared<Agent>()); // Finally agent


}
