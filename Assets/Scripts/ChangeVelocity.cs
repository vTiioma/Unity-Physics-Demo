using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ChangeVelocity : MonoBehaviour {
    [Tooltip("The key which will trigger the velocity change")]
    public KeyCode trigger = KeyCode.Space;
    [Space]
    [Tooltip("The amount of time it takes for the velocity to change to the target velocity")]
    [Range(0.0f, 5.0f)]
    public float duration = 1.0f;
    [Tooltip("Have the increate in velocity be uneffected by timescale")]
    public bool ignoreTimescale = true;
    [Space]
    [Tooltip("The velocity the rigidbody will change to")]
    public Vector3 targetVelocity = new Vector3(0.0f, 5.0f, 0.0f);

    private Rigidbody myBody;

    private Rigidbody body {
        get {
            if (this.myBody == null)
                this.myBody = this.GetComponent<Rigidbody>();

            return this.myBody;
        }
    }

    private void Update () {
		if (Input.GetKeyDown(trigger)) {
            StartCoroutine("LerpVelocity");
        }
	}

    private IEnumerator LerpVelocity () {
        Vector3 startVelocity = this.body.velocity;
        Vector3 endVelocity = this.targetVelocity;
        float progress = 0.0f;
        float timeLength = this.duration;

        while (progress < timeLength && timeLength > 0) {
            this.body.velocity = Vector3.Lerp(startVelocity, endVelocity, progress/timeLength);

            yield return new WaitForEndOfFrame();
            progress += this.ignoreTimescale ? Time.unscaledDeltaTime : Time.smoothDeltaTime;
        }

        this.body.velocity = endVelocity;
    }
}
