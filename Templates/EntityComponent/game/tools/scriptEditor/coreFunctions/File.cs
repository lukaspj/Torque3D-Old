//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

/*
Description: Read the entire contents of file %fileName and return as a string.
WARNING: Will crash engine for files containing more than about 4K characters.
*/
function readFile( %fileName )
{
	%file = new FileObject();
	if(%file.openForRead(%fileName))
	{
		while(!%file.isEOF())
		{
			%input = %file.readLine();
			%fileContents = ("" $= %fileContents) ? %input : %fileContents NL %input;
		}
	} else {
		%file.delete();
		return false;
	}
	%file.close();
	%file.delete();
	return %fileContents;
}

/*
Description: Write the contents of %string into %fileName.
*/
function writeFile( %fileName , %data ) 
{
	%file = new FileObject();
	if(! %file.openforWrite( %fileName ) )
	{
		%file.delete();
		return false;
	}
	%file.writeLine( %data );
	%file.close();
	%file.delete();
	return true;
}

/*
Description: Append the contents of %string to %fileName.
*/
function appendToFile( %fileName , %data ) 
{
	%file = new FileObject();
	if(! %file.openforAppend( %fileName ) )
	{
		%file.delete();
		return false;
	}
	%file.writeLine( %data );
	%file.close();
	%file.delete();
	return true;
}


/*
Description: Return space-separated list of paths to all files matching %pattern.
*/
function getFileList( %pattern ) {
   %fileName = findFirstFile( %pattern );
   
   %fileList =  %fileName;

   while("" !$= %fileName ) 
   {
      %fileName = findNextFile(%pattern );
    
      %fileList = %fileList SPC %fileName;
   }
   return %fileList;
}


/*
Description: Search contents of file %fileName for %string and return true if found, false otherwise.
*/
function findStringInFile( %fileName , %string )
{
	%file = new FileObject();
	if(%file.openForRead(%fileName))
	{
		while(!%file.isEOF())
		{
			%input = %file.readLine();
			//echo(%input);
			%position = strstr( %input, %string );
			if( -1 != %position )
			{
   	   	%file.close();
	         %file.delete();
	         return true;
			}
		}
	} else {
		%file.delete();
		return false;
	}
	%file.close();
	%file.delete();
	return false;
}

/*
Description: Return all content in file %fileName between delimiters %startKey and %endKey.
If not found, %startKey defaults to begining of file and %endKey defaults to end of file.
*/
function extractFileSegment( %fileName, %startKey, %endKey  )
{
   %startgrab = (%startKey $= "") ? true : false;
   %endgrab   = false;
   
	%file = new FileObject();
	if(%file.openForRead(%fileName))
	{
		while(!%file.isEOF())
		{
			%input = %file.readLine();

         if( (%endKey !$= "") && strContains( %input, %endKey ) ) 
            %endgrab = true;

			if(%startGrab && !%endgrab)
			   %fileContents = ("" $= %fileContents) ? %input : %fileContents NL %input;
			   
         if( (!%startgrab) && strContains( %input, %startKey ) ) 
            %startgrab = true;

		}
	} else {
		%file.delete();
		return "";
	}
	%file.close();
	%file.delete();
	return %fileContents;
}


/*
Description: Return newline-separated list all lines in file containing %searchKey.
WARNING: Will crash engine for cumulative lines greater than about 4K characters.
*/
function extractFileLinesContaining( %fileName, %searchKey  )
{
	%file = new FileObject();
	if(%file.openForRead(%fileName))
	{
		while(!%file.isEOF())
		{
			%input = %file.readLine();

         if( strContains( %input, %searchKey ) ) 
         {
            %fileContents = %fileContents NL %input;
         }
		}
	} else {
		%file.delete();
		return "";
	}
	%file.close();
	%file.delete();
	return %fileContents;
}


////
//   Following routines are designed to operate on a previously opened file, line by line
//   These are similar to the above routines, but used for extracting (inserting) large amounts of data.
//   i.e. This overcomes Torque's ~4K string length limit (Torque crashes when you pass large strings).
////

/*
Description: Open a file for reading and return the handle to that file (or 0 for failure)
*/
function openFileForRead( %fileName )
{
	%fileObject = new FileObject();
	if(%fileObject.openForRead(%fileName))
	{
	   return %fileObject;
	}

	%fileObject.delete();
	return 0;
}

/*
Description: Close file specified by %handle.
*/
function closeFileHandle( %handle ) 
{	
   %handle.close();
	%handle.delete();
}

/*
Description: Search previously opened file specified by %handle and return all contents delimiters %startKey and %endKey.
If not found, %startKey defaults to begining of file and %endKey defaults to end of file.
WARNING: Will still crash engine for cumulative segments greater than about 4K characters.
*/
function getNextFileLineInSegment( %handle, %startKey, %endKey  )
{
   if(!isObject(%handle)) return "";
   
   if( !%handle.grabbingSegment )
   {
      %handle.startgrab       = (%startKey $= "") ? true : false;
      %handle.endgrab         = false;
      %handle.grabbingSegment = true;
   }   
	
   while(!%handle.isEOF())
	{
		%input = %handle.readLine();

      if( (%endKey !$= "") && strContains( %input, %endKey ) )
      { 
         %handle.endgrab = true;
         %handle.grabbingSegment = false;
         return "";
      }

	   if(%handle.startgrab && !%handle.endgrab)
	   {
	      return %input;
	   }
   
      if( (!%handle.startgrab) && strContains( %input, %startKey ) ) 
          %handle.startgrab = true;
   }

	return "";
}


/*
Description: Search previously opened file specified by %handle and return next line containing %searchKey string.
*/
function getNextFileLineContaining( %handle, %searchKey  )
{
   if(!isObject(%handle)) return "";   
   
   while(!%handle.isEOF())
	{
		%input = %handle.readLine();

      if( strContains( %input, %searchKey ) ) 
      {
         return %input;
      }
   }
	
	return "";
}
