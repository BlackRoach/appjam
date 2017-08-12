using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeelShot : MonoBehaviour {

    public GameObject gray;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Shot", 0.3f, 0.3f);
	}

    void Shot()
    {
        Instantiate(gray, transform.position, transform.rotation);
    }
}
