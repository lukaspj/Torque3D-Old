$ScriptEditorPrefs::localVars = 2;
$ScriptEditorPrefs::globalVars = 3;
$ScriptEditorPrefs::reservedWord = 4;
$ScriptEditorPrefs::strings = 5;
$ScriptEditorPrefs::comments = 6;
$ScriptEditorPrefs::operators = 7;

$ScriptEditorPrefs::localVars::color = "0 160 128"; //local variables: %var
$ScriptEditorPrefs::globalVars::color = "196 92 0";  //global variables: $var
$ScriptEditorPrefs::reservedWord::color = "0 0 255"; //reserved words: for, function, if, else
$ScriptEditorPrefs::strings::color = "160 32 240";   //Strings: "blah"
$ScriptEditorPrefs::comments::color = "0 100 0";     //comments: //derp /*herp*/
$ScriptEditorPrefs::operators::color = "107 142 35";

if( !isObject( GuiScriptEditorProfile ) )
new GuiControlProfile( GuiScriptEditorProfile )
{
   fontType = ($platform $= "macos") ? "Monaco" : "Lucida Console";
   fontSize = ($platform $= "macos") ? 13 : 12;
   tab = true;
   canKeyFocus = true;
   
   // Deviate from the Default
   opaque=true;  
   
   fillColor = "255 255 255";
   
   //Default text color
   fontColor = "0 0 0"; 
   
   fontColors[$ScriptEditorPrefs::localVars] = $ScriptEditorPrefs::localVars::color; //local variables: %var
   fontColors[$ScriptEditorPrefs::globalVars] = $ScriptEditorPrefs::globalVars::color; //global variables: $var
   fontColors[$ScriptEditorPrefs::reservedWord] = $ScriptEditorPrefs::reservedWord::color; //reserved words: for, function, if, else
   fontColors[$ScriptEditorPrefs::strings] = $ScriptEditorPrefs::strings::color; //Strings: "blah"
   fontColors[$ScriptEditorPrefs::comments] = $ScriptEditorPrefs::comments::color; //comments: //derp /*herp*/
   fontColors[$ScriptEditorPrefs::operators] = $ScriptEditorPrefs::operators::color; //operators: = + - *
   
   fontColorHL = "49 106 197"; //selected text

   border = 0;
   category = "Core";
};