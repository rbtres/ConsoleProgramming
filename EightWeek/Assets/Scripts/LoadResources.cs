﻿using UnityEngine;
using System.Collections;

public class LoadResources : MonoBehaviour {

	public static LoadResources LR;
	// Use this for initialization
	public GameObject BUILDING;

	void Awake()
	{
		if(LR != null)
		{
			GameObject.Destroy(LR);
		}
		else
		{
			LR = this;
		}
		DontDestroyOnLoad(this);
	}
	void Start () {
		LoadAllResources();
	}

	//This will load all of games resource folder
	void LoadAllResources()
	{
		BUILDING = Resources.Load<GameObject>("BuildingGround");
	}
}
