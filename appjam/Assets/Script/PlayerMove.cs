using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float Speed = 0;
    public GameObject PLR;
    private Vector3 beforeposition;
    private bool stop;
    private void Start()
    {
        stop = false;
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Move(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        if(Input.GetMouseButtonUp(0))
        {
            beforeposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            beforeposition.z = 0;
            stop = true;
           
        }
        if (Speed > 0 && stop == true)
        {
            Speed -= Time.deltaTime*12;
            transform.position = Vector3.MoveTowards(transform.position, beforeposition, Speed * Time.deltaTime);
          
        }
    }

    void Move(Vector3 target)
    {
        target.z = 0;
            stop = false;
            Speed = 5;
            transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.deltaTime);
    }
}
