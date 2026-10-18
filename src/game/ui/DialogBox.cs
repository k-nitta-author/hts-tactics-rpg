using System;
using Godot;

public partial class DialogBox : Control
{
    RichTextLabel body;
    AnimationPlayer anim;
    Label header;
    AudioStreamPlayer typingSound;

    [Export]
    float perCharacterSpeed;
    bool IsTyping;
    int CurrentIdx;

    Tween tween;
    DialogItem[] dialogItems;

    public override void _Ready()
    {
        body = GetNodeOrNull<RichTextLabel>("body");
        header = GetNodeOrNull<Label>("header");
        typingSound = GetNodeOrNull<AudioStreamPlayer>("typingSound");
        anim = GetNodeOrNull<AnimationPlayer>("anim");
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed("generalInteract"))
        {
            if (IsTyping)
            {
                Skip();
            }

            else
            {
                CurrentIdx++;

                DialogItem di = NextDialog(dialogItems, CurrentIdx);

                UpdateToNextDialog(di);
            }
        }

        if (@event.IsActionPressed("pause"))
        {
            Conceal();
        }
    }

    public void AddDialogItems(DialogItem[] dialogItems)
    {
        this.dialogItems = dialogItems;
    }

    void Skip()
    {
        tween.Stop();
        IsTyping = false;
        body.VisibleRatio = 1.0f;
    }

    void Cleanup()
    {
        dialogItems = null;
        CurrentIdx = 0;

        header.Text = "";
        body.Text = "";
        body.VisibleRatio = 0.0f;
    }

    void Conceal()
    {
        Cleanup();
        Hide();
    }

    void Display()
    {
        Show();
    }

    DialogItem NextDialog(DialogItem[] dialogItems, int idx)
    {
        return dialogItems[idx];
    }

    void UpdateToNextDialog(DialogItem dialogItem)
    {
        float dialog_duration = dialogItem.BodyText.Length * perCharacterSpeed;

        header.Text = dialogItem.HeaderText;
        body.Text = dialogItem.BodyText;
        body.VisibleRatio = 0.0f;

        tween = GetTree().CreateTween();

        tween.Finished += () =>
        {
            IsTyping = false;
        };

        IsTyping = true;
    }

}
