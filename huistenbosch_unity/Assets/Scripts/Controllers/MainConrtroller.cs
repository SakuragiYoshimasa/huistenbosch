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

	#region BeforeStartMovie
	public void StartMovieSplitIntoTwo(){
		if(checkLoadedTextures()) return;

		SoundController.playSound ();
	}

	public void StarrMovieSplitIntoThree(){
		if(checkLoadedTextures()) return;

		SoundController.playSound ();
	}

	public void LoadImages(){
		ImageLoadManager.I.LoadTextures ();
		mainMenu.UpdateScrollImageViewContent ();
	}

	private bool checkLoadedTextures(){
		if(ImageLoadManager.I.GetLoadedTexturesSize() > 0){
			return true;
		}
		return false;
	}
	#endregion


	#region AfterStartMovie
	private void EmergencyStop(){

	}

	#endregion
}
