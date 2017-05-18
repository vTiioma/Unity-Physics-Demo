using System.Collections;
using UnityEngine;

public class TimescaleChanger : MonoBehaviour {
    public AnimationCurve ease = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);
    [Space]
    [Space]
    [Range(0.0f, 1.0f)]
    public float targetTimescale = 0.25f;
    [Range(0.0f, 5.0f)]
    public float duration = 1.0f;
    [Range(0.0f, 1.0f)]
    public float delay = 0.0f;
    [Space]
    public bool useMouseClick = true;
    [Space]
    public KeyCode activationKey = KeyCode.Return;
    public KeyCode resetKey = KeyCode.Space;

    private void Awake() {
        Application.targetFrameRate = 60;
    }

    private void Update () {
		if (Input.GetMouseButtonDown(0) && this.useMouseClick) {
            // start changing time scale
            StartCoroutine("LerpTimescale");
        }
        if (Input.GetKeyDown(this.activationKey)) {
            // start changing time scale
            StartCoroutine("LerpTimescale");
        }
        if (Input.GetKeyDown(this.resetKey)) {
            Time.timeScale = 1.0f;
        }
	}

    private IEnumerator LerpTimescale () {
        float startTimescale = Time.timeScale;
        float endTimescale = this.targetTimescale;
        float progress = this.delay * -1.0f;
        float timeLength = this.duration;

        while (progress < timeLength) {
            Time.timeScale = Mathf.LerpUnclamped(startTimescale, endTimescale, ease.Evaluate (Mathf.Clamp01(progress / timeLength)));

            yield return new WaitForEndOfFrame();
            progress += Time.unscaledDeltaTime;
        }
    }
}
