//============================Top==========================================

// This guide will familiarize you with the Torque engine

//============================Interlopers Executable==================

// First, let's discuss The Interloper War executable (interlopers.exe)
// interlopers.exe is a compiled binary written in C++
// Before it was compiled, it was a collection of folders and scripts, just like our modules are now
// The .exe was compiled from a Windows binary using VisualStudio 2013 Professional
// The C++ scripts inherent to the engine and the and the icon we see are what is packaged into the exe when it is compiled
// At the end of development, we will recompile the engine with a new icon and encrypt our files so they can't be modified
// The recompiled and encrypted engine will be what is released to customers

//============================Execution====================================

// When the interlopers.exe is run it takes these steps:
// First the video is initialized through OpenGL, this is how the game window is brought up
// During this initialization, OpenGL detects the appropriate settings for our computer and automatically sets up video for us
// Then the .exe reads the main.cs file in the root directory of the game

//============================main.cs======================================

// The root main.cs file typically contains debug options that can be toggled on or off to aid with development
// Then, the main.cs file calls to scan the modules folder and make a note of every module within
// Then it explicitly loads the AppCore module, which is the core of our application (hence its name)

//============================AppCore======================================

// When the root main.cs calls for the AppCore module to be loaded, first its module.taml file is checked to see if it has any dependencies
// If it is dependent on any other modules, those will be loaded
// Then the main.cs file of AppCore is executed
// First the main.cs initializes all necessary system scripts
// Then it initializes the canvas and sets its color
// Audio is initialized through OpenAL, and it sets itself up in the same way as OpenGL to give us audio
// All modules and their dependencies in group gameBase are loaded
// If the game has any mods (modifications), those are loaded explicitly along with their dependencies (if any)

//============================Concept======================================

// You may have noticed the concept folder in the root directory of the game
// This is basically the idea folder
// New concepts that we want to add to the game will be kept there
// You may add pictures to inspire visual aspects of the game
// You may add audio files to inspire the sounds of the game
// You may add music to inspire the soundtrack for the game
// You may add text documents to describe plot aspects you may want to include
// Always keep track of exactly where you get the files you add to your concept folder
// This way we can credit the necessary artists when the game is released
// Ideas may or may not be added to the game depending on whether it is relevant, practical, or possible
// Any ideas that will not be added, will be removed from the concept folder
// Everybody on the team should have their own subdirectory in the concept folder labelled by their username
// Before a concept is added to the game, a majority of members must agree on it
// In special circumstances, the producer can override all votes and choose to include or not include concepts
// Take the time to look through concept/ceigemaster to get some ideas of things that might be in the game

//============================Tutorials====================================

// You should know what this folder is for
// Only the producer should change this folder, unless otherwise specified

//============================credits.txt======================================

// Everybody's name and position will be in here, giving everyone credit for their work
// If we use a third party's work, they will receive special thanks here too

//============================LICENSE.md===================================

// License information for our product
// Basically anybody can do whatever they want with our product
// Due to the licensing of our product, if we want to keep its integrity we will encrypt the engine and find a way to keep it from being copied for free
// Perhaps each game could somehow be given a unique ID and no two games of the same ID could connect to the server
// We would have to be sneaky and do the product ID check in the start up of the program
// Determined people could probably still decrypt the engine, alter it, and distribute it
// But these fail-safes should deter the majority of people
// However, we are not extortionists, I do want to give people a way to legitimately get the game for free
// Perhaps if they contribute in a meaningful way to the game community they could receive a free copy
// This would work especially well since it could keep people from trying to decrypt the engine at all
// It would be much easier for them to use that knowledge to contribute to the game community and legitimately get the game
// Or perhaps we could make the mods (modifications) require purchase and make the game free to play
// Or we could do in-app purchases
// This will all be decided at a later stage in development
// Note that the .md format is for compatibility with Github, which will be discussed later

//============================README.md==============================

// This should tell the user where the game originated from, who made it,
// What to do if they have problems, and version updates
// Note that this is currently unfinished, will be completed later

//============================.github/.gitattributes======================================

