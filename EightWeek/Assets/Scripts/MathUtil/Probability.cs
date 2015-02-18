using System.Collections;
using System;
public class Probability {
    public const float e = 2.71828f;
    //cumlative probabilty of ans < randVariable based on the mean and standDev
    //so if you wanted to know how long a light bulb would last for 1200 hours or less
    //the mean would be 1000 and dev would be 100
    // you would use CumlativeStand...(1200,1000,100) the percentage would be .97
    static public float NormalDis(float randVariable, float mean, float standDev)
    {
        float y = (float)1.0f / (standDev * (float)Math.Sqrt(2.0f * Math.PI));
        float z = -1 * (((randVariable - mean) * (randVariable - mean)) / (2.0f * standDev * standDev));
        float x = e;
        x = (float)Math.Pow(x, z);
        y = y * x;
        
        return y;
    }

    //--------------------------------------------------------------------------------------------
    static public float CumlativeNormalDis(float randVariable, float mean, float standDev)
    {
        float ans = 0;
        for(int i = 0; i < randVariable;i++)
        {
            ans += NormalDis(i, mean, standDev);
        }
        return ans * 100;
    }
}
