using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        checkKeyPress();
    }

    private void checkKeyPress()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-0.5f, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(0.5f, 0, 0));
        }
    }
}