// Depending on whether your explorer is set to see hidden files or not, you may have noticed .github/.gitattributes
// .github is a file that tells Github which files/folders to ignore for pushing new versions of the game to Github
// .gitattributes controls the attributes for certain file types

//============================OpenAL32.dll=================================

// This is the Dynamin Link Library (.dll) that handles OpenAL in Windows

//============================unicows.dll==================================

// Contrary to popular belief, it has nothing to do with cows
// It is the UNICOde Windows System, and allows Windows users to read Unicode
// Windows systems XP and later can already read Unicode
// This is here mostly for compatibility with older systems

//============================Github=======================================

// Github is where we host our game and a vanilla copy of our game engine
// Whenever you finish an update to the game, you should "commit" it to Github
// This announces to the servers, that you intend to upload files
// Then, click publish and sync your repositories afterwards
// Whenever you need an update another member has done (simply for peer review, or actual module dependency)
// You should open Github and click sync
// Issues with our code should be reported in the Issues section of our Github home page
// In the process of making this game, we may discover bugs that are not the result of our own error, but inherent to the Torque engine
// This issue should be posted in the Issues section of our fork of the Torque2D engine repository
// All relevant current issues known about the Torque2D engine have been copied from the Master Torque2D repository and reported in our fork
// I am currently watching the issues to see if they resolve themselves
// If they don't, we will have to fix them eventually
// All confirmed bugs are marked as "bug" in the Issues page
// You can choose to host a local vanilla copy of the Torque2D engine along with our game if you so choose

//============================Stages of Development========================

// When you update the engine by committing it to Github, make sure to put the stage of development and the version number
// There are seven possibles stages of development
// Pre-Alpha - This is the phase where I compiled the engine and then set it up to start development
// Alpha - Our current phase, this is where we build the actual game
// Beta - Once the game is considered playable, we will open it to Beta testing
    // Beta testing is the stage where we open it to the public for willing testers to help us find bugs
    // There are two types of beta testing: open beta and closed beta
    // Open beta is open to the public and anyone can test it
    // Closed beta only has a select group of testers
// Release Candidate - this is the version that has the potential to be the final product (unless significant bugs arise)
// Release to Web (RTW) - this means the game is open to customers, however patches or mods may be released to update the game
// Release to Manufacturing (RTM) - We may not use this, however we could potentially package the game on a CD with mods as a deal
// General Availability (GA) - This comes after the RTM stage, where we are ready to sell the physical medium to the public

//============================Version Numbering============================

// Version numbering is listed after the stages to indicate the progress within the current stage and towards the next stage
// The format goes like this: X.Y.Z
// Where X indicates a major update to the game
// Y indicates a minor update to the game
// And Z indicates a patch

//============================Commit Format================================

// When you commit to Github using the Windows Github program, you will notice it asks for a summary and a description
// In summary, the format should be: Stage X.Y.Z
// For example: Alpha 1.1.0
// The description should contain the details for the changes to the game

//============================Github Wiki==================================

// We also have a Wiki on our Github page
// We will update this as we add new game content
// Information specifically related to the game engine should not be put here
// It should look like any other Wiki for a video game you may have seen

//============================VisualStudio=================================

// Currently we use VisualStudio in our TorqueScript coding
// All .cs files should be opened here
// We can also use VisualStudio to create projects, which will be saved as .sln (solution) files
// VisualStudio is also necessary to recompile and encrypt our engine for consumer releases
// We can also use it to edit .taml and .gui.taml files
// Remember TAML is a different language than TorqueScript, however TAML is simple to use
// A guide on TAML will be included later when it is relevant// It has many other uses that I have yet to explore
// This tutorial will be updated later for those uses
// For now, this is all you need to know

//============================progress.txt=================================

// This should be updated whenever you make changes to anything
// This is for everybody's reference
// The format should be pretty clear, please follow it

//============================console.log==================================

// This is created by the engine whenever it runs
// It keeps track of everything that is passed into the console during an execution
// This is useful to read through if you want to see where something went wrong

//============================Torque2d.xsd=================================

// This is called a schema file, VisualStudio uses it
// It helps correct errors in TAML coding
// VisualStudio reads from it for comparison when it checks your work

// Now you should be pretty familiar with the engine, how it runs, and the different parts of it

//============================End==========================================