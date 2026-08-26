using Godot;
using System;

public partial class MapContext : Node2D, IContext
{
    Cursor cursor;
    Vector2 currentCursorPosition;

    TerrainTile[,] terrainTiles = TerrainTile.CreateMapOfSize(255, 255);
    Unit[] units = new Unit[255];

    UnitsPanel unitsPanel;

    TerrainInfoPanel terrainInfoPanel;

    Unit selectedUnit;
    Vector2I selectedPosition;
    byte selectedUnitID;

    Label selectedUnitLabel;

    string[] class_names = {"null", "exorcist", "PALADIN", "citizen"}; 


    public override void _Ready()
    {
        cursor = GetNodeOrNull<Cursor>("cursor");

        selectedUnitLabel = GetNodeOrNull<Label>("Panel2/Label");
        terrainInfoPanel = GetNodeOrNull<TerrainInfoPanel>("TerrainInfoPanel");
        unitsPanel = GetNodeOrNull<UnitsPanel>("UnitsPanel");

        string[] a = {"Mara", "Sonia", "Bartholomew"};

        for (byte i = 1; i < 4; i++)
        {
            string name = a[i - 1];

            units[i] = new Unit(i, name, Unit.CHR_CLASS.EXORCIST);

            terrainTiles[i, 0].unitID = i;
            unitsPanel.AddUnit(units[i]);

            MapUnit mapUnit = GD.Load<PackedScene>("uid://xvqt462vk3av").Instantiate<MapUnit>();
            mapUnit.Setup(units[i]);
            mapUnit.GlobalPosition = new Vector2(i, 0) * Game.GRID_SIZE;

            AddChild(mapUnit);
        }

    }

    public Unit GetUnitByGridPosition(int X, int Y)
    {
        return units[terrainTiles[X, Y].unitID];
    }

    public Vector2I GetGridwisePosition(Vector2 position)
    {
        return (Vector2I) position.Snapped(Game.GRID_SIZE) / Game.GRID_SIZE;
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);

        if (@event is InputEventMouseMotion inputEventMouseMotion)
        {
            cursor.MoveTo(inputEventMouseMotion.Position);
            
            Vector2I hoverPosition = GetGridwisePosition(cursor.GlobalPosition);

            byte hoveringUnitID = terrainTiles[hoverPosition.X,hoverPosition.Y].unitID;
            Unit unit = GetUnitByGridPosition(hoverPosition.X, hoverPosition.Y);

            terrainInfoPanel.updateText(unit, hoveringUnitID);

        }

        if (@event.IsActionPressed("mapSelect"))
        {

            Vector2I oldSelectedPosition = selectedPosition;
            selectedPosition = GetGridwisePosition(currentCursorPosition);
            selectedUnit = GetUnitByGridPosition(selectedPosition.X, selectedPosition.Y);

            selectedUnitLabel.Text = selectedUnit.name;
        }

        if (@event.IsActionPressed("escapeToOptions"))
        {
            
        }


    }

    public void Prioritize()
    {
        throw new NotImplementedException();
    }

    public void Deprioritize()
    {
        throw new NotImplementedException();
    }
}
