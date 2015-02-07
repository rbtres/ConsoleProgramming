using System.Collections;

//--------------------------------------------------------------------------------------------
public class VisualAlibis 
{
    public VisualAlibis(VisualTraits vTraits)
    {
        _visualTraits = vTraits;
    }

    public VisualTraits _visualTraits { public get; private set; }
}

//--------------------------------------------------------------------------------------------
public struct VisualTraits
{
    public HairColor _hairColor;
    public EyeColor _eyeColor;
    public SkinColor _skinColor;
};

//--------------------------------------------------------------------------------------------
public enum HairColor
{
    Brown,
    Blond,
    Black,
    Red
};

//--------------------------------------------------------------------------------------------
public enum EyeColor
{
    Hazel,
    Blue,
    Green
};

//--------------------------------------------------------------------------------------------
public enum SkinColor
{
    White,
    Brown,
    Black
}