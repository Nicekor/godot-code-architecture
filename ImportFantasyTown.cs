using Godot;
using System;

// run in the editor/not at runtime
[Tool]
public class ImportFantasyTown : EditorScenePostImport
{
    public override Godot.Object PostImport(Godot.Object scene)
    {
        
        Spatial spatialScene = scene as Spatial;
        MeshInstance mesh = (spatialScene.GetChild(0).GetChild(0)) as MeshInstance;
        mesh.CreateTrimeshCollision();
        return scene;
    }
}
