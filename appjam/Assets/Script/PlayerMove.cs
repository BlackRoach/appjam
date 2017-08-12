using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    [SerializeField]
    private float Speed = 0;
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
            beforeposition.z = -1;
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
        target.z = -1;
        stop = false;
        Speed = 5;
        transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.deltaTime);
    }
}
