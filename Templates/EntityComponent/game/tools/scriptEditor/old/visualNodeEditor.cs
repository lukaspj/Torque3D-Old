//-----------------------------------------------------------------------------
// Copyright (C) Sickhead Games, LLC
//-----------------------------------------------------------------------------

singleton GuiControlProfile( VisualNodeEditorProfile )
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

singleton GuiCursor(VisualNodeEditorMoveCursor)
{
   hotSpot = "4 4";
   renderOffset = "0 0";
   bitmapName = "~/gui/images/macCursor";
   category = "Editor";
};  

singleton GuiCursor( VisualNodeEditorMoveNodeCursor )
{
   hotSpot = "1 1";
   renderOffset = "0 0";
   bitmapName = "./Cursors/outline/drag_node_outline";
   category = "Editor";
};

singleton GuiCursor( VisualNodeEditorAddNodeCursor )
{
   hotSpot = "1 1";
   renderOffset = "0 0";
   bitmapName = "./Cursors/outline/add_to_end_outline";
   category = "Editor";
};

singleton GuiCursor( VisualNodeEditorInsertNodeCursor )
{
   hotSpot = "1 1";
   renderOffset = "0 0";
   bitmapName = "./Cursors/outline/insert_in_middle_outline";
   category = "Editor";
};

singleton GuiCursor( VisualNodeEditorResizeNodeCursor )
{
   hotSpot = "1 1";
   renderOffset = "0 0";
   bitmapName = "./Cursors/outline/widen_path_outline";
   category = "Editor";
};
