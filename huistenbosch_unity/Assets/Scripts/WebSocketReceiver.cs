using UnityEngine;
using System.Collections;
using System;


[AddComponentMenu("Data/WebSocketReceiver")]
public class WebSocketReceiver : MonoBehaviour {

	//public getNewTweetCallBack callBack;

	// Use this for initialization
	IEnumerator Start () {
		WebSocket w = new WebSocket(new Uri("ws://127.0.0.1:3000"));
		yield return StartCoroutine(w.Connect());
		w.SendString("Hi there");
		int i=0;
		while (true)
		{
			string reply = w.RecvString();
			if (reply != null)
			{
				Debug.Log ("Received: "+reply);
				//callBack (JSONparser.parseJSON(reply));
				w.SendString("Hi there"+i++);
			}
			if (w.Error != null)
			{
				//Debug.LogError ("Error: "+w.Error);
				break;
			}
			yield return new WaitForSeconds(0.5f);
			yield return 0;
		}
		w.Close();
	}

	//public delegate void getNewTweetCallBack(Tweet newTweet);
}

//export NODE_PATH=$HOME/.nodebrew/current/lib/node_modules
//export PATH=$HOME/.nodebrew/current/bin:$PATH
//export NODEBREW_ROOT=$HOME/.nodebrew
//ps aux | grep node
//sudo kill -9 num
//nmp i
