//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

// Some utilties for modifying strings of words
/*
Description: Locate words %first and %second and swap their position in %words.
*/
function swapWords( %words, %first, %second )
{
	%numWords = getWordCount(%words);

	if( ! ( ( 0 == %numWords) ||
		(%first < 0) ||
		(%first >= %numWords)  ||
		(%second < 0)  ||
		(%second >= %numWords) ||
		( %first == %second) ) )
	{
		%tmp = getWord( %words , %first );
		%words = setWord( %words , %first , getWord( %words , %second ) );
		%words = setWord( %words , %second , %tmp );

	}

	return %words;
}

/*
Description: Randomize the locations of words with the word list %words.  (Optionally specify the number of %iterations to use while sorting.)
*/
function randomizeWords( %words , %iterations )
{
   if(%iterations $= "") %iterations = 1;
	%numWords = getWordCount(%words);
	if( 0 == %numWords) return "";
	for( %count = 0; %count < %iterations * %numWords ; %count++) {
		%first  = getRandom( 0 , %numWords - 1 );
		%second = getRandom( 0 , %numWords - 1 );
		%words = swapWords( %words, %first, %second );
	}
	return %words;
}

/*
Description:  Sort list of %words (optionally sort in descending order).
*/
function sortWords( %words , %descending )
{
   %tmpArray = new scriptObject( arrayObject );
      
   %tmpTokens = %words;
   
   while( "" !$= %tmpTokens ) 
   {
      %tmpTokens = nextToken( %tmpTokens , "theToken" , " " );
      %tmpArray.addEntry( %theToken );      
   }
   
   %tmpArray.sort( %descending );
   
   %entries = %tmpArray.getCount();
   
   for( %count = 0; %count < %entries; %count++ )
   {
      %newWords = %newWords SPC %tmpArray.getEntry( %count );
   }
   
   %newWords = trim( %newWords );
   
   %tmpArray.delete();
   
   return %newWords;
}

/*
Description: Return true if %newWord does not exist in the list of %words.
*/
function isUniqueWord( %words , %newWord )
{
   //
   // Find and replace the old name
   //
   %tmpWords = %words; 
   
   %isUnique = true;  

   while( "" !$= %tmpWords ) 
   {
      %tmpWords = nextToken( %tmpWords , "theToken" , " " );
      
      if (%theToken $= %newWord) %isUnique = false;
   }
   
   return( %isUnique );
}

/*
Description: Add %newWord to list %words if %newWord does not already exist in list.
*/
function addUniqueWord( %words , %newWord )
{
   //
   // Find and replace the old name
   //
   %tmpWords = %words; 
   
   %isUnique = true;  

   while( "" !$= %tmpWords ) 
   {
      %tmpWords = nextToken( %tmpWords , "theToken" , " " );
      
      if (%theToken $= %newWord) %isUnique = false;
   }
   
   if( !%isUnique ) return %words;
   
   %newWords = %words SPC %newWord;
   
   %newWords = trim ( %newWords );
   
   return %newWords;
}

/*
Description: Find %oldWord in list %words and replace it with %newWord.
*/
function replaceWord( %words , %oldWord, %newWord )
{
   //
   // Find and replace the old name
   //
   %tmpWords = %words;   

   while( "" !$= %tmpWords ) 
   {
      %tmpWords = nextToken( %tmpWords , "theToken" , " " );
      
      %word = (%theToken $= %oldWord) ? %newWord : %theToken;
      
      %newWords = %newWords SPC %word;
   }
   
   %newWords = trim ( %newWords );
   
   return %newWords;
}

/*
Description: Add %newWord to (end of) list %words.
*/
function addWord( %words, %newWord ) 
{
   return( trim(%words SPC %newWord) );   
}

/*
Description: Locate all instances of %oldWord from list %words.  Optionally specify that only the first instance (starting at position 0) of %oldWord be removed.
*/
function removeNamedWord( %words , %oldWord , %firstOnly )
{
   //
   // Find and replace the old name
   //
   %tmpWords = %words;   

   while( "" !$= %tmpWords ) 
   {
      %tmpWords = nextToken( %tmpWords , "theToken" , " " );
      
      if ( ( %theToken $= %oldWord ) && !(%firstOnly && %removed) )
      {
         // Nothing
         %removed = true;
      }
      else
      {
         %newWords = %newWords SPC %theToken;
      }

   }
   
   %newWords = trim ( %newWords );
   
   return %newWords;
}

/*
Description: Add %newWord to list %words, in position 0.
*/
function pushWordFront( %words , %newWord )
{
   %words = ("" $= %words) ?  %newWord : %newWord SPC %words;
   return %words;
}

/*
Description: Add %newWord to list %words, in position 'wordCount'.
*/
function pushWordBack( %words , %newWord )
{
   %words = ("" $= %words) ?  %newWord : %words SPC %newWord;
   return %words;
}

/*
Description: Remove word 0 from list %words and return the resultant list.
*/
function popWordFront( %words )
{
   %wordCount = getWordCount( %words );

   switch( %wordCount )
   {
   case 0: return "";
   case 1: return "";
   default:
      %words = getWords( %words , 1 );
      return ( trim( %words ) );
   }
}

/*
Description: Remove word 'wordcount-1' from list %words and return the resultant list.
*/
function popWordBack( %words )
{
   %wordCount = getWordCount( %words );

   switch( %wordCount )
   {
   case 0: return "";
   case 1: return "";
   default:
      %words = getWords( %words , 0 , %wordCount-2 );
      return ( trim( %words ) );
   }
}
