using Godot;
using Godot.Collections;

public partial class Game : Node2D
{
    public static int GRID_SIZE => 16;

    [Export] Vector2I mapSize { get { return _mapSize; } set { _mapSize = value; } }
    private Vector2I _mapSize;

    private StartScreen startScreen;

    [Export] bool skipStartScreen;

    IContext currentContext;

    public override void _Ready()
    {
        if (skipStartScreen) { return; }

        startScreen = GD.Load<PackedScene>("uid://dobs7g5vxgsbu").Instantiate<StartScreen>();
        AddChild(startScreen);
        startScreen.CallDeferred("Setup", this);   
    }


    public void StartGame()
    {
        startScreen.CallDeferred("queue_free");
    }

    public void LoadGame()
    {

    }

    public void ShowSettings()
    {

    }

    public void EndGame()
    {
        GetTree().Quit();
    }

}
