function LordTestWizard::create( %this )
{
    // We need a main "Scene" we can use as our game world.  The place where sceneObjects play.
    // Give it a global name "wizScene" since we may want to access it directly in our scripts.
    new Scene(wizScene);

    // Without a system window or "Canvas", we can't see or interact with our scene.
    // AppCore initialized the Canvas already

    // Now that we have a Canvas, we need a viewport into the scene.
    // Give it a global name "wizWindow" since we may want to access it directly in our scripts.
    new SceneWindow(wizWindow);
    wizWindow.profile = new GuiControlProfile();
    Canvas.setContent(wizWindow);

    // Finally, connect our scene into the viewport (or sceneWindow).
    // Note that a viewport comes with a camera built-in.
    wizWindow.setScene(wizScene);
    wizWindow.setCameraPosition( 0, 0 );
    wizWindow.setCameraSize( 100, 75 );

    // load some scripts and variables
    // exec("./scripts/someScript.cs");
    exec("./scripts/wizWorld.cs");

    // buildAquarium(wizScene);
    // createAquariumEffects(wizScene);

    LordTestWizard.spawnLordTestWizard();
}

//-----------------------------------------------------------------------------

function LordTestWizard::destroy( %this )
{
}

//-----------------------------------------------------------------------------

function LordTestWizard::spawnLordTestWizard(%this)
{
    %anim = "AssetsMod:LordTestWizard_WalkWest";    
    %size = getWizardSize(%anim);

    %twiz = new Sprite()
    {
        Animation = %anim;
        class = "LordTestWizard";
        position = "0 0";
        size = %size;
        SceneLayer = "15";
        SceneGroup = "14";
        minSpeed = "5";
        maxSpeed = "15";
        CollisionCallback = true;
    };

    %twiz.createPolygonBoxCollisionShape(%size);
    %twiz.setCollisionShapeIsSensor(0, true);
    %twiz.setCollisionGroups( "15" );
    
    %controls = MovementControlsBehavior.createInstance();
    %twiz.addBehavior(%controls);      

    wizScene.add( %twiz ); 
}
