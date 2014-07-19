//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

/*
Description: Return true if %string contains %subStr.  (Case insensitve).
*/
function strContains( %string, %subStr )
{
   %pos = strstr( strlwr(%string) , strlwr(%subStr) );
   return ( -1 != %pos );
}

/*
Description: Remove all letters from %string and return the resulting string.
*/
function removeAlpha( %string )
{
   %string = strlwr( %string );
   %string = strreplace( %string, "a", "" );
   %string = strreplace( %string, "b", "" );
   %string = strreplace( %string, "c", "" );
   %string = strreplace( %string, "d", "" );
   %string = strreplace( %string, "e", "" );
   %string = strreplace( %string, "f", "" );
   %string = strreplace( %string, "g", "" );
   %string = strreplace( %string, "h", "" );
   %string = strreplace( %string, "i", "" );
   %string = strreplace( %string, "j", "" );
   %string = strreplace( %string, "k", "" );
   %string = strreplace( %string, "l", "" );
   %string = strreplace( %string, "m", "" );
   %string = strreplace( %string, "n", "" );
   %string = strreplace( %string, "o", "" );
   %string = strreplace( %string, "p", "" );
   %string = strreplace( %string, "q", "" );
   %string = strreplace( %string, "r", "" );
   %string = strreplace( %string, "s", "" );
   %string = strreplace( %string, "t", "" );
   %string = strreplace( %string, "u", "" );
   %string = strreplace( %string, "v", "" );
   %string = strreplace( %string, "w", "" );
   %string = strreplace( %string, "x", "" );
   %string = strreplace( %string, "y", "" );
   %string = strreplace( %string, "z", "" );
   return ( %string );
}

/*
Description: Remove all numbers from %string and return the resulting string.
*/
function removeNumeric( %string )
{
   %string = strlwr( %string );
   %string = strreplace( %string, "0", "" );
   %string = strreplace( %string, "1", "" );
   %string = strreplace( %string, "2", "" );
   %string = strreplace( %string, "3", "" );
   %string = strreplace( %string, "4", "" );
   %string = strreplace( %string, "5", "" );
   %string = strreplace( %string, "6", "" );
   %string = strreplace( %string, "7", "" );
   %string = strreplace( %string, "8", "" );
   %string = strreplace( %string, "9", "" );
   return ( %string );
}

/*
Description: Remove all white space (spaces, tabs, and newlines) from %string and return the resulting string.
*/
function removeWhiteSpace( %string )
{
   %string = strreplace(%string, " ", "");
   %string = strreplace(%string, "\t", "");
   %string = strreplace(%string, "\n", "");
   return %string;
}


/*
Description: Search %string for a substring delimited by %startMarker and %endMarker.  
Does not return markers as part of result.  
If %startMarker is found, but %endMarker is not found, returns all data after %startMarker.
If %startMarker is no found, but %endMarker is found , returns all data from beginning of string to character before %endMarker.
*/
function getSubStrMarker( %string, %startMarker, %endMarker )
{
   
   // Calculate start position
   if (%startMarker $= "") 
      %startPos = 0;
   else
   {
      %startPos = strpos( %string, %startMarker );
      
      if( %startPos == -1 ) 
         %startPos = 0;
      else
         %startPos += strlen( %startMarker );
   }
   
   // Calculate count from start
   if (%endMarker $= "") 
      %count = strlen( %string ) - %startPos;
   else
   {
      %endPos = strpos( %string, %endMarker );
      
      if( %endPos == -1 ) 
         %count = strlen( %string ) - %startPos;
      else
         %count = %endPos - %startPos;
   }
   
   return getSubStr( %string, %startPos, %count );
}

function isCharScriptTerminator(%nextChar)
{
   if(%nextChar $= "]" || %nextChar $= ";" || %nextChar $= "(" || %nextChar $= ")" || 
      %nextChar $= "-" || %nextChar $= "*" || %nextChar $= "/" || %nextChar $= "+" || 
      %nextChar $= "%" || %nextChar $= "&" || %nextChar $= "@" || %nextChar $= "$" || 
      %nextChar $= " " || %nextChar $= "," || %nextChar $= "=" || %nextChar $= "!" || 
      %nextChar $= "^" || %nextChar $= "'" || %nextChar $= "|" || %nextChar $= "{" || 
      %nextChar $= "}" || %nextChar $= "\\" || %nextChar $= "\t" || %nextChar $= "\n" ||
      %nextChar $= ".")
      return true;
   else
      return false;
}

function isCharScriptOperator(%nextChar)
{
   if(%nextChar $= "!" || %nextChar $= "=" || %nextChar $= "$" || %nextChar $= "+" || 
      %nextChar $= "-" || %nextChar $= "*" || %nextChar $= "/" || %nextChar $= "@" || 
      %nextChar $= "%" || %nextChar $= "&" || %nextChar $= "|")
      return true;
   else
      return false;
}