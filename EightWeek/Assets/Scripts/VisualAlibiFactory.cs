
using System.Collections;

public class VisualAlibiFactory
{
    static private VisualAlibiFactory _visualAlibi = null;

    public VisualCount SVisualCount;
    //--------------------------------------------------------------------------------------------
    VisualAlibiFactory()
    {
        SVisualCount.Create();
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
        //math to be done in here
        VisualTraits v;
        v._eyeColor = EyeColor.Blue;
        v._hairColor = HairColor.Black;
        v._skinColor = SkinColor.Black;
        return v;
    }
}

//--------------------------------------------------------------------------------------------
public struct VisualCount
{
    int BrownHair;
    int BlondHair;
    int BlackHair;
    int RedHair;

    int HazelEyes;
    int BlueEyes;
    int GreenEyes;

    int WhiteSkin;
    int BrownSkin;
    int BlackSkin;

    public void Create() { 
        BrownHair = 0; BlondHair = 0; BlondHair = 0; RedHair = 0;
        HazelEyes = 0; GreenEyes = 0; BlueEyes = 0;
        WhiteSkin = 0; BrownSkin = 0; BlackSkin = 0;
    }
    public void Increment(VisualTraits v)
    {

    }
    private void IncrementHairColor(HairColor h)
    {

    }
    private void IncrementEyeColor(EyeColor e)
    {

    }
    private void IncrementSkinColor(SkinColor s)
    {

    }
}
