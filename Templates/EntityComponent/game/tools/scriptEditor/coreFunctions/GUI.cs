//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

/*
Description: Dump the contents of file %testFile into GUIMLTextCtrl %theControl.
(Optionally %clear the control before dumping file contents into it.)
*/
function GuiMLTextCtrl::fillFromFile( %theControl , %textFile , %clear ) {

	if( %clear )
	{
		%theControl.setValue(""); // Clear it
	}

	%file = new FileObject();

	%fileName = expandFileName( %textFile );

	%fileIsOpen = %file.openForRead( %fileName );

	if( %fileIsOpen ) 
	{
		while(!%file.isEOF()) 
		{
			%currentLine = %file.readLine();

			%theControl.addText( %currentLine, true );
		}
	}

	if( %theControl.isVisible() ) %theControl.forceReflow();

	%file.close();

	%file.delete();
}