using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageLoadManager : Singleton<ImageLoadManager> {

	[SerializeField]
	private List<Texture2D> textures;



	[SerializeField]
	private int usedIndex;

	void Start(){
		usedIndex = 0;
	}

	public List<Texture2D> GetTextures(){
		if(textures.Count == 0){
			textures = FileLoader.LoadTextures ();
		}
		return textures;
	}

	public Texture2D GetRandomTexture(){
		if(textures.Count == 0){
			textures = FileLoader.LoadTextures ();
		}

		double randomValue = Random.value;
		int index = (int)(randomValue * (double)textures.Count);
		return textures [index];
	}

	public Texture2D GetSortedTexture(){

		if(textures.Count == 0){
			textures = FileLoader.LoadTextures ();
		}

		int useIndex = usedIndex;
		usedIndex++;
		if(usedIndex >= textures.Count - 1){
			usedIndex = 0;
		}

		return textures [useIndex];
	}

	public void LoadTextures(){
		textures = FileLoader.LoadTextures ();
	}

	public int GetLoadedTexturesSize(){
		return textures.Count;
	}
}
