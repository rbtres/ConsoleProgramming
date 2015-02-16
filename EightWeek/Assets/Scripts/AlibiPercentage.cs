
using System.Collections;
//this class handles the percentages of everything
//should split it up by type later;

public class AlibiPercentage {
    public int MeanAmountOfCharacters = 30;
    public int StandDevOfCharacters = 5;
    public int CurrentAmountOfCharacters = 0;
    public int StandDevTypes = 2;

    public System.Random _Random;


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
    public void SetMaxTraits()
    {
        _Random = new System.Random();
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

        traits._eyeColor = getEyeColor(v);
        traits._hairColor = getHairColor(v);
        traits._skinColor = getSkinColor(v);

        return traits;
    }


    //Each Based off Percent Will Check Current
    //Compared to Avg using Normal Distribution
    //than the percentage will be added and will 
    //return the type based off of semi random
    // 1% = 1 so 10% holds 0-9 next 10% holds 10-19
    //etc
    private SkinColor getSkinColor(VisualCount v)
    {
        int currentBrn = v.BrownSkin;
        int currentBlk = v.BlackSkin;
        int currentWht = v.WhiteSkin;

        int difBrn;
        int difBlk;
        int difWht;
        //Might need to modifiy to check how far above max
        //In order to do proper Math
        difBrn = _maxTraits.BrownSkin - currentBrn;
        difWht = _maxTraits.WhiteSkin - currentWht;
        difBlk = _maxTraits.BlackSkin - currentWht;

        int perBrn;
        int perBlk;
        int perWht;
        if (difBrn > 0)
        {
            perBrn = (int)Probability.CumlativeNormalDis(_maxTraits.BrownSkin, _maxTraits.BrownSkin, StandDevTypes) -
                (int)Probability.CumlativeNormalDis(currentBrn, _maxTraits.BrownSkin, StandDevTypes); 
        }
        else
        {
            perBrn = (int)Probability.CumlativeNormalDis(currentBrn, _maxTraits.BrownSkin, StandDevTypes) -
                (int)Probability.CumlativeNormalDis(_maxTraits.BrownSkin, _maxTraits.BrownSkin, StandDevTypes);
             
            //don't know exactly what to do in this case
        }

        if(difBlk > 0)
        {
            perBlk = (int)Probability.CumlativeNormalDis(_maxTraits.BlackSkin, _maxTraits.BlackSkin, StandDevTypes) -
               (int)Probability.CumlativeNormalDis(currentBlk, _maxTraits.BlackSkin, StandDevTypes); 
        }
        else
        {
            perBlk = (int)Probability.CumlativeNormalDis(currentBlk, _maxTraits.BlackSkin, StandDevTypes) -
               (int)Probability.CumlativeNormalDis(_maxTraits.BlackSkin, _maxTraits.BlackSkin, StandDevTypes);
        }

        if(difWht > 0)
        {
            perWht = (int)Probability.CumlativeNormalDis(_maxTraits.WhiteSkin, _maxTraits.WhiteSkin, StandDevTypes) -
               (int)Probability.CumlativeNormalDis(currentWht, _maxTraits.WhiteSkin, StandDevTypes); 
        }
        else
        {
            perWht = (int)Probability.CumlativeNormalDis(currentWht, _maxTraits.WhiteSkin, StandDevTypes) -
               (int)Probability.CumlativeNormalDis(_maxTraits.WhiteSkin, _maxTraits.WhiteSkin, StandDevTypes);
        }

        SkinColor s;

        int r = _Random.Next(perBlk + perBrn + perWht);

        if( r < perWht)
        {
            s = SkinColor.White;
        }
        else if(r < (perWht + perBlk))
        {
            s = SkinColor.Black;
        }
        else 
        {
            s = SkinColor.Brown;
        }

        return s;
    }

