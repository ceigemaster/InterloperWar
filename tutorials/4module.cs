//============================Top==========================================

// This tutorial will give you a more in-depth look into how how modules are made and the basic structure a script should take

//============================Folder Structure=============================

// All new modules should be created in the module folder
/* The structure should be as follows:
    modulefolder: the folder that contains the module
        -versionnumber: different version of modules should be housed in separate folders
                        version numbering for modules should work the same as version numbering for the game
                        this allows you to roll back to an earlier module should a major change cause something to go wrong
            -fonts: contains fonts for use in the game
            -assets: contains all the assets to be used in the game
                -gui: contains the assets specifically related to the gui
                -animations: contains the assets specifically related to animation
                -audio: contains audio assets
                -images: contains image assets
                -particles: contains particle assets
            -gui: contains anything related to gui, note that this is deprecated thanks to AssetsMod, just keep things in the assets folder
                -images
            -scripts: contains all scripts that aren't the main.cs script
            -main.cs: the script that is called when a module is loaded
            -module.taml: the TAML file that defines a module
*/

// You might create a module that does not use fonts, or add any new gui elements
// In this case, you do not need to add the folders, this is just to cover where folders should go if they need to be added
// Console and MainMenu use deprecated folder structures, but they will remain the same
// This is because they are initialized before AssetsMod
// Since the introduction of AssetsMod, our assets are handled completely by it

//============================TAML creation================================

// TAML (Torque Application Mark-up Language) files define the module to the game engine, without it, the engine will not be able to find the module
// Here is an example of how a module.taml file should be formatted:

// <ModuleDefinition is the opening tag to define the module
<ModuleDefinition
    // ModuleId is the variable that tells the game engine what the name of the module is
	ModuleId="Console"
    // VersionId tells the game engine what version this module is
	VersionId="1"
    // Dependencies lists all the modules this one is dependent on
	Dependencies="AppCore=1"
    // Group defines the group that module belongs to, these are the groups that are referred to when ModuleDatabase.loadGroup() is called
    Group="gameBase"
    // Description provides the description for the module
	Description="A console GUI for general debugging."
    // ScriptFile defines the name of the main script that the TAML file will look for to start the module
	ScriptFile="main.cs"
    // CreateFunction defines the name of the function that decides what runs when the module is created
	CreateFunction="create"
    // DestroyFunction defines the name of the function that decides what runs when the module is destroyed
	DestroyFunction="destroy">
        // Declares that this module uses assets and provides the details for said assets
		<DeclaredAssets
            // Defines the path that the assets are contained in
			Path="assets"
            // Defines the extension that asset files will used
			Extension="asset.taml"
            // Recurse tells the engine to search all subfolders of the assets folder to find assets
			Recurse="true"/>
// This is the closing tag for the Module Definition
</ModuleDefinition>

// There are many more things you can do with TAML, but this will be discussed in a later guide

//============================main.cs Creation=============================

// The main.cs script defines what you really want to do with the script, so each one will follow a different pattern
// However, there are two things you must always put in a script:

// This is the create function we defined in the module definition
// Note that if we had named the function "tarzan" the format would be "function MyModule::tarzan (%this)
// %this is the parameter we are passing to the create function, this tells the engine by what variable name to store the module

function MyModule::create( %this )
{
    // When the module is loaded, everything in these brackets will be run
}
// %this is the parameter we are passing to the destroy function, the parameter is the same variable name we stored the module in
// Note that %this is a local variable, meaning outside of this script, %this has no value
// This keeps the engine from overwriting the %this variables in other scripts that the module uses to refer to itself
function MyModule::destroy( %this )
{
    // When the module is unloaded, everything in these brackets will be run
}

// Note that the function is not globally defined, so we could not call it like this:

function create()
{
}

// This is because the create/destroy function would be overwritten every time a new module was loaded

// The module system is actually much more advanced than this, but this is all we will cover for now
// Now you should know how to create a new module!

//============================End==========================================