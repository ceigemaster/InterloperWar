function MainMenu::create( %this )
{    
    // Adds the dialog file that introduces the "New Game" and "Quit Game" buttons
    MainMenu.add( TamlRead("./gui/MenuDialog.gui.taml") );
    // Brings up the Main Menu on the canvas
    Canvas.pushDialog(MenuDialog);

    // Adds the dialog file that introduces the "Options" menu
    MainMenu.add( TamlRead("./gui/OptionsDialog.gui.taml") );
}

function MainMenu::destroy( %this )
{
}

// Adding command for NewGameButton
// This says that the function will be executed upon the mouse left click of this button
function NewGameButton::onClick(%this)
{
    // This removes the previous Menu (the MainMenu) from the canvas
    Canvas.popDialog(MenuDialog);
    // This brings up the Options Menu on the canvas
    Canvas.pushDialog(OptionsDialog);
}

// Adding command for QuitButton
// This says that the function will be executed upon the mouse left click of this button
function QuitButton::onClick(%this)
{
    // This quits the game
    quit();
}

// Adding command for StartGameButton.
// This says that the function will be executed upon the mouse left click of this button
function StartGameButton::onClick(%this)
{
    // This group doesn't exist, just here for example.
    // We could load up a group this way to start the game.
    ModuleDatabase.loadGroup("gameInit");
    // Removes the Options Menu from the canvas
    Canvas.popDialog(OptionsDialog);
}

// Adding command for DebugButton.
// This says that the function will be executed upon the mouse left click of this button
function DebugButton::onClick(%this)
{
    // Loads the debug group for debugging
    ModuleDatabase.loadGroup("debug");
    // Removes the Options Menu from the canvas
    Canvas.popDialog(OptionsDialog);
}

// Adding command for MainMenuButton.
// This says that the function will be executed upon the mouse left click of this button
function MainMenuButton::onClick(%this)
{
    // Removes the Options Menu from the canvas
    Canvas.popDialog(OptionsDialog);
    // Brings the Main Menu back onto the canvas
    Canvas.pushDialog(MenuDialog);
}