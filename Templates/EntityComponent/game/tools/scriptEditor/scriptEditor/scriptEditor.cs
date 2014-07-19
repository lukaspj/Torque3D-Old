//------------------------------------------------------------
// Initialazion
//------------------------------------------------------------
$ScriptEditorPrefs::ReservedWords = "continue for if else where new %this false true function return break while do";

function EWBrowserWindow::init( %this )
{
   EWBrowserWindow.setListView( false );
   EWBrowserWindow.tab = "Scripts";      
   EWBrowserWindow.navigate( "" );
   
   if( !ScriptEditorTree.getItemCount() )
      %this.populateTrees();
}

//------------------------------------------------------------
// Icons
//------------------------------------------------------------

function EWBrowserWindow::setListView( %this, %noupdate )
{
   //ScriptIconArray.clear();
   //ScriptIconArray.setVisible( false );
   
   ScriptIconArray.setVisible( true );
   %this.contentCtrl = ScriptIconArray;   
   %this.isList = true;
   
   if ( %noupdate == true )
      %this.navigate( %this.address );
}

function EWBrowserWindow::addScriptIcon( %this, %fullPath )
{
   %ctrl = %this.createIcon();
   
   %ext = fileExt( %fullPath );
   %file = fileBase( %fullPath );
   %fileLong = %file @ %ext;
   %tip = %fileLong NL
          "Size: " @ fileSize( %fullPath ) / 1000.0 SPC "KB" NL
          "Date Created: " @ fileCreatedTime( %fullPath ) NL
          "Last Modified: " @ fileModifiedTime( %fullPath );

   %ctrl.altCommand = "EWBrowserWindow.openScript( \"" @ %fullPath @ "\" );";  

   %ctrl.iconBitmap = EditorIconRegistry::findIconByClassName( "SimDataBlock" );
   %ctrl.text = %file;
   %ctrl.class = "CreatorStaticIconBtn";
   %ctrl.tooltip = %tip;
   
   %ctrl.buttonType = "radioButton";
   %ctrl.groupNum = "-1";   
   
   %this.contentCtrl.addGuiControl( %ctrl );   
}

function EWBrowserWindow::addFolderIcon( %this, %text )
{
   %ctrl = %this.createIcon();
      
   %ctrl.altCommand = "EWBrowserWindow.navigateDown(\"" @ %text @ "\");";
   %ctrl.iconBitmap = "core/art/gui/images/folder.png";   
   %ctrl.text = %text;
   %ctrl.tooltip = %text;     
   %ctrl.class = "CreatorFolderIconBtn";
   
   %ctrl.buttonType = "radioButton";
   %ctrl.groupNum = "-1";   
   
   %this.contentCtrl.addGuiControl( %ctrl );   
}

function EWBrowserWindow::createIcon( %this )
{
   %ctrl = new GuiIconButtonCtrl()
   {            
      profile = "GuiCreatorIconButtonProfile";     
      buttonType = "radioButton";
      groupNum = "-1";    
   };
      
   if ( %this.isList )
   {
      %ctrl.iconLocation = "Left";
      %ctrl.textLocation = "Right";
      %ctrl.extent = "348 19";
      %ctrl.textMargin = 8;
      %ctrl.buttonMargin = "2 2";
      %ctrl.autoSize = true;
   }
   else
   {
      %ctrl.iconLocation = "Center";         
      %ctrl.textLocation = "Bottom";
      %ctrl.extent = "40 40";    
   }
         
   return %ctrl;
}

function EWBrowserWindow::doesFolderExist( %this, %name )
{
   for ( %i = 0; %i < %this.contentCtrl.getCount(); %i++ )
   {
      %ctrl = %this.contentCtrl.getObject( %i );
      if ( %ctrl.text $= %name && %ctrl.iconBitmap $= "core/art/gui/images/folder.png")
         return %ctrl;
   }
   
   return -1;
}

function EWBrowserWindow::doesScriptExist( %this, %name )
{
   for ( %i = 0; %i < %this.contentCtrl.getCount(); %i++ )
   {
      %ctrl = %this.contentCtrl.getObject( %i );
      if ( %ctrl.text $= %name && %ctrl.iconBitmap $= EditorIconRegistry::findIconByClassName( "SimDataBlock" ))
         return %ctrl;
   }
   
   return -1;
}
 
