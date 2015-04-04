using UnityEngine;
using System.Collections;

public class BodyType : MonoBehaviour {

    public FacePiece mFacePiece;

	// Use this for initialization
	void Start () {
	
	}
	public void setColor(Color c)
    {
        this.renderer.material.color = c;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
