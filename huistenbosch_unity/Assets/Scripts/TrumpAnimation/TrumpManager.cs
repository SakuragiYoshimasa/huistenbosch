using System.Collections;
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

	void Start () {
		state = TrumpAnimationState.Construction;
	}

	void Update () {
		
	}
}
