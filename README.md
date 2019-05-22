# Disassembler UI Test #

I'm porting the [6502bench](https://github.com/fadden/6502bench) user
interface from WinForms to WPF.  Replicating the main code interaction
window has proven to be a challenge.  I created this project as a
sandbox for experiments.

The central part of the UI looks like this:

![WinForms Sample](wf-sample.png)

Key things to note:

 * The ListView has resizable columns and full-line multi-select.  It does
   not allow columns to be rearranged or sorted.
 * Most rows have 9 columns.  Some rows have full-line comments or "notes",
   which start in the Label column and extend to the end of the Comment
   column.  (If you collapse the first 5 columns, you're left with what
   looks like a source listing.)
 * Some individual cells may get color highlights, e.g. if you select
   "jmp Start" (offset +000000), the Addr and Label columns at the target
   line (offset +000047) will have their backgrounds set to light blue.
   Notes may have a background color set.  (This was not implemented here.)
 * I don't particularly want mouse-over highlighting, but I do need the
   selected row(s) to be highlighted.  (This gets lost when you replace the
   control template).

The WinForms version used a ListView control with OwnerDraw.


When you run the project, you are given four options.  Clicking on a button
creates an instance of that type of window.

 * Simple List: the data is presented in a generic ListView.  This lets
   you compare the default style.
 * Multi-Column Template: a partial implementation based on a Stack Overflow
   answer.  The selection highlighting is partially implemented -- you'll
   notice that it's green and doesn't look quite right on the long lines -- and
   the mouse-hover effects don't work on the long lines.
 * GridViewRowPresenter: a variation on the previous, using
   GridViewRowPresenter elements.
 * Fully Styled: a merge of the above with the default WPF style (WPF 4.5
   in Win10).  This should be indistinguishable from the Simple List
   version, except that the "long comments" start in the 5th column and
   span multiple columns.

The current solution doesn't cap the width of the long comment lines, so
if the user shrinks the rightmost columns you'll still see the long comments.
For the case of Notes, this is probably desirable.  I haven't figured out a
way to do this, other than by catching thumb DragDeltaEvents and summing up
column widths into a property in the code-behind.

The code license is Apache 2.0, so it can be used in free or commercial
products.  There is no NOTICE file, so you don't need to provide attribution
in the shipping product.
