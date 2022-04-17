using Godot;
using System;

public class Dialogue : Resource
{
    [Export]
    public Texture AvatarTexture;

    [Export(PropertyHint.MultilineText)]
    public string[] DialogueSlides;
}
