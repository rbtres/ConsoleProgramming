using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class UnityFile : MonoBehaviour {
    VisualAlibiFactory _factory;
    List<VisualTraits> _visualTraits;
	// Use this for initialization
	void Start () {
        _factory = VisualAlibiFactory.getInstance();
        _visualTraits = new List<VisualTraits>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(_factory.CanCreateNewCharacter())
        {
            _visualTraits.Add(_factory.CreateVisualTrait());
        }
        if(Input.GetButtonDown("x"))
        {
            reset();
        }
	}
    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 200, 20), "Total Alibis: " + _visualTraits.Count);
        GUI.Box(new Rect(10, 40, 200, 20), " Total with Red Hair: " + _factory._visualCount.RedHair);
        GUI.Box(new Rect(10, 70, 200, 20), " Total with Brown Hair: " + _factory._visualCount.BrownHair);
        GUI.Box(new Rect(10, 100, 200, 20), " Total with Black Hair: " + _factory._visualCount.BlackHair);
        GUI.Box(new Rect(10, 130, 200, 20), " Total with Blond Hair: " + _factory._visualCount.BlondHair);
        GUI.Box(new Rect(10, 160, 200, 20), " Total with white skin: " + _factory._visualCount.WhiteSkin);
        GUI.Box(new Rect(10, 190, 200, 20), " Total with black skin: " + _factory._visualCount.BlackSkin);
        GUI.Box(new Rect(10, 220, 200, 20), " Total with tan skin: " + _factory._visualCount.BrownSkin);
        GUI.Box(new Rect(10, 250, 200, 20), " Total with hazel eyes: " + _factory._visualCount.HazelEyes);
        GUI.Box(new Rect(10, 280, 200, 20), " Total with blue eyes: " + _factory._visualCount.BlueEyes);
        GUI.Box(new Rect(10, 310, 200, 20), " Total with Green eyes: " + _factory._visualCount.GreenEyes);
    }
    void reset()
    {
        while(_visualTraits.Count > 0)
        {
            _visualTraits.RemoveAt(0);
        }
        VisualAlibiFactory._totalPeople = 0;
        _factory._visualCount.Create();
    }
}
