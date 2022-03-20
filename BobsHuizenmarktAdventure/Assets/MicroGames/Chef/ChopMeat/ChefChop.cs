using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefChop : MonoBehaviour
{
    public LockManager lm;

    public Quaternion rotation_start;
    public Quaternion rotation_end;
    
    public Vector3 position_start;
    public Vector3 position_end;

    public float speed = 0.5f;

    public bool startend = false;

    // Start is called before the first frame update
    void Start() {
        lm.e_endGame.AddListener(rotateChef);

        position_start = transform.position;    
        rotation_start = transform.rotation;
    }

    void Update() {
        if (startend) {
            transform.rotation = Quaternion.Slerp(rotation_start, rotation_end, speed);
            transform.position = Vector3.Slerp(position_start, position_end, speed);
            speed = speed + Time.deltaTime;
        }
    }

    void rotateChef() {
        startend = true;
    }
}
