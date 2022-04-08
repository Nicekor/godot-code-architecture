using Godot;
using System;

public class Dialogue : Resource
{
    [Export]
    public Texture avatarTexture;

    [Export(PropertyHint.MultilineText)]
    public string[] dialogueSlides;

    
}
