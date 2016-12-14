using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioListener))]
public class SoundController : MonoBehaviour {

	[SerializeField]
	private AudioSource bgm;

	public void playSound(){
		bgm.Play ();
	}

	public void stopSound(){
		bgm.Stop ();
	}

	public void pauseSound(){
		bgm.Pause ();
	}
}
