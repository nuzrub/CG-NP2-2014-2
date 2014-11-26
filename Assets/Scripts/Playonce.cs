using UnityEngine;
using System.Collections;

public class Playonce : MonoBehaviour {

    private bool played = false;

    void OnTriggerEnter() {
        if (played == false) {
            audio.PlayOneShot(audio.clip);
            played = true;
        }
    }
}
