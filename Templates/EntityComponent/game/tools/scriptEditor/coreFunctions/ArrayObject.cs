//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

////
//// Create a scriptObject named 'arrayObject' and use these methods 
//// to maintain a easily sortable array
////

/*
Description: Create new array object with optionally specified %name.
*/
function createArrayObject( %name )
{
   %obj = new ScriptObject( %name )
   {
      superClass = "arrayObject";
   };
   
   return %obj;
}

/*
Description: Internal only.  Callback that initializes all array objects.
*/
function arrayObject::onAdd( %this )
{
	%this.curIndex=0;
}

/*
Description: Add new %entry to this array object.
*/
function arrayObject::addEntry( %this , %entry )
{
	%this.entry[%this.curIndex] = %entry;
	%this.curIndex++;
	return %entry;
}

/*
Description: Get number of entries in array object.
*/
function arrayObject::getCount( %this )
{
	return %this.curIndex;
}

/*
Description: Sort the entries in array object.  By default this sort is in increasing order, but by specifying true in the %Decreasing (second) argument, the direction can be changed.
*/
function arrayObject::sort( %this  , %Decreasing )
{
	if(!%this.curIndex) return;

	new GuiTextListCtrl(sortProxy);

	for(%count=0; %count < %this.curIndex; %count++)
	{
		sortProxy.addRow( %count , %this.entry[%count] );
	}

	%sortOrder = !(%Decreasing);

	sortProxy.sort( 0 , %sortOrder );

	for(%count=0; %count < %this.curIndex; %count++)
	{
		%this.entry[%count] = sortProxy.getRowText(%count);
	}

	sortProxy.delete();

}

/*
Description: Return entry in array object at specified %index.
*/
function arrayObject::getEntry( %this ,  %index )
{
	if( %index >= %this.curIndex) return "";
	return %this.entry[%index];
}

