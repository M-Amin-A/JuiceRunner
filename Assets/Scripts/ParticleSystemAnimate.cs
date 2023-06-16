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
        AnimationClip newClip = Instantiate(clip);

        float startTime = 0;
        float startValue = characterTransform.position.x;
        float endTime = 1;
        float endValue = 2.5f;
        AnimationCurve curve = AnimationCurve.Linear(startTime, startValue, endTime, endValue);
        string relativeObjectName = string.Empty; // Means the object holding the animator component
        newClip.SetCurve(relativeObjectName, typeof(Transform), "localPosition.x", curve);

        AnimatorOverrideController animatorOverrideController= (AnimatorOverrideController)GetComponent<Animator>().runtimeAnimatorController;
        GetComponent<Animator>().runtimeAnimatorController = Instantiate(animatorOverrideController);
        animatorOverrideController = (AnimatorOverrideController)GetComponent<Animator>().runtimeAnimatorController;

        KeyValuePair<AnimationClip, AnimationClip> pair = new(clip, newClip);
        List<KeyValuePair<AnimationClip, AnimationClip> > list = new();
        list.Add(pair);

        animatorOverrideController.ApplyOverrides(list);
        
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
