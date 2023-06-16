using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemAnimate : MonoBehaviour
{
    // Start is called before the first frame update
    public AnimationClip clip;
    public Transform characterTransform;

    void Start()
    {
        float startTime = 0;
        float startValue = characterTransform.position.x;
        float endTime = 1;
        float endValue = 2.5f;
        AnimationCurve curve = AnimationCurve.Linear(startTime, startValue, endTime, endValue);
        string relativeObjectName = string.Empty; // Means the object holding the animator component
        clip.SetCurve(relativeObjectName, typeof(Transform), "localPosition.x", curve);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void disableObject()
    {
        gameObject.SetActive(false);
    }
}
