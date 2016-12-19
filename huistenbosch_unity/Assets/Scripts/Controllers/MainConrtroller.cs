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
    #region Feilds
    public SplitMode splitMode;
	[SerializeField]
	private MainMenu mainMenu;
	[SerializeField]
	private SoundController soundController;
	[SerializeField]
	private MovieController movieController;
    [SerializeField]
    private bool isMappingTesting;
    #endregion
    #region MappingTest
    public void MappingTestStart() {
        movieController.setMappingMode();
    }
    public void MappingTestEnd() {
        movieController.endMappingMode();
    }
    #endregion
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
    public void LoadDammy()
    {
        ImageLoadManager.I.LoadDummyTextures();
    }
    public void LoadFromTwitter()
    {
        ImageLoadManager.I.LoadTwitterTexture();
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
