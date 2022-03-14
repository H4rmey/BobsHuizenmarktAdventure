using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTheObjectsScript : MonoBehaviour {

    public Camera camera;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start() {
    }

    void FixedUpdate() {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit, layerMask)) {
            Transform objectHit = hit.transform;
            Debug.DrawRay(ray.origin, ray.direction, Color.red);
            Debug.Log(objectHit);
        }
    }
}