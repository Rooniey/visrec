# vistex_recruitment_task
Console application for recruitment task.

## Instruction
Application must be provided with 3 arguments in that order:

* ***number of vertices*** (integer value, it must be greater than 2)
  
* ***side length*** (double value, it must be greater than 0; invariant culture, decimal point separator - ".")
  
* ***output option*** (string value, accepts two options (case insensitive): 
   "C" - console display; or "F" - save in default file;)*
  
(*) everything that starts with letters "c" or "f" will be accepted (e.i. "console", "FILESAVE")

If those logical requirements are not met, the user will be informed what error occured.

The filepath (relative path, file is created in the application working directory): "regular_polygon.txt" 

## Examples
Displaying on console: area and vertices of equilateral triangle with side length 2.0
```
app.exe 3 2.0 c
```

Saving information about created regular polygon to the file
```
app.exe 8 3.99 f
```
