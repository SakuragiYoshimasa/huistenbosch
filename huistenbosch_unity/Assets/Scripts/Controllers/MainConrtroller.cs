using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainConrtroller : Singleton<MainConrtroller> {

	[SerializeField]
	private MainMenu mainMenu;

	//In movie
	[SerializeField]
	private SoundController SoundController;
	[SerializeField]
	private MovieController movieController;

	public void StartMovieSplitIntoTwo(){
		SoundController.playSound ();
	}

	public void StarrMovieSplitIntoThree(){
		
	}

	public void LoadImages(){
		ImageLoadManager.I.LoadTextures ();


	}

	private void EmergencyStop(){
		
	}
}
