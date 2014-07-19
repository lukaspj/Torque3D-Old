#include "T3D/tagLibrary.h"

namespace TagManager
{
	TagLibrary *gTagLibrary;

	void initTagLibrary()
	{
		gTagLibrary = new TagLibrary;
	}
}

IMPLEMENT_CONOBJECT(TagLibrary);

void TagLibrary::addEntity(Entity* newEntity)
{
	mTaggedEntities.pushObject(newEntity);
}

void TagLibrary::addTag(const char* tagName)
{

}