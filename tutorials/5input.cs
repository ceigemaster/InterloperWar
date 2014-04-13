//============================Top==========================================

// Logically, the most important thing in a video game is being able to control your character
// This guide will cover how the Torque2D engine handles input and how we can use it in our game

//============================Input Event Callbacks========================

// An input event callback is the response from the T2D engine when an input event (clicking, scrolling, or leaving the window with the cursor) has happened
// Input events are handled by the GuiControl that receives them
// The most common GuiControl that we will deal with is the SceneWindow
// This is the Gui object where our game is displayed
// When you click and drag or resize the window, those events are handled by input event callbacks within the engine
// We can also create multiple SceneWindows and handle them in different ways
// This is the syntax for using Input Event Callbacks:

// This is the same process as defining a method
// SceneWindow is the class that this method will work with
// ::onTouchDown is the name of the object method that we are defining
// %this is the variable parameter that is passed for the engine to refer to this method within itself
// %touchID is the variable parameter that defines specifically which finger is touching the screen
// This is an android/iOS function, we won't need this unless we port the game to other platforms
// %worldPosition is the point on the game screen (the world) that was clicked
// %mouseClicks keeps track of the number of times the mouse was clicked (for double-click actions, or even quintuple-click if you like)
function SceneWindow::onTouchDown(%this, %touchID, %worldPosition, %mouseClicks)
{
}

// This is a list of other callbacks you could use:
onTouchDown
onTouchUp
onTouchMoved
onTouchDragged
onTouchEnter
onTouchLeave
onMiddleMouseDown
onMiddleMouseUp
onMiddleMouseDragged
onRightMouseDown
onRightMouseUp
onRightMouseDragged
onMouseWheelUp
onMouseWheelDown
onMouseEnter
onMouseLeave
// The names should be pretty self-explanatory
// Left-click mouse functions are covered by the onTouch... functions

//============================Input Listeners==============================

// An input listener is an object that receives any input events that the SceneWindow also receives now or in the future
// You can allow any SimObject to be an input listener as follows:

// %obj is the local variable that will store the listener
// new announces to the engine that we are creating a new instance of this object
// ScriptObject is the type of object that we are creating
%obj = new ScriptObject()  
{  
   // class is an existing field already within the engine that we are giving to this object
   class="ExampleListener";  
};  

// This is how we call the object method
SceneWindow.addInputListener(%obj);

// This is how we can tell the engine that we want the listener to stop receiving the same inputs as SceneWindow
SceneWindow.removeInputListener(%obj);

//============================Per-Object Callbacks=========================

// While you can use input callbacks on the SceneWindow level, it is also possible to use them on a per-object basis
// This means that individual sprites or other scene objects can react to defined input events
// Touching or clicking within that object's bounding box will result in the callback being run

// To turn on SceneWindow event passing:

// Turn on input events for scene objects.
SceneWindow.setUseObjectInputEvents(true);

// As a second step, each individual object needs its ability to receive input events turned on
// This can be done with .setUseInputEvents():

// We create a new Sprite and store it in the %object variable
// We give it the class field and put it in the ButtonClass
%object = new Sprite() {class = "ButtonClass";};
// Now we tell this sprite to use input event from the SceneWindow
%object.setUseInputEvents(true);

// Note that we used a different format for defining the Sprite object because it was a one-line function
// We could have just as easily done this:

%object = new Sprite()
{
    class = "ButtonClass";
};
// It means the same thing

// You can then use the same callback list as the SceneWindow to create object specific functions:

function ButtonClass::onTouchDown(%this, %touchID, %worldPosition)
{
}

function ButtonClass::onTouchUp(%this, %touchID, %worldPosition)
{
}

// Note that the onMouseEnter/onTouchEnter and onMouseLeave/onTouchLeave callbacks do not work for objects

// Consider the following example:

// Make sure that you have turned on object event passing for both the SceneWindow and each individual object

function SceneWindow::onTouchDown(%this, %touchID, %worldPosition)
{
    echo("This is the SceneWindow");
}

function AreaX::onTouchDown(%this, %touchID, %worldPosition)
{
   echo("This is Area X");
}

function AreaY::onTouchDown(%this, %touchID, %worldPosition)
{
   echo("This is Area Y");
}

// Referencing the example above, clicking or touching anywhere in the area of the SceneWindow will call the SceneWindow::onTouchDown method
// Within the scene object "X", both the SceneWindow::onTouchDown and AreaX::onTouchDown are run
// A click or touch within the scene object "Y" will give you the echo statements in the console for SceneWindow::onTouchDown and AreaY::onTouchDown only 
// If you delete the SceneWindow::onTouchDown function, you will only receive a callback if you touch or click within either the X or Y areas.
// Keep this in mind when writing response callbacks for your input events
// Torque 2D gives you complete control over how global or local those callbacks should be

//============================Action Maps==================================

// ActionMaps hold key/input binds that give you commands when certain input events happen. 
// These events can be anything from pressing the space bar, up arrow, or "w" key to moving the mouse horizontally or vertically.

// At the base of all input is a GlobalActionMap where the bindings are defined which will be used throughout the program. 
// The GlobalActionMap's bindings cannot be overriden by other ActionMaps

// You can "push" to enable these other ActionMaps and "pop" to disable them
// This works almost as a layer system, that way when multiple ActionMaps specify commands to be triggered on an event
// The most recently pushed one will be the event triggered
// Multiple ActionMaps can be enabled at the same time and you can "bind" input commands to an ActionMap in one of three different ways

// The process of using an ActionMap is very simple:

