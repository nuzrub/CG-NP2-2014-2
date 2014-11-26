using UnityEngine;
using System.Collections;

public class BGM_Controller : MonoBehaviour {
    public static BGM_Controller instance;
    public AudioClip intro;
    public AudioClip plan;
    public AudioClip emergency;
    public AudioClip moonshift;
    public AudioClip mad;
    public AudioClip dota;


	void Start () {
        audio.clip = intro;
        audio.Play();
        audio.loop = true;
        instance = this;
	}

    public static void PlayIntro() {
        instance.changeAudio(instance.intro);
    }
    public static void PlayPlan() {
        instance.changeAudio(instance.plan);
    }
    public static void PlayEmergency() {
        instance.changeAudio(instance.emergency);
    }
    public static void PlayMoonshift() {
        instance.changeAudio(instance.moonshift);
    }
    public static void PlayMad() {
        instance.changeAudio(instance.mad);
    }
    public static void PlayDota() {
        instance.changeAudio(instance.dota);
        instance.audio.loop = false;
    }

    private void changeAudio(AudioClip newclip) {
        audio.Stop();
        audio.clip = newclip;
        audio.Play();
    }
}
