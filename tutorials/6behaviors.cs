//============================Top==========================================

// A behavior is similar to a class, it has a definition with methods and fields
// However, several behaviors can be “attached” to one game object
// Ideally, each behavior handles one aspect of a game object's state independent of the other behaviors

// Games tend to be made of many objects each interacting with each other in similar but different ways
// For example, many objects will probably move, fight, take injuries, make sounds, model health loss, etc
// Each of these concepts are relatively separate from the others
// Each could be an individual behavior instead of a chunk of functions within one big class

// Otherwise, before you know it, a class that represents an object can become quite bloated with features
// And for each new object that is pretty similar to others, there is a tendency to share the same class but with subtle differences tracing throughout the code 
// Think of a behavior as a way to take one slice of this functionality and keep it self-contained

//============================Theory=======================================

// To put this as an example, think of it like this:

// Games have "entities", objects on the screen that are visible to the player
// They could be things like rockets, a tank, a car, the hero, a gun, a rock, a grenade, an alien, or a pedestrian
// You want these objects to do different things, like run a script, move, be targeted by the player, react as a rigid body, be worn by the player, and animate
// To organize our thought process so far, it might look like this:

// run a script: hero, alien, pedestrian, tank, car
// move: hero, pedestrian, tank, car, alien
// be targeted: pedestrian, alien
// rigid body: grenade, rock
// be worn: gun, rockets
// animate: alien, pedestrian, tank, car, hero

// Note that some of these entities will share the same functions, but not all entities will have all functions
// Unfortunately, most developers' solution to these is to implement this in a hierarchal manner
// Suppose we set it up like this:

/*
    Entity
        Moveable
            Car
            Tank
        Human
            Hero
            Pedestrian
            Alien
        Rigid
            Rock
            Grenade
*/

// In this hierarchy, functions that need to be shared are applied to a parent object of the child objects
// For example, both cars and tanks need to move, so they are made child objects of Moveable
// Then, the functions related to movement are given to the Moveable parent object, thus all of its children share the same quality
// There may be some things that all entities need to do, thus the functions will be given to the Entity parent
// This may seem efficient now, but as many more parent and child objects are created, this system becomes bloated
// Cars and tanks are different, and a car may not need all of the added functionality that we are giving to the tank


// This is why we will use behaviors
// Using behaviors whenever we create a new object, it will be as simple as attaching existing behaviors to it and maybe even creating a unique behavior or two


//============================Behavior Creation============================

// Below is an example of the syntax a created behavior should follow:

// Note that this is not a function, rather a global if-then statement
// When the script is run, the if-then statement will immediately execute
// !isObject (ShooterControlsBehavior) asks if an instance of ShooterControlsBehavior has not yet been created
// not the ! (not) operator, so !isObject "object is NOT created"
// If it has, this block of code will be skipped over
// This is a sanity measure to protect the BehaviorTemplate from being overwritten
// It is considered standard to protect all BehaviorTemplates with if-then statements
if (!isObject(ShooterControlsBehavior))
    {
        // Here we create a new BehaviorTemplate called ShooterControlsBehavior and store it in the %template variable
        // A behavior template is similar to a class definition
        %template = new BehaviorTemplate(ShooterControlsBehavior);

        // These fields are simply for documentation and are self-explanatory
        // They do not affect how we can use the behaviors we define
        %template.friendlyName = "Shooter Controls";
        %template.behaviorType = "Input";
        %template.description  = "Shooter style movement control";

        // .addBehaviorField, logically, adds new fields to our behavior, which is stored in our %template variable
        // upKey is the name of the field that will be created for the behavior
        // The following string is simply a description
        // The third parameter defines the type of field, which is set here to be a keybind field
        // The fourth parameter is the default value
        %template.addBehaviorField(upKey, "Key to bind to upward movement", keybind, "keyboard up");
        %template.addBehaviorField(downKey, "Key to bind to downward movement", keybind, "keyboard down");
        %template.addBehaviorField(leftKey, "Key to bind to left movement", keybind, "keyboard left");
        %template.addBehaviorField(rightKey, "Key to bind to right movement", keybind, "keyboard right");

        %template.addBehaviorField(verticalSpeed, "Speed when moving vertically", float, 20.0);
        %template.addBehaviorField(horizontalSpeed, "Speed when moving horizontally", float, 20.0);
    }

// Technically, there is another way we could do this
// We could first define a new BehaviorTemplate protected by an if-then statement without defining any BehaviorFields:

if (!isObject (ShooterControlsBehavior))
    { %template = new BehaviorTemplate(ShooterControlsBehavior); }

// Then, when we later create an instance of it, we could define its fields then:

