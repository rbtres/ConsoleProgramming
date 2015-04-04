using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ColorScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void setColors(VisualTraits v)
    {
        Color eye,hair;
        switch (v._skinColor)
        {
            case SkinColor.Black:
                setColor(Color.black);
                break;
            case SkinColor.Brown:
                setColor(Color.gray);
                break;
            case SkinColor.White:
                setColor(Color.white);
                break;
        }

        switch(v._hairColor)
        {
            case HairColor.Black:
                hair = Color.black;
                break;
            case HairColor.Blond:
                hair = Color.yellow;
                break;
            case HairColor.Brown:
                hair = Color.gray;
                break;
            case HairColor.Red:
                hair = Color.red;
                break;
            default:
                hair = Color.white;
                break;
        }
        switch(v._eyeColor)
        {
            case EyeColor.Blue:
                eye = Color.blue;
                break;
            case EyeColor.Green:
                eye = Color.green;
                break;
            case EyeColor.Hazel:
                eye = Color.gray;
                break;
            default:
                eye = Color.red;
                break;
        }
        setFaceColors(eye, hair);
    }
    public void setColor(Color c)
    {
        this.renderer.material.color = c;
    }
    public void setFaceColors(Color eyes, Color Hair)
    {
        BodyType[] o = this.gameObject.GetComponentsInChildren<BodyType>();
        for (var i = 0; i < o.Length; i++)
        {
            if(o[i].mFacePiece == FacePiece.EYE)
            {
                o[i].setColor(eyes);
            }
            else if(o[i].mFacePiece == FacePiece.HAIR)
            {
                o[i].setColor(Hair);
            }
        }
    }
}
public enum FacePiece:byte
{
    EYE = 0,
    HAIR
};