    //--------------------------------------------------------------------------------------------
    private EyeColor getEyeColor(VisualCount v)
    {
        int currentHzl = v.HazelEyes;
        int currentBlu = v.BlueEyes;
        int curretnGrn = v.GreenEyes;

        //Same as above function
        int difHz = _maxTraits.HazelEyes - currentHzl;
        int difBl = _maxTraits.BlueEyes - currentBlu;
        int difGrn = _maxTraits.GreenEyes - curretnGrn;

        int perHz;
        int perBl;
        int perGr;

        if (difHz > 0)
        {
            perHz =  (int)Probability.CumlativeNormalDis(_maxTraits.HazelEyes, _maxTraits.HazelEyes, StandDevTypes) -
                (int)Probability.CumlativeNormalDis(currentHzl, _maxTraits.HazelEyes, StandDevTypes); 
        }
        else
        {
            perHz = (int)Probability.CumlativeNormalDis(currentHzl, _maxTraits.HazelEyes, StandDevTypes) - 
                 (int)Probability.CumlativeNormalDis(_maxTraits.HazelEyes, _maxTraits.HazelEyes, StandDevTypes);
        }

        if(difBl > 0)
        {
            perBl = (int)Probability.CumlativeNormalDis(_maxTraits.BlueEyes, _maxTraits.BlueEyes, StandDevTypes) -
                (int)Probability.CumlativeNormalDis(currentBlu, _maxTraits.BlueEyes, StandDevTypes);
        }
        else
        {
            perBl = (int)Probability.CumlativeNormalDis(currentBlu, _maxTraits.BlueEyes, StandDevTypes) -
                (int)Probability.CumlativeNormalDis(_maxTraits.BlueEyes, _maxTraits.BlueEyes, StandDevTypes);
        }

        if (difGrn > 0)
        {
            perGr = (int)Probability.CumlativeNormalDis(_maxTraits.GreenEyes, _maxTraits.GreenEyes, StandDevTypes) -
                (int)Probability.CumlativeNormalDis(curretnGrn, _maxTraits.GreenEyes, StandDevTypes);
        }
        else
        {
            perGr = (int)Probability.CumlativeNormalDis(curretnGrn, _maxTraits.GreenEyes, StandDevTypes) -
                (int)Probability.CumlativeNormalDis(_maxTraits.GreenEyes, _maxTraits.GreenEyes, StandDevTypes);
        }

        int r = _Random.Next(perBl + perGr + perHz);

        EyeColor e;

        if (r < perBl)
        {
            e = EyeColor.Blue;
        }
        else if( r < (perBl + perHz))
        {
            e = EyeColor.Hazel;
        }
        else
        {
            e = EyeColor.Green;
        }
        return e;
    }

    //--------------------------------------------------------------------------------------------
    private HairColor getHairColor(VisualCount v)
    {
        int currentBld = v.BlondHair;
        int currentRed = v.RedHair;
        int currentBlk = v.BlackHair;
        int currentBrn = v.BrownHair;

        //Same as above
        int difBld = _maxTraits.BlondHair - currentBld;
        int difRed = _maxTraits.RedHair - currentRed;
        int difBlk = _maxTraits.BlackHair - currentBlk;
        int difBrn = _maxTraits.BrownHair - currentBrn;


        int perBld;
        int perRed;
        int perBlk;
        int perBrn;

        if (difBld > 0)
        {
            perBld = (int)Probability.CumlativeNormalDis(_maxTraits.BlondHair, _maxTraits.BlondHair, StandDevTypes) -
                (int)Probability.CumlativeNormalDis(currentBld, _maxTraits.BlondHair, StandDevTypes);
        }
        else
        {
            perBld = (int)Probability.CumlativeNormalDis(currentBld, _maxTraits.BlondHair, StandDevTypes) -
                (int)Probability.CumlativeNormalDis(_maxTraits.BlondHair, _maxTraits.BlondHair, StandDevTypes);
        }

        if (difRed > 0)
        {
            perRed = (int)Probability.CumlativeNormalDis(_maxTraits.RedHair, _maxTraits.RedHair, StandDevTypes) -
                (int)Probability.CumlativeNormalDis(currentRed, _maxTraits.RedHair, StandDevTypes);
        }
        else
        {
            perRed = (int)Probability.CumlativeNormalDis(currentRed, _maxTraits.RedHair, StandDevTypes) -
                (int)Probability.CumlativeNormalDis(_maxTraits.RedHair, _maxTraits.RedHair, StandDevTypes);
        }

        if (difBlk > 0)
        {
            perBlk = (int)Probability.CumlativeNormalDis(_maxTraits.BlackHair, _maxTraits.BlackHair, StandDevTypes) -
                (int)Probability.CumlativeNormalDis(currentBlk, _maxTraits.BlackHair, StandDevTypes);
        }
        else
        {
            perBlk = (int)Probability.CumlativeNormalDis(currentBlk, _maxTraits.BlackHair, StandDevTypes) -
                (int)Probability.CumlativeNormalDis(_maxTraits.BlackHair, _maxTraits.BlackHair, StandDevTypes);
        }

        if (difBrn > 0)
        {
            perBrn = (int)Probability.CumlativeNormalDis(_maxTraits.BrownHair, _maxTraits.BrownHair, StandDevTypes) -
                (int)Probability.CumlativeNormalDis(currentBrn, _maxTraits.BrownHair, StandDevTypes);
        }
        else
        {
            perBrn = (int)Probability.CumlativeNormalDis(currentBrn, _maxTraits.BrownHair, StandDevTypes) -
                (int)Probability.CumlativeNormalDis(_maxTraits.BrownHair, _maxTraits.BrownHair, StandDevTypes);
        }

        HairColor h;

        int r = _Random.Next(perBlk + perBrn + perRed+ perBld);

        if (r < perBlk)
        {
            h = HairColor.Black;
        }
        else if (r < (perBlk + perBrn))
        {
            h = HairColor.Brown;
        }
        else if(r < (perBlk + perBrn + perRed))
        {
            h = HairColor.Red;
        }
        else
        {
            h = HairColor.Blond;
        }

        return h;
    }

}