function EWBrowserWindow::findIconCtrl( %this, %name )
{
   for ( %i = 0; %i < %this.contentCtrl.getCount(); %i++ )
   {
      %ctrl = %this.contentCtrl.getObject( %i );
      if ( %ctrl.text $= %name )
         return %ctrl;
   }
   
   return -1;
}

//------------------------------------------------------------
// Navigation
//------------------------------------------------------------

function ScriptPopupMenu::onSelect( %this, %id, %text )
{   
   %split = strreplace( %text, "/", " " );
   EWBrowserWindow.navigate( %split );  
}

function EWBrowserWindow::navigateDown( %this, %folder )
{
   if ( %this.address $= "" )
      %address = %folder;
   else   
      %address = %this.address SPC %folder;

   // Because this is called from an IconButton::onClick command
   // we have to wait a tick before actually calling navigate, else
   // we would delete the button out from under itself.
   %this.schedule( 1, "navigate", %address );
}

function EWBrowserWindow::navigateUp( %this )
{
   %count = getWordCount( %this.address );
   
   if ( %count == 0 )
      return;
      
   if ( %count == 1 )
      %address = "";
   else      
      %address = getWords( %this.address, 0, %count - 2 );
      
   %this.navigate( %address );
}

function EWBrowserWindow::navigate( %this, %address )
{
   ScriptIconArray.frozen = true;
   ScriptIconArray.clear();  
   CreatorPopupMenu.clear();
   
   if ( %this.tab $= "Scripts" )
   {  
      %filterstr = ScriptEditorGui.FileFilter;
      %filter = "";
      for(%i = 0; %i < getWordCount(%filterstr); %i++)
      {
         %addfilter = getWord( %filterstr, %i );
         if(%filter $= "")
            %filter = %addfilter;
         else
            %filter = %filter TAB %addfilter;
      }
      %fullPath = findFirstFileMultiExpr( %filter );//( "*.cs" TAB "*.gui" );
      
      while ( %fullPath !$= "" )
      {
         %fullPath = makeRelativePath( %fullPath, getMainDotCSDir() );                                  
         %splitPath = strreplace( %fullPath, "/", " " );     
         
         /*if( getWord(%splitPath, 0) $= "tools" )
         {
            %fullPath = findNextFileMultiExpr( %filter );
            continue;
         }*/
                      
         %dirCount = getWordCount( %splitPath ) - 1;
         
         %pathFolders = getWords( %splitPath, 0, %dirCount - 1 );         
         
         // Add this file's path (parent folders) to the
         // popup menu if it isn't there yet.
         %temp = strreplace( %pathFolders, " ", "/" );         
         %r = CreatorPopupMenu.findText( %temp );
         if ( %r == -1 )
         {
            CreatorPopupMenu.add( %temp );
         }
         
         // Is this file in the current folder?        
         if ( stricmp( %pathFolders, %address ) == 0 )
         {
            //if ( fileExt( %fullPath ) $= ".gui" )
               //%this.addGuiIcon( %fullPath );
            //else
               %this.addScriptIcon( %fullPath );
         }
         // Then is this file in a subfolder we need to add
         // a folder icon for?
         else
         {
            %wordIdx = 0;
            %add = false;
            
            if ( %address $= "" )
            {
               %add = true;
               %wordIdx = 0;
            }
            else
            {
               for ( ; %wordIdx < %dirCount; %wordIdx++ )
               {
                  %temp = getWords( %splitPath, 0, %wordIdx );
                  if ( stricmp( %temp, %address ) == 0 )
                  {                  
                     %add = true;
                     %wordIdx++;
                     break;  
                  }
               }
            }
            
            if ( %add == true )
            {               
               %folder = getWord( %splitPath, %wordIdx );
               
               %ctrl = %this.doesFolderExist( %folder );
               if ( %ctrl == -1)
                  %this.addFolderIcon( %folder );
            }
         }         

         %fullPath = findNextFileMultiExpr( %filter );
      }
   }
   
   ScriptIconArray.sort( "alphaIconCompare" );
   
   for ( %i = 0; %i < ScriptIconArray.getCount(); %i++ )
   {
      ScriptIconArray.getObject(%i).autoSize = false;         
   }
   
   ScriptIconArray.frozen = false;
   ScriptIconArray.refresh();
   
   // Recalculate the array for the parent guiScrollCtrl
   ScriptIconArray.getParent().computeSizes();  
   
   %this.address = %address;

   CreatorPopupMenu.sort();

   %str = strreplace( %address, " ", "/" );
   %r = CreatorPopupMenu.findText( %str );
   if ( %r != -1 )
      CreatorPopupMenu.setSelected( %r, false );
   else
      CreatorPopupMenu.setText( %str );
   CreatorPopupMenu.tooltip = %str;
}

