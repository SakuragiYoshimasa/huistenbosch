using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileLoader : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			ReadFile ();
		}  
	}

	void ReadFile(){
		Texture2D tex = new Texture2D(0,0);
		tex.LoadImage(LoadBin("/Users/sakuragiyoshimasa/Desktop/twitapi/insta_img/0.jpg"));
		gameObject.GetComponent<Renderer>().material.mainTexture = tex;
	}

	byte[] LoadBin(string path){
		FileStream fs = new FileStream(path, FileMode.Open);
		BinaryReader br = new BinaryReader(fs);
		byte[] buf = br.ReadBytes( (int)br.BaseStream.Length);
		br.Close();
		return buf;
	}
}
