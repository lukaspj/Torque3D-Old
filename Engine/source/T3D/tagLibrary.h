#ifndef _TAG_LIBRARY_H_
#define _TAG_LIBRARY_H_

#ifndef _CONSOLEINTERNAL_H_
#include "console/consoleInternal.h"
#endif
#ifndef _SIMOBJECT_H_
#include "console/simObject.h"
#endif

#ifndef _ENTITY_H_
#include "T3D/entity.h"
#endif

class TagLibrary : public SimObject
{
	typedef SimObject Parent;

	Vector<StringTableEntry> mTags;

	//Note, this should only really ever be used in the case where we're searching for entities with a given tag, or if we have to update our tag IDs. 
	SimSet mTaggedEntities;

public:
	S32 buildTextField(String fieldText, RectI bounds);

	void addTag(const char* tagName);
	void removeTag(const char* tagName){}

	S32 findTag(const char* tagName){}
	StringTableEntry findTag(S32 index){}

	void addEntity(Entity* newEntity);

	DECLARE_CONOBJECT( TagLibrary );
    DECLARE_DESCRIPTION( "A class that builds editor fields and returns the container control for use." );
};



#endif