function EWBrowserWindow::populateTrees(%this)
{
   // Populate datablock tree.
      
   if( %this.excludeClientOnlyDatablocks )
      %set = DataBlockGroup;
   else
      %set = DataBlockSet;

   ScriptEditorTree.clear();
   
   foreach( %datablock in %set )
   {
      %unlistedFound = false;
      %id = %datablock.getId();
      
      foreach( %obj in UnlistedScripts )
         if( %obj.getId() == %id )
         {
            %unlistedFound = true;
            break;
         }
   
      if( %unlistedFound )
         continue;
         
      %this.addExistingItem( %datablock, true );
   }
   
   ScriptEditorTree.sort( 0, true, false, false );
   
   // Populate datablock type tree.
   
   %classList = enumerateConsoleClasses( "SimDatablock" );
   ScriptEditorTypeTree.clear();
   
   foreach$( %datablockClass in %classList )
   {
      if(    !%this.isExcludedDatablockType( %datablockClass )
          && DatablockEditorTypeTree.findItemByName( %datablockClass ) == 0 )
         DatablockEditorTypeTree.insertItem( 0, %datablockClass );
   }
   
   ScriptEditorTypeTree.sort( 0, false, false, false );   
}
//------------------------------------------------------------
// Script Functions
//------------------------------------------------------------

function EWBrowserWindow::openScript( %this, %file )
{
   if(ScriptEditorGui.visible == false)
      ScriptEditorGui.setVisible(true);
      
   //%script = loadFileText(%file);
   //ScriptEditorGui-->TextPad.setText(%script);
   ScriptEditorGui.parseAndColorizeText(%file, true);
   ScriptEditorGui-->TextPadWindow.text = "TextPad - " @ %file;
}

//------------------------------------------------------------
// TextPad Functions
//------------------------------------------------------------

function ScriptEditorGui::close( %this )
{
   //if(hasSaved = false)
   //{
      MessageBoxYesNoCancel("Save?", 
         "Do you want to save before closing?", 
         "ScriptEditorGui.save(); ScriptEditorGui.exit();", 
         "ScriptEditorGui.exit();", 
         "" );
   //}else{
      //%this.exit();
   //}
}

function ScriptEditorGui::exit( %this )
{
   // Hide TextPad
   %this.setVisible(false);
   
   // Clean up
   %this-->TextPad.setText("");
}

function ScriptEditorGui::save( %this )
{
   %title = %this-->TextPadWindow.text;
   %file = getWord(%title, 2);
   %text = %this-->TextPad.getText();
   %text = %this.removeColoration(%text);
   writeFile(%file, %text);
   //Re-exec the file as well, to make sure it updates
   exec(%file);
   %this.parseAndColorizeText(%file, true);
}

