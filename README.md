# Disassembler UI Test #

I'm porting the [6502bench](https://github.com/fadden/6502bench) user
interface from WinForms to WPF.  Replicating the main code interaction
window has proven to be a challenge.  I created this project to have a
way to experiment and ask questions.

The interesting bit looks like this:

![WinForms Sample](wf-sample.png)

Key things to note:

 * The ListView has resizable columns and full-line multi-select.  It does
   not allow columns to be rearranged or sorted.
 * Most rows have 9 columns.  Some rows have full-line comments or "notes",
   which start in the Label column.  (If you collapse the first 5 columns,
   you're left with what looks like a source listing.)  Notes may have a
   background color set.
 * Some individual cells may get color highlights, e.g. if you select
   "jmp Start" (offset +000000), the Addr and Label columns at the target
   line (offset +000047) will have their backgrounds set to light blue.

The WinForms version used a ListView control with OwnerDraw.

