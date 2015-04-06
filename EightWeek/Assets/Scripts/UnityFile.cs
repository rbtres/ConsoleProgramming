using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
public class UnityFile : MonoBehaviour {
    VisualAlibiFactory _factory;
    List<VisualTraits> _visualTraits;
    List<GameObject> _gameObjectList;
    CheatThread thread;
	// Use this for initialization
	void Start () {
       thread = new CheatThread();
        _factory = VisualAlibiFactory.getInstance();
        _visualTraits = new List<VisualTraits>();
        _gameObjectList = new List<GameObject>();
        CheatThread.k_playerCreatedEvent += new CheatThread.playerCreated(createObject);
	}
	
	// Update is called once per frame
	void Update () {
	    if(_factory.CanCreateNewCharacter())
        {
            thread.createObject();
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
    void createObject(VisualTraits v)
    {
        GameObject c = (GameObject)Instantiate(LoadResources.LR.FACE);
        c.GetComponent<ColorScript>().setColors(v);
        c.transform.Translate(-21.0f + _visualTraits.Count * 1.5f, 0, 0);
        _gameObjectList.Add(c);
        _visualTraits.Add(v);
    }
    void reset()
    {
        while(_visualTraits.Count > 0)
        {
            _visualTraits.RemoveAt(0);
        }
        while(_gameObjectList.Count > 0)
        {
            Destroy(_gameObjectList[0]);
            _gameObjectList.RemoveAt(0);
        }
        VisualAlibiFactory._totalPeople = 0;
        _factory._visualCount.Create();
    }
}
