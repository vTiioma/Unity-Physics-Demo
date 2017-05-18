using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ExplosionAsset : MonoBehaviour {
    [Tooltip("The force of the explosion (which may be modified by distance)")]
    public float explosionForce = 5.0f;
    [Tooltip("The radius of the sphere within which the explosion takes place")]
    public float explosionRadius = 3.0f;
    [Tooltip("Adjustment to the apparent position of the explosion to make it seem to lift objects")]
    public float upwardsModifier = 1.0f;
    [Tooltip("The method used to apply the force to its target")]
    public ForceMode mode = ForceMode.Impulse;

    private Rigidbody myBody;

    private Rigidbody body {
        get {
            if (this.myBody == null)
                this.myBody = this.GetComponent<Rigidbody>();

            return this.myBody;
        }
    }

    private void Start () {
        ExplosionManager.instance.onRaycastHit += this.OnRaycastHit;
	}

    private void OnRaycastHit (RaycastHit hit) {
        this.body.AddExplosionForce(explosionForce, hit.point, explosionRadius, upwardsModifier, mode);
    }
}
