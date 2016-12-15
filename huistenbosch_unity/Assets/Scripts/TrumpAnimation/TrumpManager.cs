﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpManager : Singleton<TrumpManager> {

	[SerializeField]
	private int cardNum;

	[SerializeField]
	private List<GameObject> trumpCards;

	[SerializeField]
	private List<Transform> pointsOfTrumptower;

	[SerializeField]
	private TrumpAnimationState state;
    public TrumpAnimationState State {
        get { return state; }
    }

	[SerializeField]
	public Texture2D shapeTex;

	void Start () {
		state = TrumpAnimationState.Construction;
	}

	void Update () {
		if(Input.GetKeyUp(KeyCode.Space)){
			Debug.Log (shapeTex);
		}
	}
}
