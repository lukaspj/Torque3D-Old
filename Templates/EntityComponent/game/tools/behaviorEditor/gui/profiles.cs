if(!isObject(EditorFillColors)) new GuiControlProfile (EditorFillColors)
{
   fillColor = "102 153 204 100";
   fillColorHL = "102 153 204 100";
   borderColor = "0 0 0";
   borderColorHL = "0 0 0";
};

if(!isObject(EditorFontHL)) new GuiControlProfile (EditorFontHL : EditorFillColors ) 
{ 
   fontType    = "Arial";
   fontSize    = "14";
   fontColorHL = "25 25 25 220";
   fontColorNA = "128 128 128";
   fontColor = "0 0 0 150";
};

if(!isObject(EditorFontHLBold)) new GuiControlProfile (EditorFontHLBold : EditorFontHL ) 
{ 
   fontType    = "Arial";
};

if(!isObject(EditorTextHLBoldLeft)) new GuiControlProfile (EditorTextHLBoldLeft : EditorFontHLBold ) { justify = "left"; };

if(!isObject(EditorTextHLBoldCenter)) new GuiControlProfile (EditorTextHLBoldCenter : EditorFontHLBold ) { justify = "center"; };

if (!isObject(EditorTextEditBold)) new GuiControlProfile (EditorTextEditBold : EditorTextHLBoldLeft )
{
   fillColor = "255 255 255 200";
   canKeyFocus = true;
   tab         = true;
   opaque      = true;
   bitmap = "./images/textEdit";
   border = -2;
};

if(!isObject(EditorTextWhiteBoldCenter)) new GuiControlProfile( EditorTextWhiteBoldCenter : EditorTextHLBoldCenter )
{
   fontColorHL = "25 25 25 220";
   fontColorNA = "128 128 128";
   fontColor = "255 255 255";   
};

if (!isObject(EditorMLTextProfile)) new GuiControlProfile (EditorMLTextProfile: EditorTextWhiteBoldCenter)
{
   border = false;
   fillColor = "102 153 204 0";
   fillColorHL = "102 153 204 0";
   borderColor = "0 51 153 0";
   borderColorHL = "0 51 153 0";   
};

if (!isObject(EditorMLTextProfileModeless)) new GuiControlProfile (EditorMLTextProfileModeless: EditorMLTextProfile)
{
   modal = false;
};

if (!isObject(EditorTextEditBoldModeless)) new GuiControlProfile (EditorTextEditBoldModeless : EditorTextEditBold )
{
   fontColor = "0 0 0 255";
   fontColors[1] = "255 0 0";
   modal = false; 
};

if(!isObject(GuiTransparentProfileModeless)) new GuiControlProfile (GuiTransparentProfileModeless) 
{
   opaque = false;
   border = false;
   modal = false;
};

if(!isObject(EditorBehaviorRolloutProfile))
   singleton GuiControlProfile(EditorBehaviorRolloutProfile)  
   {
      border = 0;
      
      hasBitmapArray = true;
      bitmap = "./images/rollout_dark_bg";
      
      textoffset = "17 0";
      category = "Editor";
   };
   
if(!isObject(EditorBehaviorGroupProfile))
   singleton GuiControlProfile(EditorBehaviorGroupProfile)  
   {
      border = 0;
      
      hasBitmapArray = true;
      bitmap = "./images/rollout_group_bg";
      
      textoffset = "17 0";
      category = "Editor";
   };

if(!isObject(visualNodeProfile))
	new GuiControlProfile (visualNodeProfile)
	{
		opaque = false;
		border = 2;
		fillColor = "242 241 240";
		fillColorHL = "221 221 221";
		fillColorNA = "200 200 200";
		fontColor = "50 50 50";
		fontColorHL = "0 0 0";
		bevelColorHL = "255 255 255";
		bevelColorLL = "0 0 0";
		text = "untitled";
		//bitmap = "./window";
		bitmap = "./images/node";
		textOffset = "8 4";
		hasBitmapArray = true;
		justify = "left";
		category = "Core";
	};