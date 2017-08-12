using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGray : MonoBehaviour {
    public int Speed;
    bool bounce = true;

    void Start()
    {
        int r = Random.Range(0, 361);
        transform.Rotate(new Vector3(0, 0, r), Space.Self);
    }

    void Update() {
        transform.Translate(Speed * Time.deltaTime, 0, 0);

    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}