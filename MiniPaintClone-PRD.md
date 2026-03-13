# PRD: Mini Paint Studio for WPF Students

## 1. Project title
`Mini Paint Studio`

## 2. Project purpose
Build a brand-new WPF application from scratch that helps students practice:

- event-driven programming
- WPF layout and controls
- mouse input handling
- passing data between windows
- drawing on a `Canvas`
- working with shapes and collections

This project should be built over several lectures, starting with a simple version and expanding step by step.

---

## 3. Project summary
The application should allow a user to:

- enter a display name in a startup window
- open a drawing window
- see the passed-in display name
- draw freehand on a `Canvas`
- choose a tool
- choose a color
- choose brush thickness
- clear the canvas
- optionally undo the last drawing
- optionally draw basic shapes

---

## 4. Why this project is a good teaching choice

### Educational value
This project is suitable for beginner WPF students because it teaches:

- **Events**: button clicks, mouse down, mouse move, mouse up
- **Controls**: `TextBox`, `Button`, `Label`, `ComboBox`, `Slider`, `Canvas`, `ListBox`
- **Window navigation**: opening one window from another
- **Data passing**: sending user data through a constructor
- **Visual feedback**: every event produces an immediate on-screen result
- **Progressive complexity**: students can build a simple version first, then add features later

### Why this project is effective
A mini paint application is interactive and engaging. Students can immediately see how user input triggers code, which makes event-driven programming easier to understand than with forms-only applications.

---

# 5. Project goals

## Functional goals
The system must allow the user to:

1. Enter a display name in the first window
2. Open the paint window
3. Display the passed-in display name in the paint window
4. Draw freehand on a `Canvas`
5. Select a drawing color
6. Select a brush thickness
7. Clear all drawings
8. Optionally draw shapes such as:
   - line
   - rectangle
   - ellipse

## Learning goals
Students should understand:

- what an event is
- how controls raise events
- how to write event handlers in code-behind
- how to pass data from one window to another
- how dynamic UI elements can be added to a `Canvas`
- how state is stored while drawing

---

# 6. Target users
Beginner programming students learning WPF for the first time.

---

# 7. Scope

## In scope
- one startup window
- one drawing window
- freehand drawing
- simple tool options
- color selection
- thickness selection
- clear canvas
- optional undo
- optional shape tools

## Out of scope for the first version
- saving to image files
- loading saved artwork
- advanced brush styles
- layers
- text drawing
- object resizing after drawing
- full MVVM architecture

---

# 8. Suggested application flow

1. User opens `LaunchWindow`
2. User enters a display name
3. User clicks `Start Studio`
4. `LaunchWindow` creates `PaintStudioWindow` and passes the display name
5. `PaintStudioWindow` shows the display name
6. User selects a tool, color, and thickness
7. User draws on the canvas
8. User can clear or undo drawings

---

# 9. Functional requirements

## FR1: Accept user input in `LaunchWindow`
- The system must provide a `TextBox` for entering a display name.
- The system must provide a button to open the paint studio.

## FR2: Pass data to `PaintStudioWindow`
- The system must pass the entered display name from `LaunchWindow` to `PaintStudioWindow` through a constructor.

## FR3: Display user information in `PaintStudioWindow`
- The system must display the received display name in the paint studio window.

## FR4: Freehand drawing
- When the user presses the left mouse button on the canvas, drawing begins.
- While the mouse moves with the button pressed, the drawing continues.
- When the mouse button is released, drawing ends.

## FR5: Tool selection
The system should provide tools such as:

- `Pen`
- `Line`
- `Rectangle`
- `Ellipse`

Version 1 may start with only `Pen`.

## FR6: Color selection
- The user must be able to choose a drawing color.
- A simple `ComboBox` containing color names is sufficient.

## FR7: Brush thickness
- The user must be able to choose thickness using either:
  - a `Slider`, or
  - a `ComboBox`

## FR8: Clear canvas
- The user must be able to remove all drawings from the canvas.

## FR9: Undo last drawing
- The system should remove the last shape or stroke added to the canvas.

---

# 10. Non-functional requirements

- The interface must be simple and suitable for beginners.
- Control names must be meaningful.
- Methods must be short and focused.
- The application should respond quickly to user actions.
- The design should support future extensions.

---

# 11. Suggested UI design

## `LaunchWindow`
Purpose: collect the user's display name and open the paint application.

