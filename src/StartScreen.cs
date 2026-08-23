using System;
using Godot;
public partial class StartScreen : Control
{
    private Button startButton;
    private Button loadButton;
    private Button settingsButton;
    private Button quitButton;
    private Button creditsButton;

    public override void _Ready()
    {
        base._Ready();
        startButton = GetNodeOrNull<Button>("startButton");
        loadButton = GetNodeOrNull<Button>("loadButton");
        settingsButton = GetNodeOrNull<Button>("settingsButton");
        creditsButton = GetNodeOrNull<Button>("creditsButton");
        quitButton = GetNodeOrNull<Button>("quitButton");
    }


    public void Setup(Game game)
    {
        startButton.Pressed += game.StartGame;
        loadButton.Pressed += game.LoadGame;
        //settingsButton.Pressed += game.ShowSettings;
        quitButton.Pressed += game.EndGame;
    }
}
