﻿using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileLoader : MonoBehaviour {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
    public const string FOLDER_PATH = "/Users/sakuragi/Desktop/twiapi/insta_img/";
    public const int IMAGE_NUM = 15;
#elif UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
    public const string FOLDER_PATH = "/Users/yoshimasasakuragi/Desktop/twiapi/img/";
    public const int IMAGE_NUM = 188; 
#endif
    public const string IMAGE_SUFFIX = ".jpg";
	
	static string texpath;

	public static List<Texture2D> LoadTextures(){

		//TODO before load from local path, call node program in here asynch

		List<Texture2D> textures = new List<Texture2D> (0);
		for(int i = 0; i < IMAGE_NUM; i++){
			Texture2D tex = new Texture2D(0,0);
			string texpath = FileLoader.FOLDER_PATH + i.ToString () + FileLoader.IMAGE_SUFFIX;
			tex.LoadImage(LoadBin(texpath));
			textures.Add (tex);
		}
		return textures;
	}

	static byte[] LoadBin(string path){
		FileStream fs = new FileStream(path, FileMode.Open);
		BinaryReader br = new BinaryReader(fs);
		byte[] buf = br.ReadBytes( (int)br.BaseStream.Length);
		br.Close();
		return buf;
	}
}