### Controls
- `TextBox` → `txtDisplayName`
- `Label` → `lblWelcome`
- `Button` → `btnStartStudio`

## `PaintStudioWindow`
Purpose: display the user's display name and provide a drawing surface with tools.

### Suggested layout
- top section: title and user display name
- left or top panel: tools and options
- main section: drawing area

### Controls
- `Label` → `lblArtistName`
- `Canvas` → `cnvDrawingSurface`
- `ComboBox` → `cmbToolSelector`
- `ComboBox` → `cmbColorSelector`
- `Slider` → `sldBrushThickness`
- `Button` → `btnClearCanvas`
- `Button` → `btnUndoStroke`

---

# 12. Naming conventions

## Windows
- `LaunchWindow`
- `PaintStudioWindow`

## Controls
Use clear prefixes:

- `txt` for `TextBox`
- `btn` for `Button`
- `lbl` for `Label`
- `cmb` for `ComboBox`
- `sld` for `Slider`
- `cnv` for `Canvas`

### Recommended names
- `txtDisplayName`
- `lblWelcome`
- `btnStartStudio`
- `lblArtistName`
- `cnvDrawingSurface`
- `cmbToolSelector`
- `cmbColorSelector`
- `sldBrushThickness`
- `btnClearCanvas`
- `btnUndoStroke`

---

# 13. Required variables and fields

In `PaintStudioWindow.xaml.cs`, students will likely need:

- `bool isDrawing`
- `Point startPoint`
- `Shape? currentShape`
- `Polyline? currentStroke`
- `string selectedTool`
- `Brush selectedBrush`
- `double selectedThickness`

If undo is implemented:
- use a collection of drawn elements, or
- use `cnvDrawingSurface.Children`

---

# 14. Required methods

## In `LaunchWindow`
### `btnStartStudio_Click(...)`
Responsibility:
- read the display name from `txtDisplayName`
- create the drawing window
- pass the display name into the constructor
- call `Show()`

---

## In `PaintStudioWindow`
### Constructor
`PaintStudioWindow(string displayName)`

Responsibility:
- initialize controls
- display the received display name

### `cnvDrawingSurface_MouseLeftButtonDown(...)`
Responsibility:
- start drawing
- save the first mouse position
- create the initial shape or stroke

### `cnvDrawingSurface_MouseMove(...)`
Responsibility:
- continue drawing while the mouse is pressed
- update the current line, shape, or stroke

### `cnvDrawingSurface_MouseLeftButtonUp(...)`
Responsibility:
- stop drawing
- release mouse capture
- finalize the current shape or stroke

### `btnClearCanvas_Click(...)`
Responsibility:
- remove all items from the canvas

### `btnUndoStroke_Click(...)`
Responsibility:
- remove the most recently added drawing

### `cmbToolSelector_SelectionChanged(...)`
Responsibility:
- update the selected tool

### `cmbColorSelector_SelectionChanged(...)`
Responsibility:
- update the selected drawing color

### `sldBrushThickness_ValueChanged(...)`
Responsibility:
- update the selected thickness

---

# 15. Suggested development phases

## Phase 1: Project setup and window navigation
Students should:

1. create a new WPF project
2. add `LaunchWindow`
3. add `PaintStudioWindow`
4. open the second window from the first window
5. pass a display name into the second window

### Deliverable
A startup window opens the paint studio and passes user data correctly.

---

## Phase 2: Canvas and freehand drawing
Students should:

1. add a `Canvas`
2. handle:
   - `MouseLeftButtonDown`
   - `MouseMove`
   - `MouseLeftButtonUp`
3. draw freehand using `Polyline`

### Deliverable
The user can draw on the canvas with the mouse.

---

## Phase 3: Tool controls
Students should:

1. add tool selection
2. add color selection
3. add thickness control

### Deliverable
The user can change drawing settings.

---

## Phase 4: Shape drawing
Students should add:

- line
- rectangle
- ellipse

### Deliverable
The user can choose between freehand and shape tools.

---

## Phase 5: Editing actions
Students should add:

- clear canvas
- undo last drawing

### Deliverable
The paint studio is functionally complete for the beginner version.

---

# 16. Recommended implementation order

1. Create a new WPF project
2. Build `LaunchWindow`
3. Build `PaintStudioWindow`
4. Pass the display name to the second window
5. Add the drawing canvas
6. Implement freehand pen drawing
7. Add color selection
8. Add thickness selection
9. Add clear button
10. Add undo button
11. Add shape tools

