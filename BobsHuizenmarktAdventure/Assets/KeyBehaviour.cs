using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour {

    public int uses = 1;
    
    public KeyLockID klid;
    
    public Camera camera;
    public LayerMask layerMask;

    public GameObject keyObject;

    // Start is called before the first frame update
    void Start() {

    }

    void FixedUpdate() {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        
        if ( Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask) ) {
            Debug.DrawRay(ray.origin, ray.direction, Color.red);

            keyObject.transform.position = hit.point;
        }

        if (uses <= 0) {
            Destroy(this);
        }
    }
}