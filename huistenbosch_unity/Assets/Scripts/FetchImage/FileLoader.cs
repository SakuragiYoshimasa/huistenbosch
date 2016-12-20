using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileLoader : MonoBehaviour {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
    public const string FOLDER_PATH = "/Users/sakuragi/Desktop/huistenbosch_sns/insta_img/";
    public const int IMAGE_NUM = 188;
    public const string FOLDER_PATH_TWITTER = "/Users/sakuragi/Desktop/huistenbosch_sns/twitter_img/";
    public const int IMAGE_NUM_TWITTER = 100;
    public const string DAMMY_FOLDER_PATH = "/Users/sakuragi/Desktop/huistenbosch_sns/img_scrape/";
    public const int DAMMY_IMAGE_NUM = 188;
#elif UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
    public const string FOLDER_PATH = "/Users/yoshimasasakuragi/Desktop/twiapi/img/";
    public const int IMAGE_NUM = 188; 
#endif
    public const string IMAGE_SUFFIX = ".jpg";
	
	static string texpath;

	public static List<Texture2D> LoadTextures(){

		List<Texture2D> textures = new List<Texture2D> (0);
		for(int i = 0; i < IMAGE_NUM; i++){
			Texture2D tex = new Texture2D(0,0);
			string texpath = FileLoader.FOLDER_PATH + i.ToString () + FileLoader.IMAGE_SUFFIX;
			tex.LoadImage(LoadBin(texpath));
            if (tex != null) {
                textures.Add(tex);
            }
		}
		return textures;
	}
    public static List<Texture2D> LoadTexturesFromTwitter() {
        List<Texture2D> textures = new List<Texture2D> (0);
		for(int i = 0; i < IMAGE_NUM_TWITTER; i++){
			Texture2D tex = new Texture2D(0,0);
			string texpath = FileLoader.FOLDER_PATH_TWITTER + i.ToString () + FileLoader.IMAGE_SUFFIX;
			tex.LoadImage(LoadBin(texpath));
            if (tex != null) {
                textures.Add(tex);
            }
		}
		return textures;
    }

    public static List<Texture2D> LoadTexturesDammy()
    {
        List<Texture2D> textures = new List<Texture2D>(0);
        for (int i = 0; i < DAMMY_IMAGE_NUM; i++)
        {
            Texture2D tex = new Texture2D(0, 0);
            string texpath = FileLoader.DAMMY_FOLDER_PATH + i.ToString() + FileLoader.IMAGE_SUFFIX;
            tex.LoadImage(LoadBin(texpath));
            if (tex != null)
            {
                textures.Add(tex);
            }
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
