//var:: to access a given variable used by the node
//out:: to access a given out socket, to acccess the code for collapsing, used ::refcode
//in:: to access a given out socket
//@ on each side delimits the parsing for variables and socket code
//in the event of more than one socket applying, such as if-else's, you can 
//apply cases where it checks for all relevent ones using &&
/*<varNode String>
   //variable declarations as var, name, type
   <var String String/>
</varNode>

<FuncNode keyBindEvent> //this defines it as a function node, and sets the name

   //what category of node this would be placed in
   <category Events/>
   
   //define the node's variables
   <var moveMap ActionMap/>
   <var device String/>
   <var key String/>
   
   //define the node's output sockets
   <out onKeyDown/>
   <out onKeyUp/>
   <out onKeyHold/>
   
   //define the node's input sockets
   //<in>

   //if the sockets listed are <in in> or <out out>, then it's a simple flow path, it will drop in it's
   //and keep 'stacking' the next node down

   //here we have the proper code portion of the node, because we reference connecting nodes via the 'refcode'
   //this section will "collapse" back to the node that called it to create a streamlined function of code
   <Code>
   @var::moveMap@.bindCmd(@var::device@, "@var::key@", on@var::key@Pressed);
   function on@var::key@Pressed(%val){
      <out::onKeyDown>
      if(%val) {
         @out::onKeyDown::Code@
      }
      </out::onKeyDown>
      <out::onKeyDown&&out::onKeyDown>
      else 
      </out::onKeyDown&&out::onKeyDown>
      <out::onKeyUp>
      if(!%val) {
         @out::onKeyUp::Code@
      }
      </out::onKeyUp>
   }
   </Code>
</FuncNode>
      
      
//so, if the variables movemap, device and key are 'global', 'keyboard', and 'f', respectively, 
//and our refcode called some functions, like say, reload, our output would look something like this:

/*Global.bindCmd(keyboard, "F", onFPressed);
function onFPressed(%val){
   if(%val) {
      reload();
   }
   else if(!%val) {
      wave();
   }
}*/
   