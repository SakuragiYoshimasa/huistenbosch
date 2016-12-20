using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageLoadManager : Singleton<ImageLoadManager> {

    [SerializeField]
    private List<Texture2D> textures;
    [SerializeField]
    private int usedIndex;
    [SerializeField]
    private ProcessRunner processRunner;
    [SerializeField]
    private MainMenu mainMenu;
    public bool FetchFinished = false;
    public bool twitterFetchFinished = false;

    void Start() {
        usedIndex = 0;
    }
    void Update() {
        if (FetchFinished) {
            HandleFetchedImages();
            FetchFinished = false;
        }
        if (twitterFetchFinished) {
            HandleFetchedImagesFromTwitter();
            twitterFetchFinished = false;
        }
    }

    public List<Texture2D> GetTextures() {
        return textures;
    }
    public Texture2D GetRandomTexture() {
        if (textures.Count == 0) {
            textures = FileLoader.LoadTexturesDammy();
        }

        double randomValue = Random.value;
        int index = (int)(randomValue * (double)textures.Count);
        return textures[index];
    }
    public Texture2D GetSortedTexture() {

        if (textures.Count == 0) {
            textures = FileLoader.LoadTexturesDammy();
        }

        int useIndex = usedIndex;
        usedIndex++;
        if (usedIndex >= textures.Count - 1) {
            usedIndex = 0;
        }

        return textures[useIndex];
    }
    public void refresh() {
        textures = new List<Texture2D>(0);
    }
    public void LoadTextures() {
        processRunner.FetchImage();
        //LoadDummyTextures();
    }
    public void LoadTwitterTexture() {
        processRunner.FetchImageFromTwitter();
        //LoadDummyTextures();
    }
    public void LoadDummyTextures() {
        textures = FileLoader.LoadTexturesDammy();
        mainMenu.UpdateScrollImageViewContent();
    }
    public void HandleFetchedImages() {
        textures = FileLoader.LoadTextures();
        mainMenu.LoadingEnd();
        mainMenu.UpdateScrollImageViewContent();
    }
    public void HandleFetchedImagesFromTwitter() {
        textures = FileLoader.LoadTexturesFromTwitter();
        mainMenu.LoadingEnd();
        mainMenu.UpdateScrollImageViewContent();
    }
    public int GetLoadedTexturesSize(){
		return textures.Count;
	}
	public void RemoveSelectedTextures(List<bool> selectedStates){
		List<Texture2D> newTextures = new List<Texture2D> (0);

		for(int i = 0; i < textures.Count; i++){

			if (!selectedStates [i]) {
				newTextures.Add (textures[i]);
			}
		}
		textures = newTextures;
	}
}
