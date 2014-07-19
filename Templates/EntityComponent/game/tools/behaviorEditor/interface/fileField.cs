$ImageFieldTypes = "Image Files|*.jpg;*.png;*.bmp;*.dds"
                 @"|JPEG Files|*.jpg" 
                 @"|PNG Files|*.png"
                 @"|BMP Files|*.bmp"
                 @"|DDS Files|*.dds"
                 @"|All Files|*.*";
                 
$ModelFieldTypes = "Model Files|*.dts;*.dae;*.khz;"
                 @"|DTS Files|*.dts"
                 @"|Collada Files|*.dae"
                 @"|Sketchup Files|*.khz"
                 @"|All Files|*.*";
                 
$SoundFieldTypes = "Sound Files|*.wav;*.ogg;*.mp3;"
                 @"|WAV Files|*.wav"
                 @"|OGG Files|*.ogg"
                 @"|MP3 Files|*.mp3"
                 @"|All Files|*.*";

function BehaviorFieldStack::createFileProperty(%this, %accessor, %filter, %label, %tooltip, %data)
{
   %extent = 64;
      
   %container = new GuiControl() {
      canSaveDynamicFields = "0";
      Profile = "EditorContainerProfile";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "0 0";
      Extent = "300 24";
      MinExtent = "8 2";
      canSave = "0";
      Visible = "1";
      hovertime = "100";
      tooltip = %tooltip;
      tooltipProfile = "EditorToolTipProfile";
   };

   %labelControl = new GuiTextCtrl() {
      canSaveDynamicFields = "0";
      Profile = "EditorFontHLBold";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "16 3";
      Extent = "100 18";
      MinExtent = "8 2";
      canSave = "0";
      Visible = "1";
      hovertime = "100";
      tooltip = %tooltip;
      tooltipProfile = "EditorToolTipProfile";
      text = %label;
      maxLength = "1024";
   };
   
   %editControl = new GuiTextEditCtrl() {
      class = "BehaviorEdTextField";
      internalName = %accessor @ "File";
      canSaveDynamicFields = "0";
      Profile = "EditorTextEdit";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "100 1";
      Extent = %extent - 17 SPC "22";
      MinExtent = "8 2";
      canSave = "0";
      Visible = "1";
      hovertime = "100";
      tooltip = %tooltip;
      tooltipProfile = "EditorToolTipProfile";
      maxLength = "1024";
      historySize = "0";
      password = "0";
      text = %data;
      
      tabComplete = "0";
      sinkAllKeyEvents = "0";
      password = "0";
      passwordMask = "*";
      precision = %precision;
      accessor = %accessor;
      isProperty = true;
      undoLabel = %label;
      object = %this.object;
      useWords = false;
   };
   
   %browse = new GuiButtonCtrl() {
      canSaveDynamicFields = "0";
      className = "fileBrowseFldBtn";
      Profile = "GuiButtonProfile";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = %editControl.position.x + %extent - 17 SPC "1";
      Extent = "15 22";
      MinExtent = "8 2";
      canSave = "0";
      Visible = "1";
      hovertime = "100";
      tooltip = "Browse for a file";
      tooltipProfile = "EditorToolTipProfile";
      text = "...";
      pathField = %editControl;
   };
   %browse.lastPath = %editControl.text;
   
   if(%filter $= "models")
      %browse.filter = $ModelFieldTypes;
   else if(%filter $= "images")
      %browse.filter = $ImageFieldTypes;
   else if(%filter $= "sounds")
      %browse.filter = $SoundFieldTypes;
   else
      %browse.filter = "All Files|*.*";

   %container.add(%labelControl);
   %container.add(%editControl);
   %container.add(%browse);
   
   return %container;
}

function fileBrowseFldBtn::onClick( %this )
{
   if(%this.lastPath $= "")
      %this.lastPath = "art";
    
   getLoadFilename( %this.filter, %this @ ".onBrowseSelect", %this.lastPath );
}

function fileBrowseFldBtn::onBrowseSelect( %this, %path )
{
   %path = makeRelativePath( %path, getMainDotCSDir() );
   %this.lastPath = %path;
   %this.pathField.text = %path;
   %this.pathField.onReturn(); //force the update
   %this.object.inspectorApply();
}