using System;

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
}