if(!isObject(visualNodeControlProfile))
new GuiControlProfile (visualNodeControlProfile)
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
   bitmap = "./node";
   textOffset = "8 4";
   hasBitmapArray = true;
   justify = "left";
   category = "Core";
};

new GuiVisualNodeCtrl(VNTest)
{
	hm = "0";
};

function VNTest::onWake(%this)
{
	%this.addNodes();	
}

function VNTest::addNode(%this)
{
	%node = new VisualNode()
	{
		profile = visualNodeControlProfile;
	};
	
	%node.addInputSocket("In");
	%node.addOutputSocket("Out");
	%node.addOutputSocket("Out2");
	%node.addParamSocket("What");
	%node.addParamSocket("What2");
	%node.addParamSocket("What3");
	
	%this.add(%node);
}

function VNTest::addNodes(%this)
{
	%this.addNode();
	//%this.addNode();
}

