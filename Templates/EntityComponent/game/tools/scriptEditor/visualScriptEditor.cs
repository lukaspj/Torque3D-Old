//-----------------------------------------------------------------------------
// Copyright (C) Sickhead Games, LLC
//-----------------------------------------------------------------------------

singleton GuiControlProfile( VisualScriptEditorProfile )
{
   canKeyFocus = true;
   opaque = true;
   fillColor = "192 192 192 192";
   category = "Editor";
};

singleton GuiControlProfile (GuiSimpleBorderProfile)
{
   opaque = false;   
   border = 1;   
   category = "Editor";
};

singleton GuiCursor(VisualScriptEditorMoveCursor)
{
   hotSpot = "4 4";
   renderOffset = "0 0";
   bitmapName = "~/gui/images/macCursor";
   category = "Editor";
};  

singleton GuiCursor( VisualScriptEditorMoveNodeCursor )
{
   hotSpot = "1 1";
   renderOffset = "0 0";
   bitmapName = "./Cursors/outline/drag_node_outline";
   category = "Editor";
};

singleton GuiCursor( VisualScriptEditorAddNodeCursor )
{
   hotSpot = "1 1";
   renderOffset = "0 0";
   bitmapName = "./Cursors/outline/add_to_end_outline";
   category = "Editor";
};

singleton GuiCursor( VisualScriptEditorInsertNodeCursor )
{
   hotSpot = "1 1";
   renderOffset = "0 0";
   bitmapName = "./Cursors/outline/insert_in_middle_outline";
   category = "Editor";
};

singleton GuiCursor( VisualScriptEditorResizeNodeCursor )
{
   hotSpot = "1 1";
   renderOffset = "0 0";
   bitmapName = "./Cursors/outline/widen_path_outline";
   category = "Editor";
};
