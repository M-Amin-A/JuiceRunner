using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject sampleGround;
    public FruitGenerator fruitGenerator;

    private Transform characterTransform;
   
    private Queue<GameObject> grounds = new Queue<GameObject>();

    public GameObject gameDataObject;
    private GameData gameData;

    private const float initialCharacterPosition = -1000f;
    private const int numberOfGroundsInGame = 5;
    void Start()
    {
        gameData = gameDataObject.GetComponent<GameData>();

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


        //generate fruits

        float leftLimit = characterTransform.gameObject.GetComponent<Character>().leftLimit+0.3f;
        float rightLimit = characterTransform.gameObject.GetComponent<Character>().rightLimit-0.3f;

        float downLimit = zPosition - sampleGround.transform.localScale.z / 2 + 0.3f;
        float upLimit = zPosition + sampleGround.transform.localScale.z / 2 - 0.3f;


        Vector3 fruitPosition = new Vector3(Random.Range(leftLimit, rightLimit),
            characterTransform.position.y,
            Random.Range(downLimit, upLimit));

        fruitGenerator.generate(gameData.getUnclaimedFruitType(),fruitPosition);

    }
}
