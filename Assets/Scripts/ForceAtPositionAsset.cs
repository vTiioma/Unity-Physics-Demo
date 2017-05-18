using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ForceAtPositionAsset : MonoBehaviour {
    [Tooltip("Force vector in world coordinates")]
    public Vector3 force = new Vector3(3.0f, 3.0f, 3.0f);
    [Tooltip("The way in which the force is being applied to the target")]
    public ForceMode mode = ForceMode.Impulse;
    private Collider myCollider;
    private Rigidbody myBody;

    private Rigidbody body {
        get {
            if (this.myBody == null)
                this.myBody = this.GetComponent<Rigidbody>();

            return this.myBody;
        }
    }

    private Collider coll {
        get {
            if (this.myCollider == null) {
                this.myCollider = this.GetComponent<Collider>();
            }

            return this.myCollider;
        }
    }

    private void Start() {
        ExplosionManager.instance.onRaycastHit += this.OnRaycastHit;
    }

    private void OnRaycastHit(RaycastHit hit) {
        if (hit.collider == this.coll) {
            this.body.AddForceAtPosition(force, hit.point, mode);
        }
    }
}
