
using System.Collections;

public class VisualAlibiFactory
{
    static private VisualAlibiFactory _visualAlibi = null;
    private AlibiPercentage _alibiPercent;

    public VisualCount _visualCount;
    //--------------------------------------------------------------------------------------------
    public VisualAlibiFactory()
    {
        _visualCount.Create();
    }
    public static VisualAlibiFactory getInstance()
    {
        if(_visualAlibi == null)
        {
            _visualAlibi = new VisualAlibiFactory();
        }
        return _visualAlibi;
    }
    //--------------------------------------------------------------------------------------------
    public VisualTraits CreateVisualTrait()
    {
        VisualTraits v = _alibiPercent.GetVisualAlibi(_visualCount);

        _visualCount.Increment(v);
        return v;
    }
}

//--------------------------------------------------------------------------------------------
public struct VisualCount
{
    //--------------------------------------------------------------------------------------------
    public int BrownHair { public get; private set; }
    public int BlondHair { public get; private set; }
    public int BlackHair { public get; private set; }
    public int RedHair { public get; private set; }

    //--------------------------------------------------------------------------------------------
    public int HazelEyes { public get; private set; }
    public int BlueEyes { public get; private set; }
    public int GreenEyes { public get; private set; }

    //--------------------------------------------------------------------------------------------
    public int WhiteSkin { public get; private set; }
    public int BrownSkin { public get; private set; }
    public int BlackSkin { public get; private set; }

    //--------------------------------------------------------------------------------------------
    public void Create() { 
        BrownHair = 0; BlondHair = 0; BlondHair = 0; RedHair = 0;
        HazelEyes = 0; GreenEyes = 0; BlueEyes = 0;
        WhiteSkin = 0; BrownSkin = 0; BlackSkin = 0;
    }

    //--------------------------------------------------------------------------------------------
    public void Increment(VisualTraits v)
    {
        IncrementHairColor(v._hairColor);
        IncrementEyeColor(v._eyeColor);
        IncrementSkinColor(v._skinColor);
    }

    //--------------------------------------------------------------------------------------------
    public void IncrementHairColor(HairColor h)
    {
        switch(h)
        {
            case HairColor.Black:
                BlackHair++;
                break;
            case HairColor.Blond:
                BlondHair++;
                break;
            case HairColor.Brown:
                BrownHair++;
                break;
            case HairColor.Red:
                RedHair++;
                break;
        }
    }

    //--------------------------------------------------------------------------------------------
    public void IncrementEyeColor(EyeColor e)
    {
        switch(e)
        {
            case EyeColor.Blue:
                BlueEyes++;
                break;
            case EyeColor.Green:
                GreenEyes++;
                break;
            case EyeColor.Hazel:
                HazelEyes++;
                break;
        }
    }

    //--------------------------------------------------------------------------------------------
    public void IncrementSkinColor(SkinColor s)
    {
        switch(s)
        {
            case SkinColor.Black:
                BlackSkin++;
                break;
            case SkinColor.Brown:
                BrownSkin++;
                break;
            case SkinColor.White:
                WhiteSkin++;
                break;
        }
    }
}