function ScriptEditorGui::parseAndColorizeText( %this, %textFile, %clear )
{
	if( %clear )
		ScriptEditorGui-->TextPad.setValue(""); // Clear it

   %file = new FileObject();

   %fileName = expandFileName( %textFile );

   %fileIsOpen = %file.openforRead( %fileName );

   %commented = false;

   if( %fileIsOpen ) 
   {
         while(!%file.isEOF()) 
         {
               %currentLine = %file.readLine();
               
               %quote = false;

               //next, walk through and colorize the current line based on our characters!
               for(%i=0; %i<strlen(%currentLine); %i++)
               {
                  %lineLen = strlen(%currentLine);
                  
			         %char = getSubStr(%currentLine, %i, 1);

                  if(%commented && %i==0){
                     //%currentLine = "\c6"@%currentLine;
                     %i++;
                  }
	                 

			         //if we're selectively commented, and the next characters don't make a comment terminator, just continue on
                  if(%commented && getSubStr(%currentLine, %i, 2) !$= "*/")
                     continue;
               
			   //==================================================================
			   // Comments!
			   //==================================================================
			   if(%char $= "/" && !%quote){
			      //make sure it's either a / or a * that follows, otherwise it's probably an operator
			      %nextchar = getSubStr(%currentLine, %i+1, 1);
			      if(%nextChar $= "/" || %nextChar $= "*"){
			         
			         %colorChar = "<color:"@%this.plugin.comments@">";
			         %end = getSubStr(%currentLine, %i, %lineLen-%i);
			         //yep, it's a comment. so we need to add in the coloration character here
			         if(%i == 0)
			            %currentLine = %colorChar@%end;
                  else
                     %currentLine = getSubStr(%currentLine, 0, %i) @ %colorChar @ %end;
                     
                  %i++; //added a character, so we up the index just to play it safe
                                 
                  if(%nextChar $= "/")
                      break; //we're done with the line
                   else{
                      %commented = true; //nope, it's a selective comment, we may not yet be done.
                      continue;
                   }
                      
               }
            }
            
            //uncomment a selective comment
            if(%char $= "*" && !%quote){
               //make sure it's either a / or a * that follows, otherwise it's probably an operator
			      %nextchar = getSubStr(%currentLine, %i+1, 1);
			      if(%nextChar $= "/"){
			         %colorChar = "<color:000000>";
			         
			         %commented = false; //nope, it's a selective comment, we may not yet be done.
			         
			         if(%lineLen-%i-1 > 1) //double check we should even bother.
			         {
                     %end = getSubStr(%currentLine, %i+1, %lineLen-%i-1);
                     //yep, it's a comment. so we need to add in the coloration character here
                     if(%i == 0)
                        %currentLine = getSubStr(%currentLine, 1, 1)@%colorChar@getSubStr(%currentLine, %i+1, %lineLen-%i-1);
                     else
                        %currentLine = getSubStr(%currentLine, 0, %i+1) @ %colorChar @ %end;
                        
                     %i++; //added a character, so we up the index just to play it safe
			         }
                  else
                     continue;
                  
               }
            }
            
            //uncomment a selective comment
            if(%char $= "\"" && !%commented){
               //if we're currently IN a quote, check if we should end it. We don't end it if there was a \ leading up to this.
               if(%quote)
               {
                  %priorChar = getSubStr(%currentLine, %i-1, 1);
                  if(%priorChar !$= "\\"){
                     //nope, we're clear to stop our current quotation.
                     %quote = false;
                     
                     %colorChar = "<color:000000>";
                     %end = getSubStr(%currentLine, %i+1, %lineLen-%i+1);
                     if(%i == 0)
                        %currentLine = %colorChar@%end;
                     else
                        %currentLine = getSubStr(%currentLine, 0, %i+1) @ %colorChar @ %end;
                        
                     %i++; //added a character, so we up the index just to play it safe
                  }
               }
               else
               {
                  //not in a current quote, so start it!
                  %quote = true;
                     
                   %colorChar = "<color:"@%this.plugin.comments@">";
                   %end = getSubStr(%currentLine, %i, %lineLen-%i);
                   if(%i == 0)
                        %currentLine = %colorChar@%end;
                   else
                        %currentLine = getSubStr(%currentLine, 0, %i) @ %colorChar @ %end;
                        
                   %i++; //added a character, so we up the index just to play it safe
               }
            }
      
			   //local Variables!
			   if(%char $= "%" && !%commented && !%quote)
			   {
			      //go find the end of the varaible name
			      %toEndCount = strlen( getSubStr(%currentLine, %i, %lineLen-%i));
			      for(%l=0; %l<%toEndCount; %l++)
			      {
			         %nextchar = getSubStr(%currentLine, %i+1+%l, 1);
			         if(isCharScriptTerminator(%nextChar))
			            break;
			      }
			      
			      %colorChar = %this.plugin.localVars;
			      %var = getSubStr(%currentLine, %i, %l+1);
			      if(%var $= "%this") //this(haha) is a special case, it's actually reserved and is handled below
			         continue;
			      %end = getSubStr(%currentLine, %i+1+%l, %lineLen-%i-1-%l);
			    
			      if(%i == 0)
                  %currentLine = %colorChar @ %var @ %this.plugin.plaintext @ %end;
               else{
                  %currentLine = getSubStr(%currentLine, 0, %i) @ %colorChar @ %var @ "<color:000000>" @ %end; 
               }
                  
               //push us to after the variable ends to save effort
               %i += 3+%l;
               %next = getSubStr(%currentLine, %i, 1);
               %derp = 0;
			   }
         
			   //Global Variables!
			   if(%char $= "$" && !%commented && !%quote)
			   {
               //ensure we're not doing some kind of string comparison
               %nextChar = getSubStr(%currentLine, %i+1, 1);
               if(%nextChar !$= "=")
               {
			         //go find the end of the varaible name
			         %toEndCount = strlen( getSubStr(%currentLine, %i, %lineLen-%i));
			         for(%l=0; %l<%toEndCount; %l++)
			         {
			            %nextchar = getSubStr(%currentLine, %i+1+%l, 1);
			            if(isCharScriptTerminator(%nextChar))
			               break;
			         }
			      
			         %colorChar = "<color:"@%this.plugin.globalvars@">";
			         %var = getSubStr(%currentLine, %i, %l+1);
			         %end = getSubStr(%currentLine, %i+1+%l, %lineLen-%i-1-%l);
			    
			         if(%i == 0)
                     %currentLine = %colorChar @ %var @ "<color:000000>" @ %end;
                  else{
                     %currentLine = getSubStr(%currentLine, 0, %i) @ %colorChar @ %var @ "<color:000000>" @ %end; 
                  }
                  
                  //push us to after the variable ends to save effort
                  %i += 3+%l;
               }
			   }
			   
			   //reserved words!
			   %word = hasReservedWord(getSubStr(%currentLine, %i, %lineLen-%i));
			   if(%word !$= "" && !%commented && !%quote)
			   {
			      %wordPos = getWord(%word, 1);
			      %wordLen = strlen(getWord(%word, 0));
			      %word = getWord(%word,0);
			      
			      %end = getSubStr(%currentLine, %i+%wordPos+%wordLen, %lineLen-%i-%wordPos-%wordLen);

               %colorChar = "<color:"@%this.plugin.reservedWords@">";

               if(%i+%wordPos == 0)
                  %currentLine = %colorChar @ %word @ "<color:000000>" @ %end;
               else{
                  %currentLine = getSubStr(%currentLine, 0, %i+%wordPos) @ %colorChar @ %word @ "<color:000000>" @ %end; 
               }
               
               %i += 2+%wordPos+%wordLen;
			   }
			   
			   //Operators!
			   /*if(isCharScriptOperator(%char) && !%commented && !%quote)
			   {
			      if(getSubStr(%currentLine, %i-1, 1) !$= "/" && getSubStr(%currentLine, %i+1, 1) !$= "/")
			      {
                  //go find the end of the varaible name
                  %toEndCount = strlen( getSubStr(%currentLine, %i, %lineLen-%i));
                  for(%l=0; %l<%toEndCount; %l++)
                  {
                     %nextchar = getSubStr(%currentLine, %i+1+%l, 1);
                     if(!isCharScriptOperator(%nextChar))
                        break;
                  }
                  
                  %colorChar = "\c7";
                  %var = getSubStr(%currentLine, %i, %l+1);
                  %end = getSubStr(%currentLine, %i+1+%l, %lineLen-%i-1-%l);
                
                  if(%i == 0)
                     %currentLine = %colorChar @ %var @ "\c0" @ %end;
                  else{
                     %currentLine = getSubStr(%currentLine, 0, %i) @ %colorChar @ %var @ "\c0" @ %end; 
                  }
                     
                  //push us to after the variable ends to save effort
                  %i += 1+%l;
			      }
			   }*/
			}
			
			%currentLine = %currentLine@"\n";   //make sure to add the return character!

			ScriptEditorGui-->TextPad.addText( %currentLine, true );
		}
	}

	if( %theControl.isVisible() ) %theControl.forceReflow();

	%file.close();

	%file.delete();
}

