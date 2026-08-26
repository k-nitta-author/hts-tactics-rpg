using Godot;

public partial class WalkaroundStage : Node2D
{
    
    TileMapLayer tilemapLayer;

    public override void _Ready()
    {
        tilemapLayer = GetNodeOrNull<TileMapLayer>("tilemapLayer");
    }

}
