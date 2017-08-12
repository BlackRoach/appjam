using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float Speed = 0;
    public GameObject PLR;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Move(Camera.main.ScreenToWorldPoint(Input.mousePosition), 1);
        }
        if(Input.GetMouseButtonUp(0))
        {
            Move(Camera.main.ScreenToWorldPoint(Input.mousePosition), 2);
        }
    }

    void Move(Vector3 target, int a)
    {
        target.z = 0;
        if (a == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.deltaTime);
        }
        if(a == 2)
        {
            transform.position = Vector3.Lerp(PLR.transform.position , target, 1);
        }
    }

    void EndMove()
    {

    }
}