function ScriptEditorGui::refresh( %this )
{
   // Auto-save: Be aware!
   ScriptEditorGui.save();
         
   %title = %this-->TextPadWindow.text;
   %file = getWord(%title, 2);
   exec(%file);
}

function ScriptEditorGui::removeColoration( %this, %text)
{
     %lineCount = getRecordCount(%text);
     
     %returnTxt = "";
     
     for(%l=0; %l<%lineCount; %l++)
     {
           %line = getRecord(%text,%l);
           
           %line =detag(%line);
           %line = stripChars( %line, "\c0" );
           %line = stripChars( %line, "\c1" );
           %line = stripChars( %line, "\c2" );
           %line = stripChars( %line, "\c3" );
           %line = stripChars( %line, "\c4" );
           %line = stripChars( %line, "\c5" );
           %line = stripChars( %line, "\c6" );
           %line = stripChars( %line, "\c7" );
           %line = stripChars( %line, "\c8" );
           %line = stripChars( %line, "\c9" );
           
           if(%returnTxt $= "")
               %returnTxt = %line;
           else
               %returnTxt = %returnTxt @ "\n" @ %line;
     }
     return %returnTxt;
}

function ScriptEditorGui::injectMLTag(%this, %line, %tag, %start, %end)
{
   if(%char $= "%" && !%commented && !%quote)
   {
      //go find the end of the varaible name
      %toEndCount = strlen( getSubStr(%currentLine, %i, %lineLen-%i));
      for(%l=0; %l<%toEndCount; %l++)
      {
         %nextchar = getSubStr(%currentLine, %i+1+%l, 1);
         if(isCharScriptTerminator(%nextChar))
            break;
      }

      %colorChar = %this.plugin.localVars;
      %var = getSubStr(%currentLine, %i, %l+1);
      if(%var $= "%this") //this(haha) is a special case, it's actually reserved and is handled below
         continue;
      %end = getSubStr(%currentLine, %i+1+%l, %lineLen-%i-1-%l);

      if(%i == 0)
         %currentLine = %colorChar @ %var @ %this.plugin.plaintext @ %end;
      else{
         %currentLine = getSubStr(%currentLine, 0, %i) @ %colorChar @ %var @ "<color:000000>" @ %end; 
      }

      //push us to after the variable ends to save effort
      %i += 3+%l;
      %next = getSubStr(%currentLine, %i, 1);
      %derp = 0;
   }
}