This order keeps the project manageable and easy to teach.

---

# 17. Basic student algorithms

## Freehand drawing algorithm
1. User presses the mouse on `cnvDrawingSurface`
2. Set `isDrawing = true`
3. Create a new `Polyline`
4. Add the first point
5. While the mouse moves and `isDrawing == true`
6. Add new points to the `Polyline`
7. On mouse up, stop drawing

## Shape drawing algorithm
1. User presses the mouse
2. Save `startPoint`
3. Create a shape object
4. While the mouse moves, update width, height, or end position
5. On mouse up, finalize the shape

---

# 18. Suggested UML-style class diagram

```plaintext
+-----------------------------------------+
|              LaunchWindow               |
+-----------------------------------------+
| - txtDisplayName : TextBox              |
| - lblWelcome : Label                    |
| - btnStartStudio : Button               |
+-----------------------------------------+
| + LaunchWindow()                        |
| + btnStartStudio_Click() : void         |
+-----------------------------------------+
                    |
                    | passes string displayName
                    v
+------------------------------------------------------$
|                 PaintStudioWindow                    |
+------------------------------------------------------$
| - isDrawing : bool                                   |
| - startPoint : Point                                 |
| - currentStroke : Polyline                           |
| - currentShape : Shape                               |
| - selectedTool : string                              |
| - selectedBrush : Brush                              |
| - selectedThickness : double                         |
+------------------------------------------------------$
| + PaintStudioWindow(displayName : string)            |
| + cnvDrawingSurface_MouseLeftButtonDown() : void     |
| + cnvDrawingSurface_MouseMove() : void               |
| + cnvDrawingSurface_MouseLeftButtonUp() : void       |
| + btnClearCanvas_Click() : void                      |
| + btnUndoStroke_Click() : void                       |
| + cmbToolSelector_SelectionChanged() : void          |
| + cmbColorSelector_SelectionChanged() : void         |
| + sldBrushThickness_ValueChanged() : void            |
+------------------------------------------------------$
```

---

# 19. Suggested event diagram

```plaintext
User clicks mouse on drawing canvas
        |
        v
cnvDrawingSurface_MouseLeftButtonDown()
        |
        v
Create drawing object and start tracking position
        |
        v
User moves mouse
        |
        v
cnvDrawingSurface_MouseMove()
        |
        v
Update current stroke or shape
        |
        v
User releases mouse
        |
        v
cnvDrawingSurface_MouseLeftButtonUp()
        |
        v
Finalize drawing
```

---

# 20. Suggested control-to-event map

| Control | Name | Event | Purpose |
|---|---|---|---|
| `Button` | `btnStartStudio` | `Click` | Open the paint studio |
| `Canvas` | `cnvDrawingSurface` | `MouseLeftButtonDown` | Start drawing |
| `Canvas` | `cnvDrawingSurface` | `MouseMove` | Continue drawing |
| `Canvas` | `cnvDrawingSurface` | `MouseLeftButtonUp` | Stop drawing |
| `ComboBox` | `cmbToolSelector` | `SelectionChanged` | Select tool |
| `ComboBox` | `cmbColorSelector` | `SelectionChanged` | Select color |
| `Slider` | `sldBrushThickness` | `ValueChanged` | Change thickness |
| `Button` | `btnClearCanvas` | `Click` | Clear canvas |
| `Button` | `btnUndoStroke` | `Click` | Undo last drawing |

---

# 21. Minimum viable product

If time is limited, the MVP should include only:

- create a startup window
- pass a display name to a second window
- display the display name
- draw freehand on a `Canvas`
- choose a color
- clear the canvas

This is enough to teach the core WPF concepts.

---

# 22. Extension ideas for stronger students

After the basic version works, students can add:

- save drawing to an image file
- load saved artwork
- eraser tool
- fill color for shapes
- status bar showing the current tool
- keyboard shortcuts
- multiple brush presets
- stamp tool
- background image support

---

# 23. Assessment criteria

Students should be able to demonstrate:

1. correct use of WPF controls
2. correct event handling
3. correct data passing between windows
4. meaningful naming of controls and methods
5. working drawing functionality
6. clear and understandable code

---

# 24. Final recommendation
Use the project in this structure:

- `LaunchWindow` = startup and user input window
- `PaintStudioWindow` = drawing and tool window

This gives students a complete fresh-start project that teaches both basic WPF interaction and event-driven programming in a visual way.
