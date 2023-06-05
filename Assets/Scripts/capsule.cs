using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsule : MonoBehaviour
{
    public Transform anotherTransform;
    void Start()
    {
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-0.5f, 0, 0));
            anotherTransform.Translate(new Vector3(0.5f, 0, 0));
        }   
        
    }

    void FixedUpdate()
    {

    }
}
