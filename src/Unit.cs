using Godot;
using Godot.Collections;

public struct Unit
{
    public enum CHR_CLASS: byte
    {
        NULL,
        EXORCIST,
        PALADIN,
        CITIZEN,
        VANGUARD,
        JOURNEYMAN,
        COURIER,
        CLERIC,
        SCRYER,
        HUNTER 
    }
    public CHR_CLASS char_class = CHR_CLASS.NULL; // the current class of the unit
    
    byte unitID;
    byte statsID; // the idx of the unit's stats
    
    public string name;

    public Unit(byte unitID, string name, CHR_CLASS char_class)
    {
        this.unitID = unitID;
        this.name = name;
        this.char_class = char_class;
    }

    public static string getClassNameByIdx(byte idx)
    {
        string[] class_names = {"null", "exorcist", "paladin", "citizen", "vanguard", "journeyman", "courier", "scryer", "hunter"};

        return class_names[idx];
    }

    public static Unit[] loadCharacters()
    {
        string fileName = "res://data/characters.json";

        var f = FileAccess.GetFileAsString(fileName);

        Dictionary j = (Dictionary) Json.ParseString(f);

        Array characters = (Array) j["characters"];

        Unit[] units = new Unit[characters.Count];

        for (byte i = 0; i < characters.Count; i++)
        {
            Dictionary item = (Dictionary) characters[i];

            units[i] = new Unit(0, (string) item["name"], (Unit.CHR_CLASS) (byte) item["class"]);
        }

        return units; 
    }

}