//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

// Some utilties for modifying strings of fields
/*
Description: Locate fields %first and %second and swap their position in %fields.
*/
function swapFields( %fields, %first, %second )
{
	%numFields = getFieldCount(%fields);

	if( ! ( ( 0 == %numFields) ||
		(%first < 0) ||
		(%first >= %numFields)  ||
		(%second < 0)  ||
		(%second >= %numFields) ||
		( %first == %second) ) )
	{
		%tmp = getField( %fields , %first );
		%fields = setField( %fields , %first , getField( %fields , %second ) );
		%fields = setField( %fields , %second , %tmp );

	}

	return %fields;
}

/*
Description: Randomize the locations of fields with the field list %fields.  (Optionally specify the number of %iterations to use while sorting.)
*/
function randomizeFields( %fields , %iterations )
{
   if(%iterations $= "") %iterations = 1;
	%numFields = getFieldCount(%fields);
	if( 0 == %numFields) return "";
	for( %count = 0; %count < %iterations * %numFields ; %count++) {
		%first  = getRandom( 0 , %numFields - 1 );
		%second = getRandom( 0 , %numFields - 1 );
		%fields = swapFields( %fields, %first, %second );
	}
	return %fields;
}

/*
Description:  Sort list of %fields (optionally sort in descending order).
*/
function sortFields( %fields , %descending )
{
   %tmpArray = new scriptObject( arrayObject );
      
   %tmpTokens = %fields;
   
   while( "" !$= %tmpTokens ) 
   {
      %tmpTokens = nextToken( %tmpTokens , "theToken" , "\t" );
      %tmpArray.addEntry( %theToken );      
   }
   
   %tmpArray.sort( %descending );
   
   %entries = %tmpArray.getCount();
   
   for( %count = 0; %count < %entries; %count++ )
   {
      %newFields = %newFields TAB %tmpArray.getEntry( %count );
   }
   
   %newFields = trim( %newFields );
   
   %tmpArray.delete();
   
   return %newFields;
}

/*
Description: Return true if %newField does not exist in the list of %fields.
*/
function isUniqueField( %fields , %newField )
{
   //
   // Find and replace the old name
   //
   %tmpFields = %fields; 
   
   %isUnique = true;  

   while( "" !$= %tmpFields ) 
   {
      %tmpFields = nextToken( %tmpFields , "theToken" , "\t" );
      
      if (%theToken $= %newField) %isUnique = false;
   }
   
   return( %isUnique );
}

/*
Description: Add %newField to list %fields if %newField does not already exist in list.
*/
function addUniqueField( %fields , %newField )
{
   //
   // Find and replace the old name
   //
   %tmpFields = %fields; 
   
   %isUnique = true;  

   while( "" !$= %tmpFields ) 
   {
      %tmpFields = nextToken( %tmpFields , "theToken" , "\t" );
      
      if (%theToken $= %newField) %isUnique = false;
   }
   
   if( !%isUnique ) return %fields;
   
   %newFields = %fields TAB %newField;
   
   %newFields = trim ( %newFields );
   
   return %newFields;
}

/*
Description: Find %oldField in list %fields and replace it with %newField.
*/
function replaceField( %fields , %oldField, %newField )
{
   //
   // Find and replace the old name
   //
   %tmpFields = %fields;   

   while( "" !$= %tmpFields ) 
   {
      %tmpFields = nextToken( %tmpFields , "theToken" , "\t" );
      
      %field = (%theToken $= %oldField) ? %newField : %theToken;
      
      %newFields = %newFields TAB %field;
   }
   
   %newFields = trim ( %newFields );
   
   return %newFields;
}

/*
Description: Add %newField to (end of) list %fields.
*/
function addField( %fields, %newField ) 
{
   return( trim(%fields TAB %newField) );   
}

/*
Description: Locate all instances of %oldField from list %fields.  Optionally specify that only the first instance (starting at position 0) of %oldField be removed.
*/
function removeNamedField( %fields , %oldField , %firstOnly )
{
   //
   // Find and replace the old name
   //
   %tmpFields = %fields;   

   while( "" !$= %tmpFields ) 
   {
      %tmpFields = nextToken( %tmpFields , "theToken" , "\t" );
      
      if ( ( %theToken $= %oldField ) && !(%firstOnly && %removed) )
      {
         // Nothing
         %removed = true;
      }
      else
      {
         %newFields = %newFields TAB %theToken;
      }

   }
   
   %newFields = trim ( %newFields );
   
   return %newFields;
}

/*
Description: Add %newField to list %fields, in position 0.
*/
function pushFieldFront( %fields , %newField )
{
   %fields = ("" $= %fields) ?  %newField : %newField TAB %fields;
   return %fields;
}

/*
Description: Add %newField to list %fields, in position 'fieldCount'.
*/
function pushFieldBack( %fields , %newField )
{
   %fields = ("" $= %fields) ?  %newField : %fields TAB %newField;
   return %fields;
}

/*
Description: Remove field 0 from list %fields and return the resultant list.
*/
function popFieldFront( %fields )
{
   %fieldCount = getFieldCount( %fields );

   switch( %fieldCount )
   {
   case 0: return "";
   case 1: return "";
   default:
      %fields = getFields( %fields , 1 );
      return ( trim( %fields ) );
   }
}

/*
Description: Remove field 'fieldcount-1' from list %fields and return the resultant list.
*/
function popFieldBack( %fields )
{
   %fieldCount = getFieldCount( %fields );

   switch( %fieldCount )
   {
   case 0: return "";
   case 1: return "";
   default:
      %fields = getFields( %fields , 0 , %fieldCount-2 );
      return ( trim( %fields ) );
   }
}
