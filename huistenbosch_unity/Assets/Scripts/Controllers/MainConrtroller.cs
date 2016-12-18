using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainConrtroller : Singleton<MainConrtroller> {

	enum AppState {
		MENU,
		PLAYING,
		TESTPROJECTION
	}

	public enum SplitMode {
		TWO,
		THREE
	}

	public SplitMode splitMode;

	[SerializeField]
	private MainMenu mainMenu;

	//In movie
	[SerializeField]
	private SoundController soundController;
	[SerializeField]
	private MovieController movieController;

	#region BeforeStartMovie
	public void StartMovieSplitIntoTwo(){
		if(!checkLoadedTextures()) return;
		splitMode = SplitMode.TWO;
		soundController.playSound ();
        movieController.playMovie();
		mainMenu.switchToPlayingMode ();
	}

	public void StarrMovieSplitIntoThree(){
		if(!checkLoadedTextures()) return;
		splitMode = SplitMode.THREE;
		soundController.playSound ();
        movieController.playMovie();
        mainMenu.switchToPlayingMode ();
	}

	public void LoadImages(){
		ImageLoadManager.I.LoadTextures ();
	}

	private bool checkLoadedTextures(){
		if(ImageLoadManager.I.GetLoadedTexturesSize() > 0){
			return true;
		}
		return false;
	}

	public void RemoveSelectedTextures(List<bool> selectedStates){
		ImageLoadManager.I.RemoveSelectedTextures (selectedStates);
	}

    public void changePreviewScreen(MovieController.PlayMode mode)
    {
        mainMenu.changePreviewScreen(mode);
    }
    #endregion


    #region AfterStartMovie
    public void StopPlay(){
        ImageLoadManager.I.refresh();
        mainMenu.switchToMenuMode ();
		soundController.stopSound ();
		movieController.stopMovie ();
	}
	#endregion
}