function hasReservedWord(%text)
{
   /*%endText = getSubStr(%text, %i, (strlen(%lineLen)-%i);
   %toEnd = strlen( %endText );
   for(%i=0; %i<%toEnd; %i++)
   {
         
   }
   %lwTxt = strlwr(%text);
   if(%pos = strstr(%lwTxt, "for")&& %pos != -1 && %pos > %i)
   {
      return %pos SPC "3";
   }
   else if(%pos = strstr(%lwTxt, "if")&& %pos != -1 && %pos > %i)
   {
      return %pos SPC "2";
   }
   else if(%pos = strstr(%lwTxt, "else")&& %pos != -1 && %pos > %i)
   {
      return %pos SPC "4";
   }
   else if(%pos = strstr(%lwTxt, "function")&& %pos != -1 && %pos > %i)
   {
      return %pos SPC "8";
   }
   else if(%pos = strstr(%lwTxt, "while")&& %pos != -1 && %pos > %i)
   {
      return %pos SPC "5";
   }
   else if(%pos = strstr(%lwTxt, "return")&& %pos != -1 && %pos > %i)
   {
      return %pos SPC "6";
   }
   else if(%pos = strstr(%lwTxt, "datablock")&& %pos != -1 && %pos > %i)
   {
      return %pos SPC "9";
   }
   else if(%pos = strstr(%lwTxt, "singleton")&& %pos != -1 && %pos > %i)
   {
      return %pos SPC "9";
   }
   else if(%pos = strstr(%lwTxt, "continue")&& %pos != -1 && %pos > %i)
   {
      return %pos SPC "8";
   }
   else if(%pos = strstr(%lwTxt, "break")&& %pos != -1 && %pos > %i)
   {
      return %pos SPC "5";
   }
   else if(%pos = strstr(%lwTxt, "switch$")&& %pos != -1 && %pos > %i)
   {
      return %pos SPC "7";
   }
   else if(%pos = strstr(%lwTxt, "new")&& %pos != -1 && %pos > %i)
   {
      return %pos SPC "3";
   }*/
   for(%i=0; %i<getWordCount($ScriptEditorPrefs::ReservedWords); %i++)
   {
      %resWord = getWord($ScriptEditorPrefs::ReservedWords, %i);
      if(strContains(%text, %resWord))
      {
         %wordPos = strstr( strlwr(%text), %resWord);
         
         if(%word $= "")
            %word = %resWord SPC %wordPos;
         else {
            if(%wordPos < getWord(%word, 0))
               %word = %resWord SPC %wordPos; 
         }
      }
   }
   
   if(%word !$= ""){
      return %word;
   }
   else  
      return "";
}

