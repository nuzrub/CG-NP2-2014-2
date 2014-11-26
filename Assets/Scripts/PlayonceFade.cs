using UnityEngine;
using System.Collections;

public class PlayonceFade : MonoBehaviour {

    public Light luz;
    public float start;
    public float end;
    public float time;

    private bool played = false;

    void OnTriggerEnter() {
        if (played == false) {
            StartCoroutine(fade());
            played = true;
        }
    }

    IEnumerator fade() {
        float cronometro = 0f;

        while (cronometro < time) {
            cronometro += Time.deltaTime;
            luz.intensity = Mathf.Lerp(start, end, cronometro / time);
            yield return null;
        }
    }
}
