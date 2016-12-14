﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MovieController : MonoBehaviour {

	public enum PlayMode {
		PRE_RENDERED,
		RLT_RENDERING
	}
		
	public const int PRE_RENDERED_TIME_MILLIS = 240000;
	public const int WHOLE_PLAYING_TIME_MILLS = 300000;

	public PlayMode playmode = PlayMode.PRE_RENDERED;

	private int starttime;
	private int now;
	private int elapsedTimeMillis;

	private bool isPlaying = false;

	void Update(){
		if (!isPlaying) return;

		now = DateTime.Now.Hour * 60 *60 * 1000 + DateTime.Now.Minute * 60 * 1000 + 
		DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;

		elapsedTimeMillis = now - starttime;

		if (elapsedTimeMillis > PRE_RENDERED_TIME_MILLIS && playmode == PlayMode.PRE_RENDERED) {
			playmode = PlayMode.RLT_RENDERING;
			switchToRLTRendering ();
		}
		if(elapsedTimeMillis > WHOLE_PLAYING_TIME_MILLS){
			MainConrtroller.I.StopPlay ();
		}
	}


	public void playMovie(){
		playmode = PlayMode.PRE_RENDERED;
		starttime = DateTime.Now.Hour * 60 *60 * 1000 + DateTime.Now.Minute * 60 * 1000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
		isPlaying = true;
	}

	public void stopMovie(){
		isPlaying = false;
	}

	public void pauseMovie(){
		isPlaying = false;
	}

	private void switchToRLTRendering(){
		
	}
}