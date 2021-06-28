#include "Unit.h"
#include "Sprite.h"
#include "Agent.h"

Unit::Unit()
{
	AddComponent("Sprite", std::make_shared<Sprite>());
	AddComponent("Agent", std::make_shared<Agent>());


}
