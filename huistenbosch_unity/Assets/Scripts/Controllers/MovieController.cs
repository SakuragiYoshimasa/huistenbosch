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
	public int PRE_RENDERED_TIME_MILLIS = 5000;
	public int WHOLE_PLAYING_TIME_MILLS = 80000;
	private int starttime;
	private int now;
	private int elapsedTimeMillis;
	private bool isPlaying = false;
	[SerializeField]
	private Spout.SpoutSender spoutSender;
	[SerializeField]
	private RenderTexture preRenderedMovieSource;
    [SerializeField]
    private preRenderMovie prerenderMovie;
	[SerializeField]
	private RenderTexture rltRenderingMovieSource;
    [SerializeField]
    private rtmRenderedMovie rltRnederingMovie;
    [SerializeField]
    private RenderTexture mappingTestTexture;
    [SerializeField]
    private RenderTexture blackTexture;
	
	void Update(){
		if (!isPlaying) return;

		now = DateTime.Now.Hour * 60 *60 * 1000 + DateTime.Now.Minute * 60 * 1000 + 
		DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
		elapsedTimeMillis = now - starttime;

		if (elapsedTimeMillis > PRE_RENDERED_TIME_MILLIS && playmode == PlayMode.PRE_RENDERED) {
			playmode = PlayMode.RLT_RENDERING;
			switchToRLTRendering ();
            Debug.Log("Finish PRE");
		}
		if(elapsedTimeMillis > WHOLE_PLAYING_TIME_MILLS){
			MainConrtroller.I.StopPlay ();
            Debug.Log("Finish RTL");
		}
	}
    public void setMappingMode() {
        spoutSender.texture = mappingTestTexture;
    }
    public void endMappingMode() {
        spoutSender.texture = blackTexture;
    }
	public void playMovie(){
		playmode = PlayMode.PRE_RENDERED;
		starttime = DateTime.Now.Hour * 60 *60 * 1000 + DateTime.Now.Minute * 60 * 1000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
		isPlaying = true;
		switchToPreRendered ();
	}
	public void stopMovie(){
		isPlaying = false;
        rltRnederingMovie.StopRLTRenderingMovie();
        spoutSender.texture = blackTexture;
	}
	public void pauseMovie(){
		isPlaying = false;
	}
	private void switchToRLTRendering(){
        prerenderMovie.StopPreRenderedMovie();
        playmode = PlayMode.RLT_RENDERING;
        spoutSender.texture = rltRenderingMovieSource;
        MainConrtroller.I.changePreviewScreen(PlayMode.RLT_RENDERING);
        rltRnederingMovie.StartRLTRenderingMovie();
    }
	private void switchToPreRendered(){
        spoutSender.texture = preRenderedMovieSource;
        MainConrtroller.I.changePreviewScreen(PlayMode.PRE_RENDERED);
        prerenderMovie.StartPreRenderedMovie();
    }
}