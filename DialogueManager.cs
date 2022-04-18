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
    private GameEvents _gameEvents;

    public override void _Ready()
    {
        _dialogText = GetNode<Label>(_dialogTextPath);
        _avatar = GetNode<TextureRect>(_avatarPath);
        // todo: this breaks if the fs is changed, should I just attach a reference of the script on the editor(?)
        _gameEvents = GetNode<GameEvents>("/root/GameEvents");
        _gameEvents.Connect(nameof(GameEvents.DialogInitiated), this, nameof(_OnDialogInitiated));

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

    private void _OnDialogInitiated(Dialogue dialogue)
    {
        _currentDialogueTres = dialogue;
        this.Visible = true;
        _currentSlideIndex = 0;
        _avatar.Texture = dialogue.AvatarTexture;
        ShowSlide();
    }
}
