using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<string> gameName = new List<string>();

    private List<int> ids;
    
    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start() {
        while(ids.Count != gameName.Count) { 
            int r = Random.Range(0, gameName.Count -1);

            if (!ids.Contains(r)) {
                ids.Add(r);
            }
            r++;
            if (!ids.Contains(r)) {
                ids.Add(r);
            }
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
