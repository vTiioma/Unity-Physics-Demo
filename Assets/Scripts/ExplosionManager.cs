using System;
using UnityEngine;

public class ExplosionManager : MonoBehaviour {
    public event Action<RaycastHit> onRaycastHit;

    private static ExplosionManager reference;

    public static ExplosionManager instance {
        get {
            if (reference == null) {
                ExplosionManager[] references = FindObjectsOfType<ExplosionManager>();

                if (references.Length > 0) {
                    reference = references[0];
                } else {
                    reference = new GameObject("Scripts").AddComponent<ExplosionManager>();
                }
            }

            return reference;
        }
    }

	private void Update () {
		if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                if (onRaycastHit != null) {
                    onRaycastHit(hit);
                }
            }
        }
	}
}
