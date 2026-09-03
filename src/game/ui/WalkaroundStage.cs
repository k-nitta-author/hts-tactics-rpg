using Godot;

public partial class WalkaroundStage : Node2D, IStage
{
    
    TileMapLayer tilemapLayer;
    WalkaroundPlayer walkaroundPlayer;

    public override void _Ready()
    {
        tilemapLayer = GetNodeOrNull<TileMapLayer>("tilemapLayer");
    }

}
