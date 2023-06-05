using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float speed = 0.2f;
    public GameObject sampleGround;

    private Queue<GameObject> grounds = new Queue<GameObject>();

    private const int numberOfGroundsInGame = 5;
    private const int groundInitialOffset = 20;
    void Start()
    {
        for(int i=0;i<numberOfGroundsInGame;i++)
        {
            GameObject ground = GameObject.Instantiate(sampleGround);
            ground.SetActive(true);
            ground.transform.position = new Vector3(0, 0, i*ground.transform.localScale.z - groundInitialOffset);
            grounds.Enqueue(ground);
        }
    }

    void Update()
    {
        foreach(GameObject ground in grounds)
        {
            ground.transform.Translate(new Vector3(0, 0, -speed));
        }
    }
}