// Create an ActionMap
// Bind a function to a device and an event
// Write the function that uses the input
// Push the ActionMap when you want to use it, pop it when you are done with it

// Create a new ActionMap for input binding
new ActionMap(moveMap);

// There are three different ways to bind a device to an event and have it call a function.

moveMap.bind(DEVICE, EVENT, COMMAND);
// or

moveMap.bindCmd(DEVICE, EVENT, MAKECMD, BREAKCMD);
// or

moveMap.bindObj(DEVICE, EVENT, COMMAND, OBJECT);

// The code samples above are a "template". For each input, you need to replace the DEVICE, EVENT, COMMAND, etc variables with the following:

// Device: keyboard, mouse0, touchdevice
// Event: "u"(as in, the u key is pressed), xaxis, touchdown, touchmove or touchup
// Command: A string that contains the name of the function you wish to call
// MakeCmd: A string that contains the name of the function you wish to call (i.e. key pressed)
// BreakCmd: A string that contains the name of the function you wish to call (i.e. key released)
// Object: The explicit object

// When you are ready to use the action map and its bindings, you need to push it to the system.

moveMap.push();

// If you need to disable the current input scheme, you can call the "pop" function to disable the action map
// This does not delete it, but it does stop capturing input

moveMap.pop();

// When you are ready to cleanup your game for a shutdown, you can delete the action map

moveMap.delete();

//============================.bind() Command=============================

// For keyboard events:

// Here keyboard is the device, the "u" key is the event, and toggleU is the name of the function we will call
moveMap.bind(keyboard, "u", toggleU);

// Now we need to define toggleU so our previous command will actually do something:

function toggleU(%val)
{
   if(%val)
   {
      echo("u key down");
   } else
   {
      echo("u key up");
   }
}

// One very important thing to note is that this toggleU function is set to receive a "%val" value
// This is very important, when using the .bind() command you must always set your functions up like this
// In the case of a key (like our "u" key example) the %val will only ever be 
// Either a 1 (representing the key was pressed) or a 0 (representing the key was released)
// As you can see we can separate the functionality with a simple if statement

// An non-key example of using .bind() would be this:

moveMap.bind(mouse0, "xaxis", horizontalMove);

// This time we aren't binding an event from the "keyboard", instead we chose "mouse0" which represents the first mouse (since T2D can handle input from multiple mice)
// The event we're binding is "xaxis" and we simply call a "horizontalMove" function
// The "xaxis" basically represents the mouse movement in the x-axis
// We can set up the horizontalMove function like this:

function horizontalMove(%val)
{
   echo("xaxis = " @ %val);   
}

//============================.bindCmd() Command==========================

// The .bindCmd() function works fairly similar to the bind() function, 
// Except instead of setting a single function to be called when the event is processed, you set two functions. 
// One will be called when the event is activated (on key down), while the other is activated when the event is broken (on key release
// In this case you don't pass just a "function" though; you pass a string that represents script to be run when you activate that event
// That means that you can pass a single line if you want to do a single script action, though generally you will simply pass a function call in a string
// You can set up the same "u" key like this:

moveMap.bindCmd(keyboard, "u", "onUDown();", "onUUp();");

// Notice we wrapped the functions in a string as well as making it a full script call to that function
// Now we can have one function do what needs to be done when the "u" key is pressed, while the other can do what is needed when the "u" key is released

function onUDown()
{
   echo("u key down");
}

function onUUp()
{
   echo("u key up");
}

//============================.bindObj() Command==========================

// This function follows the format of .bind() almost exactly, except that we have an extra value for the object we are assigning the bind to 
// A typical use for this is within behaviors:

function moveBehavior::onBehaviorAdd(%this)
{
   if (!isObject(moveMap))
      return;

   moveMap.bindObj(keyboard, "up", moveUp, %this);
   moveMap.bindObj(keyboard, "down", moveDown, %this);
   moveMap.bindObj(keyboard, "left", moveLeft, %this);
   moveMap.bindObj(keyboard, "right", moveRight, %this);

}

// Similar to .bind() is the toggle function that is required
// Again, we must pass a %val value to this function:

function moveBehavior::moveUp(%this, %val)
{
   %this.up = %val;

   echo(%this.up);
}

//============================Peripherals==================================

// You can use joysticks, gamepads, Xbox360 controllers, or the Leap Motion in your game by applying the same concepts as described above
// Just keep in mind there are a few small differences

// Note that the Windows implementation of gamepad support works correctly as it uses DirectInput
// Unfortunately, OSX support for gamepads is not fully implemented at this time

// During the initialization of your game code, make sure to add the following lines to your script files:

$enableDirectInput=true;
activateDirectInput();
enableJoystick();

// For the Xbox360 controller, add the following lines of script to the startup methods of your game code:

enableXinput();
$enableDirectInput=true;
activateDirectInput();

// All 4 Xinput controllers/devices are referred to in script as gamepad0, gamepad1, etc.

// When mapping axes (xaxis, yaxis, zaxis, sliders) to either a bind or bindObj function, the corresponding functions' %val will return a value between -x and +x
// x represents the maximum range of the control in either direction
// A %val of 0 means the stick is centered

// Triggers on an Xbox360 controller (or on other controllers which have "analog" triggers) are a special case.

// A %val of 0 means that both triggers are untouched.
// A %val of -x means the Left trigger is completely pressed down
// A %val of x means the Right trigger is completely pressed down

// Support for other platforms will be considered if we decide to port the game to them
// Until then, this is all you need to know

//============================End==========================================