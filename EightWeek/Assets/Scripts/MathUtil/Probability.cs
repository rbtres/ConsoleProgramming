using UnityEngine;
using System.Collections;

public class Probability : MonoBehaviour {
    public const float e = 2.71828f;
    //cumlative probabilty of ans < randVariable based on the mean and standDev
    //so if you wanted to know how long a light bulb would last for 1200 hours or less
    //the mean would be 1000 and dev would be 100
    // you would use Stand...(1200,1000,100) the percentage would be .97
    static public float StandardDeviation(float randVariable, float mean, float standDev)
    {
        float y = (float)1.0f / (standDev * Mathf.Sqrt(2.0f * Mathf.PI));
        float z = -1 * (((randVariable - mean) * (randVariable - mean)) / (2.0f * standDev * standDev));
        float x = e;
        x = Mathf.Pow(x, z);
        y = y * x;
        
        return y;
    }

    //--------------------------------------------------------------------------------------------
    static public float CumlativeStandDev(float randVariable, float mean, float standDev)
    {
        float ans = 0;
        for(int i = 0; i < randVariable;i++)
        {
            ans += StandardDeviation(i, mean, standDev);
        }
        Debug.Log(ans);
        return ans;
    }
}
