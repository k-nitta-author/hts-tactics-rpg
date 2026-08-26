using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;

public struct TerrainTile
{

    enum TerrainType
    {
        GRASS,
        WOODS,

    }

    byte positionX;
    byte positionY;

    public byte unitID; //  the idx of the given unit on the tile.

    public void t()
    {
        Graph<int, string> g = new Graph<int, string>();

        g.AddNode(1);
        g.AddNode(2);
        g.Connect(1, 2, 5, "t");

        ShortestPathResult r = g.Dijkstra(1, 2);
    }

    public static void MoveUnit(TerrainTile oldTerrainTile, TerrainTile newTerrainTile)
    {
        oldTerrainTile.unitID = newTerrainTile.unitID;
        newTerrainTile.unitID = oldTerrainTile.unitID;
    }

    public static TerrainTile[,] CreateMapOfSize(byte sizeX, byte sizeY){return new TerrainTile[sizeX, sizeY];}

}