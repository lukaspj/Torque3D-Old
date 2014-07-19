//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

// Some utilties for modifying strings of records
/*
Description: Locate records %first and %second and swap their position in %records.
*/
function swapRecords( %records, %first, %second )
{
	%numRecords = getRecordCount(%records);

	if( ! ( ( 0 == %numRecords) ||
		(%first < 0) ||
		(%first >= %numRecords)  ||
		(%second < 0)  ||
		(%second >= %numRecords) ||
		( %first == %second) ) )
	{
		%tmp = getRecord( %records , %first );
		%records = setRecord( %records , %first , getRecord( %records , %second ) );
		%records = setRecord( %records , %second , %tmp );

	}

	return %records;
}

/*
Description: Randomize the locations of records with the record list %records.  (Optionally specify the number of %iterations to use while sorting.)
*/
function randomizeRecords( %records , %iterations )
{
   if(%iterations $= "") %iterations = 1;
	%numRecords = getRecordCount(%records);
	if( 0 == %numRecords) return "";
	for( %count = 0; %count < %iterations * %numRecords ; %count++) {
		%first  = getRandom( 0 , %numRecords - 1 );
		%second = getRandom( 0 , %numRecords - 1 );
		%records = swapRecords( %records, %first, %second );
	}
	return %records;
}

/*
Description:  Sort list of %records (optionally sort in descending order).
*/
function sortRecords( %records , %descending )
{
   %tmpArray = new scriptObject( arrayObject );
   
   %records = strreplace( %records , "\t", "\n" );
      
   %tmpTokens = %records;
   
   while( "" !$= %tmpTokens ) 
   {
      %tmpTokens = nextToken( %tmpTokens , "theToken" , "\n" );
      %tmpArray.addEntry( %theToken );      
   }
   
   %tmpArray.sort( %descending );
   
   %entries = %tmpArray.getCount();
   
   for( %count = 0; %count < %entries; %count++ )
   {
      %newRecords = %newRecords NL %tmpArray.getEntry( %count );
   }
   
   %newRecords = trim( %newRecords );
   
   %tmpArray.delete();
   
   return %newRecords;
}

/*
Description: Return true if %newRecord does not exist in the list of %records.
*/
function isUniqueRecord( %records , %newRecord )
{
   //
   // Find and replace the old name
   //
   %tmpRecords = strreplace( %records , "\t", "\n" );
   
   %isUnique = true;  

   while( "" !$= %tmpRecords ) 
   {
      %tmpRecords = nextToken( %tmpRecords , "theToken" , "\n" );
      
      if (%theToken $= %newRecord) %isUnique = false;
   }
   
   return( %isUnique );
}

/*
Description: Add %newRecord to list %records if %newRecord does not already exist in list.
*/
function addUniqueRecord( %records , %newRecord )
{
   //
   // Find and replace the old name
   //
   %tmpRecords = strreplace( %records , "\t", "\n" );
   
   %isUnique = true;  

   while( "" !$= %tmpRecords ) 
   {
      %tmpRecords = nextToken( %tmpRecords , "theToken" , "\n" );
      
      if (%theToken $= %newRecord) %isUnique = false;
   }
   
   if( !%isUnique ) return %records;
   
   %newRecords = %records NL %newRecord;
   
   %newRecords = trim ( %newRecords );
   
   return %newRecords;
}

/*
Description: Find %oldRecord in list %records and replace it with %newRecord.
*/
function replaceRecord( %records , %oldRecord, %newRecord )
{
   //
   // Find and replace the old name
   //
   %tmpRecords = strreplace( %records , "\t", "\n" );

   while( "" !$= %tmpRecords ) 
   {
      %tmpRecords = nextToken( %tmpRecords , "theToken" , "\n" );
      
      %record = (%theToken $= %oldRecord) ? %newRecord : %theToken;
      
      %newRecords = %newRecords NL %record;
   }
   
   %newRecords = trim ( %newRecords );
   
   return %newRecords;
}

/*
Description: Add %newRecord to (end of) list %records.
*/
function addRecord( %records, %newRecord ) 
{
   return( trim(%records NL %newRecord) );   
}

/*
Description: Locate all instances of %oldRecord from list %records.  Optionally specify that only the first instance (starting at position 0) of %oldRecord be removed.
*/
function removeNamedRecord( %records , %oldRecord , %firstOnly )
{
   //
   // Find and replace the old name
   //
   %tmpRecords = strreplace( %records , "\t", "\n" );

   while( "" !$= %tmpRecords ) 
   {
      %tmpRecords = nextToken( %tmpRecords , "theToken" , "\n" );
      
      if ( ( %theToken $= %oldRecord ) && !(%firstOnly && %removed) )
      {
         // Nothing
         %removed = true;
      }
      else
      {
         %newRecords = %newRecords NL %theToken;
      }

   }
   
   %newRecords = trim ( %newRecords );
   
   return %newRecords;
}

/*
Description: Add %newRecord to list %records, in position 0.
*/
function pushRecordFront( %records , %newRecord )
{
   %records = ("" $= %records) ?  %newRecord : %newRecord NL %records;
   return %records;
}

/*
Description: Add %newRecord to list %records, in position 'recordCount'.
*/
function pushRecordBack( %records , %newRecord )
{
   %records = ("" $= %records) ?  %newRecord : %records NL %newRecord;
   return %records;
}

/*
Description: Remove record 0 from list %records and return the resultant list.
*/
function popRecordFront( %records )
{
   %recordCount = getRecordCount( %records );

   switch( %recordCount )
   {
   case 0: return "";
   case 1: return "";
   default:
      %records = getRecords( %records , 1 );
      return ( trim( %records ) );
   }
}

/*
Description: Remove record 'recordcount-1' from list %records and return the resultant list.
*/
function popRecordBack( %records )
{
   %recordCount = getRecordCount( %records );

   switch( %recordCount )
   {
   case 0: return "";
   case 1: return "";
   default:
      %records = getRecords( %records , 0 , %recordCount-2 );
      return ( trim( %records ) );
   }
}
