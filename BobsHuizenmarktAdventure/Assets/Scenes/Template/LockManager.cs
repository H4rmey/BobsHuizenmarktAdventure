using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockManager : MonoBehaviour
{
    public List<OnCollisionWithkey> locks;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < locks.Count; i++)
        {
            OnCollisionWithkey onCollisionWithkey = locks[i];

            if (onCollisionWithkey.hasBeenTriggered)
            {
                locks.Remove(onCollisionWithkey);
                Destroy(onCollisionWithkey.gameObject);
            }
        }

        if (locks.Count == 0)
        {
            Debug.Log("you completed game :)");
        }
    }
}