// This creates an instance of our previously defined behavior and assigns it to the %controls variable
%controls = ShooterControlsBehavior.createInstance();
// This passes the parameter to set which key is bound to the upKey field of the %controls variable
%controls.upKey = "keyboard w";
// This passes the parameter to set which key is bound to the downKey field of the %controls variable
%controls.downKey = "keyboard s";
// This passes the parameter to set which key is bound to the leftKey field of the %controls variable
%controls.leftKey = "keyboard A";
// This passes the parameter to set which key is bound to the rightKey field of the %controls variable
%controls.rightKey = "keyboard D";
// After the parameters have been set, we can attach the behavior to the object of our choosing
%obj.addBehavior(%controls);

// However, the problem with this is that we will have to pass the parameters each time we want to create a new instance of this behavior
// It is much easier to just fully define the behavior and save ourselves time later

// Remember in the last tutorial, we covered the .bindObj() command
// Since we are using keyboard controls to demonstrate the use of behaviors, we will have to use this command:

function ShooterControlsBehavior::onBehaviorAdd(%this)
{
    if (!isObject(GlobalActionMap))
       // Return value for debugging
       return;

       // Remember the syntax for .bindObj is: .bindObj(DEVICE, EVENT, COMMAND, OBJECT)
       // Here, we use getWord() to use the same values we put in from the behavior we defined
       // This is useful in that we could change the default values in the behavior and this function would still work correctly, as it grabs the values directly from the behavior
       // Here moveUp will be the command that it run (which we will define later)
       // %this is the object that we are attaching this ActionMap to
    GlobalActionMap.bindObj(getWord(%this.upKey, 0), getWord(%this.upKey, 1), "moveUp", %this);
    GlobalActionMap.bindObj(getWord(%this.downKey, 0), getWord(%this.downKey, 1), "moveDown", %this);
    GlobalActionMap.bindObj(getWord(%this.leftKey, 0), getWord(%this.leftKey, 1), "moveLeft", %this);
    GlobalActionMap.bindObj(getWord(%this.rightKey, 0), getWord(%this.rightKey, 1), "moveRight", %this);

    // Here we will set the default values for these variables
    %this.up = 0;
    %this.down = 0;
    %this.left = 0;
    %this.right = 0;
}

//============================.owner Field=================================

// Behaviors have methods and fields for themselves, as we've seen previously
// Behaviors can also take advantage of the methods and fields of the object they are attached to
// We do this by defining the .owner field in the behavior's definition

// We will continue to build upon our script that we have for assigning controls:

// Here we will define a method (updateMovement) for use with the ShooterControlsBehavior behavior
function ShooterControlsBehavior::updateMovement(%this)
    {
    	// We define a variable (%flip) and set up this equation to work with our next method
    	// Basically, this will return true if we move left, and false if we move right
        %flip = %this.right - %this.left < 0;
        // .setFlipX controls whether our object is flipped horizontally or not, 1 = true, 0 = false
        %this.owner.setFlipX(%flip);
        // LinearVelocityX determines how fast the object moves along the X-Axis
        // This is determined by subtracting the value of %this.left from %this.right and multiplying the result by %this.horizontalSpeed (which we defined earlier)
        %this.owner.setLinearVelocityX((%this.right - %this.left) * %this.horizontalSpeed);
        // LinearVelocityY determines how fast the object moves along the Y-Axis
        // This is determined by subtracting the value of %this.down from %this.up and multiplying the result by %this.verticalSpeed (which we defined earlier)
        %this.owner.setLinearVelocityY((%this.up - %this.down) * %this.verticalSpeed);
    }
  
// Note that we use the .owner method, that means the methods we define after it (.owner.setFlipX) actually belong to the object the behavior is attached to
// Now we will create four separate methods that use the updateMovement method to set the orientation of the object, its movement speed, and direction of movement
function ShooterControlsBehavior::moveUp(%this, %val)
{
    // Here we set %this.up equal the the value of %val
    // %val will be 1 if we press the up key
    %this.up = %val;
    // Update the movement sprite accordingly
    %this.updateMovement();
}

function ShooterControlsBehavior::moveDown(%this, %val)
{
    // Here we set %this.down equal the the value of %val
    // %val will be 1 if we press the down key
    %this.down = %val;
    %this.updateMovement();
}

function ShooterControlsBehavior::moveLeft(%this, %val)
{
    // Here we set %this.left equal the the value of %val
    // %val will be 1 if we press the left key
    %this.left = %val;
    %this.updateMovement();
}

function ShooterControlsBehavior::moveRight(%this, %val)
{
    // Here we set %this.right equal the the value of %val
    // %val will be 1 if we press the right key
    %this.right = %val;
    %this.updateMovement();
}

//============================Behavior Communication=======================

// Behaviors can not only communicate information to its owner, but also to other behaviors attached to the owner
// Note that if we were to pass any command to the .owner, any behavior running afterwards could also take advantage of that information

// With that in mind, that should be all you need to know about behaviors and how they work!

//============================End==========================================
