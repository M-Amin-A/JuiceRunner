using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 0.05f;
    public Transform cameraTransform;
    public Transform sampleGroundTransform;

    private float leftLimit;
    private float rightLimit;

    void Start()
    {
        leftLimit = -sampleGroundTransform.localScale.x/2f + 1f;
        rightLimit = sampleGroundTransform.localScale.x/2f - 1f;

    }

    void Update()
    {
        checkKeyPress();
        checkTouchInput();

        transform.Translate(new Vector3(0, 0, speed));
        cameraTransform.position += new Vector3(0, 0, speed);
    }

    private void checkTouchInput()
    {
        if(Input.touchCount>0)
        {
            Touch touch = Input.touches[0];
            if(touch.phase == TouchPhase.Moved)
            {
                Vector3 characterNewPosition = new Vector3(touch.deltaPosition.x / 100.0f, 0, 0) + transform.position;
                if (characterNewPosition.x < leftLimit)
                    transform.position = new Vector3(leftLimit, transform.position.y, transform.position.z);
                else if (characterNewPosition.x > rightLimit)
                    transform.position = new Vector3(rightLimit, transform.position.y, transform.position.z);
                else
                    transform.position = characterNewPosition;
            }
        }
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
