using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InFeel : MonoBehaviour {

    public GameObject gray;
    public int Speed;

	// Use this for initialization
	void Start ()
    {
        int r = Random.Range(0, 361);
        transform.Rotate(new Vector3(0, 0, r), Space.Self);
        InvokeRepeating("Shot", 0.3f, 0.3f);
	}

    void Update()
    {
        transform.Translate(Speed * Time.deltaTime, 0, 0);
    }

    void Shot()
    {
        Instantiate(gray, transform.position, transform.rotation);
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
