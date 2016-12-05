using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageLoadManager : Singleton<ImageLoadManager> {

	[SerializeField]
	private List<Texture2D> textures;

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
}
