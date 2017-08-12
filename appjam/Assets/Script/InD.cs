using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InD : MonoBehaviour {
    
    public int Speed;

    void Update()
    {
        transform.Translate(Speed * Time.deltaTime, 0, 0);
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
