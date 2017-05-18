using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AddForce : MonoBehaviour {
    [Tooltip("The key which will trigger adding force")]
    public KeyCode trigger = KeyCode.Space;
    [Space]
    [Tooltip("Add force relative to the rigibody or using world coordinates")]
    public bool addRelativeForce = false;
    [Space]
    [Tooltip("The force being applied to the rigidbody")]
    public Vector3 force = new Vector3 (0.0f, 5.0f, 0.0f);
    [Tooltip("The type of force being applied")]
    public ForceMode mode = ForceMode.Force;

    private Rigidbody myBody;

    private Rigidbody body {
        get {
            if (this.myBody == null)
                this.myBody = this.GetComponent<Rigidbody>();

            return this.myBody;
        }
    }
	
	private void Update () {
        if (Input.GetKeyDown(this.trigger)) {
            if (addRelativeForce) {
                this.body.AddRelativeForce(this.force, this.mode);
            } else {
                this.body.AddForce(this.force, this.mode);
            }
        }
    }
}
