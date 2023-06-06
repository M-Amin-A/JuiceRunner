using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject sampleGround;
    public GameObject sampleFruit;

    private Transform characterTransform;
   
    private Queue<GameObject> grounds = new Queue<GameObject>();

    private const float initialCharacterPosition = -1000f;
    private const int numberOfGroundsInGame = 5;
    void Start()
    {
        characterTransform = transform;
        for(int i=0;i<numberOfGroundsInGame;i++)
        {
            generateNewGround(initialCharacterPosition + i * sampleGround.transform.localScale.z);
        }
    }

    void Update()
    {
        GameObject firstGround = grounds.Peek();

        if(characterTransform.position.z > firstGround.transform.position.z + sampleGround.transform.localScale.z)
        {
            grounds.Dequeue().SetActive(false);
            generateNewGround(grounds.Peek().transform.position.z + grounds.Count*sampleGround.transform.localScale.z);
        }
    }

    private void generateNewGround(float zPosition)
    {
        GameObject ground = GameObject.Instantiate(sampleGround);
        ground.SetActive(true);
        ground.transform.position = new Vector3(0, 0, zPosition);
        grounds.Enqueue(ground);

        GameObject fruit=Instantiate(sampleFruit);
        fruit.transform.position = new Vector3(0, fruit.transform.position.y, zPosition);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetType() == sampleFruit.GetType())
            collider.gameObject.transform.position += new Vector3(1, 1, 0);
    }
}
