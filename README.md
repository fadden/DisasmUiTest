# Disassembler UI Test #

I'm porting the [6502bench](https://github.com/fadden/6502bench) user
interface from WinForms to WPF.  Replicating the main code interaction
window has proven to be a challenge.  I created this project as a
sandbox for experiments and to provide background if I need to post
questions.

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
   Notes may have a background color set.
 * I don't particularly want mouse-over highlighting, but I do need the
   selection to be highlighted.  (This gets lost when you replace the
   control template).

The WinForms version used a ListView control with OwnerDraw.

