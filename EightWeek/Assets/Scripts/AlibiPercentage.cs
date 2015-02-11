
using System.Collections;
//this class handles the percentages of everything
//should split it up by type later;

public class AlibiPercentage {
    public int MeanAmountOfCharacters = 30;
    public int StandDevOfCharacters = 5;
    public int CurrentAmountOfCharacters = 0;
    public int StandDevTypes = 2;


    //should add to 1;
    //Hair Color
    public float PercentBlkHair = .3f;
    public float PercentRdHair  = .2f;
    public float PercentBldHair = .2f;
    public float PercentBrnHair = .3f;

    //Eye Color
    public float PercentHzEye = .5f;
    public float PercentBlEye = .3f;
    public float PercentGrEye = .2f;

    //Skin Color
    public float PercentBlkSkin = .3f;
    public float PercentBrnSkin = .3f;
    public float PercentWteSkin = .4f;

    public VisualCount _maxTraits;

    //--------------------------------------------------------------------------------------------
    public void setMaxTraits()
    {
        for(int i = 0; i < MeanAmountOfCharacters * PercentBrnHair; i++)
        {
            _maxTraits.IncrementHairColor(HairColor.Brown);
        }

        for (int i = 0; i < MeanAmountOfCharacters * PercentBlkHair; i++)
        {
            _maxTraits.IncrementHairColor(HairColor.Black);
        }

        for (int i = 0; i < MeanAmountOfCharacters * PercentRdHair; i++)
        {
            _maxTraits.IncrementHairColor(HairColor.Red);
        }

        for (int i = 0; i < MeanAmountOfCharacters * PercentBldHair; i++)
        {
            _maxTraits.IncrementHairColor(HairColor.Blond);
        }

        for (int i = 0; i < MeanAmountOfCharacters * PercentHzEye; i++)
        {
            _maxTraits.IncrementEyeColor(EyeColor.Hazel);
        }

        for (int i = 0; i < MeanAmountOfCharacters * PercentBlEye; i++)
        {
            _maxTraits.IncrementEyeColor(EyeColor.Blue);
        }

        for (int i = 0; i < MeanAmountOfCharacters * PercentGrEye; i++)
        {
            _maxTraits.IncrementEyeColor(EyeColor.Green);
        }

        for (int i = 0; i < MeanAmountOfCharacters * PercentWteSkin; i++)
        {
            _maxTraits.IncrementSkinColor(SkinColor.White);
        }

        for (int i = 0; i < MeanAmountOfCharacters * PercentBrnSkin; i++)
        {
            _maxTraits.IncrementSkinColor(SkinColor.Brown);
        }

        for (int i = 0; i < MeanAmountOfCharacters * PercentBlkSkin; i++)
        {
            _maxTraits.IncrementSkinColor(SkinColor.Black);
        }
    }

    //Calls Private functions to create traits.
    public VisualTraits GetVisualAlibi(VisualCount v)
    {
        VisualTraits traits = new VisualTraits();




        return traits;
    }


    //Each Based off Percent Will Check Current
    //Compared to Avg using Normal Distribution
    //than the percentage will be added and will 
    //return the type based off of semi random
    // 1% = 1 so 10% holds 0-9 next 10% holds 10-19
    //etc
    private SkinColor GetSkinColor(VisualCount v)
    {
        int currentBrn = v.BrownSkin;
        int currentBlk = v.BlackSkin;
        int currentWht = v.WhiteSkin;

        SkinColor s = SkinColor.Black;


        return s;
    }

    private EyeColor GetEyeColor(VisualCount v)
    {
        int currentHzl = v.HazelEyes;
        int currentBlu = v.BlueEyes;
        int curretnGrn = v.GreenEyes;

        EyeColor e = EyeColor.Blue;

        return e;
    }

    private HairColor GetHairColor(VisualCount v)
    {
        int currentBld = v.BlondHair;
        int currentRed = v.RedHair;
        int currentBlk = v.BlackHair;
        int currentBrn = v.BrownHair;

        HairColor h = HairColor.Blond;

        return h;
    }

}
