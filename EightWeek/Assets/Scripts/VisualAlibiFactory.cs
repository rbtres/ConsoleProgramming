using System.Collections;

public class VisualAlibiFactory
{
    static private VisualAlibiFactory _visualAlibi;
    private AlibiPercentage _alibiPercent;
    static public int _totalPeople = 0;
    static int created = 0;
    public VisualCount _visualCount;

    //--------------------------------------------------------------------------------------------
    private VisualAlibiFactory()
    {
        _visualCount.Create();
        _alibiPercent = new AlibiPercentage();
        _alibiPercent.SetMaxTraits();
    }

    //--------------------------------------------------------------------------------------------
    public static VisualAlibiFactory getInstance()
    {
        if(created == 0)
        {
            _visualAlibi = new VisualAlibiFactory();
            created++;
        }
        return _visualAlibi;
    }
    public bool CanCreateNewCharacter()
    {

        float num = Probability.CumlativeNormalDis(_alibiPercent.MeanAmountOfCharacters, _alibiPercent.MeanAmountOfCharacters, _alibiPercent.StandDevOfCharacters);
        num -= Probability.CumlativeNormalDis(_totalPeople, _alibiPercent.MeanAmountOfCharacters, _alibiPercent.StandDevOfCharacters);
        if (num > 50)
        {
            return true;
        }
        else if(num > 10)
        {
            int number = _alibiPercent._Random.Next(0, 101);
            if(number <= num)
            {
                return true;
            }
        }
        return false;
    }
    //--------------------------------------------------------------------------------------------
    public VisualTraits CreateVisualTrait()
    {
        VisualTraits v = _alibiPercent.GetVisualAlibi(_visualCount);

        _visualCount.Increment(v);
        _totalPeople++;
       

        return v;
    }
}

//--------------------------------------------------------------------------------------------
public struct VisualCount
{
    //--------------------------------------------------------------------------------------------
    public int BrownHair { get; private set; }
    public int BlondHair { get; private set; }
    public int BlackHair { get; private set; }
    public int RedHair { get; private set; }

    //--------------------------------------------------------------------------------------------
    public int HazelEyes { get; private set; }
    public int BlueEyes { get; private set; }
    public int GreenEyes { get; private set; }

    //--------------------------------------------------------------------------------------------
    public int WhiteSkin { get; private set; }
    public int BrownSkin { get; private set; }
    public int BlackSkin { get; private set; }

    //--------------------------------------------------------------------------------------------
    public void Create() { 
        BrownHair = 0; BlondHair = 0; BlondHair = 0; RedHair = 0;
        HazelEyes = 0; GreenEyes = 0; BlueEyes = 0;
        WhiteSkin = 0; BrownSkin = 0; BlackSkin = 0; BlackHair = 0;
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
