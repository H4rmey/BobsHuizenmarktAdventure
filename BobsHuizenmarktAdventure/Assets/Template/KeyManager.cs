using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    private GameObject currentKey;

    public Camera camera;
    public LayerMask layerMask;

    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        bool rayhit = Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask);

        if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Key" && rayhit) {
            layerMask = layerMask & ~(1 << 7); //disable key layer
            currentKey = hit.transform.gameObject;
        }

        if (Input.GetMouseButtonUp(0)) {
            layerMask = layerMask | (1 << 7); //enable key layer
            currentKey = null;
        }

        if (currentKey) {
            float y = currentKey.GetComponent<BoxCollider>().size.y;
            currentKey.transform.position = hit.point + new Vector3(0, y/2, 0);
        }
    }
}
