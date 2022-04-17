using Godot;
using System;

public class DialogueManager : Control
{
    [Export]
    private NodePath _dialogTextPath;
    [Export]
    private NodePath _avatarPath;
    [Export]
    private Resource _currentDialogueTres;

    private Label _dialogText;
    private TextureRect _avatar;
    private int _currentSlideIndex = 0;

    public override void _Ready()
    {
        _dialogText = GetNode<Label>(_dialogTextPath);
        _avatar = GetNode<TextureRect>(_avatarPath);

        if (_currentDialogueTres is Dialogue dialogue)
        {
            _avatar.Texture = dialogue.AvatarTexture;
            ShowSlide();
        }
    }

    public override void _Input(InputEvent evt)
    {
        if (Input.IsActionJustPressed("advance_slide") && _currentDialogueTres is Dialogue dialogue)
        {
            if (_currentSlideIndex >= dialogue.DialogueSlides.Length - 1)
            {
                this.Visible = false;
                return;
            }
            _currentSlideIndex++;
            ShowSlide();

        }
    }

    private void ShowSlide()
    {
        if (_currentDialogueTres is Dialogue dialogue)
        {
            _dialogText.Text = dialogue.DialogueSlides[_currentSlideIndex];
        }
    }
}
