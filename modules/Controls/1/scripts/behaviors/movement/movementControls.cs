//-----------------------------------------------------------------------------
// Copyright (c) 2013 GarageGames, LLC
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------

if (!isObject(MovementControlsBehavior))
{
    %template = new BehaviorTemplate(MovementControlsBehavior);

    %template.friendlyName = "Movement Controls";
    %template.behaviorType = "Input";
    %template.description  = "Defines the controls for movement";

    %template.addBehaviorField(upKey, "Key to bind to upward movement", keybind, "keyboard up");
    %template.addBehaviorField(downKey, "Key to bind to downward movement", keybind, "keyboard down");
    %template.addBehaviorField(leftKey, "Key to bind to left movement", keybind, "keyboard left");
    %template.addBehaviorField(rightKey, "Key to bind to right movement", keybind, "keyboard right");

    %template.addBehaviorField(verticalSpeed, "Speed when moving vertically", float, 20.0);
    %template.addBehaviorField(horizontalSpeed, "Speed when moving horizontally", float, 20.0);
}

function MovementControlsBehavior::onBehaviorAdd(%this)
{
    if (!isObject(GlobalActionMap))
       return;

    GlobalActionMap.bindObj(getWord(%this.upKey, 0), getWord(%this.upKey, 1), "moveUp", %this);
    GlobalActionMap.bindObj(getWord(%this.downKey, 0), getWord(%this.downKey, 1), "moveDown", %this);
    GlobalActionMap.bindObj(getWord(%this.leftKey, 0), getWord(%this.leftKey, 1), "moveLeft", %this);
    GlobalActionMap.bindObj(getWord(%this.rightKey, 0), getWord(%this.rightKey, 1), "moveRight", %this);

    %this.up = 0;
    %this.down = 0;
    %this.left = 0;
    %this.right = 0;
}

function MovementControlsBehavior::onBehaviorRemove(%this)
{
    if (!isObject(GlobalActionMap))
       return;

    //%this.owner.disableUpdateCallback();

    GlobalActionMap.unbindObj(getWord(%this.upKey, 0), getWord(%this.upKey, 1), %this);
    GlobalActionMap.unbindObj(getWord(%this.downKey, 0), getWord(%this.downKey, 1), %this);
    GlobalActionMap.unbindObj(getWord(%this.leftKey, 0), getWord(%this.leftKey, 1), %this);
    GlobalActionMap.unbindObj(getWord(%this.rightKey, 0), getWord(%this.rightKey, 1), %this);

    %this.up = 0;
    %this.down = 0;
    %this.left = 0;
    %this.right = 0;
}

function MovementControlsBehavior::updateMovement(%this)
{
    %this.owner.setLinearVelocityX((%this.right - %this.left) * %this.horizontalSpeed);
    %this.owner.setLinearVelocityY((%this.up - %this.down) * %this.verticalSpeed);
}

function MovementControlsBehavior::moveUp(%this, %val)
{
    %this.up = %val;
    %this.updateMovement();
}

function MovementControlsBehavior::moveDown(%this, %val)
{
    %this.down = %val;
    %this.updateMovement();
}

function MovementControlsBehavior::moveLeft(%this, %val)
{
    %this.left = %val;
    %this.updateMovement();
}

function MovementControlsBehavior::moveRight(%this, %val)
{
    %this.right = %val;
    %this.updateMovement();
}
