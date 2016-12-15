using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MovieController : MonoBehaviour {

	public enum PlayMode {
		PRE_RENDERED,
		RLT_RENDERING
	}

	public PlayMode playmode = PlayMode.PRE_RENDERED;
		
	public const int PRE_RENDERED_TIME_MILLIS = 240000;
	public const int WHOLE_PLAYING_TIME_MILLS = 300000;

	private int starttime;
	private int now;
	private int elapsedTimeMillis;

	private bool isPlaying = false;

	[SerializeField]
	private RenderTexture outputCamSource1;
	[SerializeField]
	private RenderTexture outputCamSource2;
	[SerializeField]
	private RenderTexture outputCamSource3;

	[SerializeField]
	private RenderTexture preRenderedMovieSource1;
	[SerializeField]
	private RenderTexture preRenderedMovieSource2;
	[SerializeField]
	private RenderTexture preRenderedMovieSource3;

	[SerializeField]
	private RenderTexture rltRenderingMovieSource1;
	[SerializeField]
	private RenderTexture rltRenderingMovieSource2;
	[SerializeField]
	private RenderTexture rltRenderingMovieSource3;

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
		outputCamSource1 = rltRenderingMovieSource1;
		outputCamSource2 = rltRenderingMovieSource2;
		outputCamSource3 = rltRenderingMovieSource3;
	}

	private void switchToPreRendered(){
		outputCamSource1 = preRenderedMovieSource1;
		outputCamSource2 = preRenderedMovieSource2;
		outputCamSource3 = preRenderedMovieSource3;
	}
}