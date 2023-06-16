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

    public GameObject tree;

    private const float initialCharacterPosition = -1000f;
    private const int numberOfGroundsInGame = 5;

    private const float fruitGenerationPropabability = 0.2f;
    private const int numberOfGroundLinesForFruitGeneration = 10;
    void Start()
    {
        gameData = gameDataObject.GetComponent<GameData>();

        characterTransform = transform;
        for(int i=0;i<numberOfGroundsInGame;i++)
        {
            generateNewGround(initialCharacterPosition + (i + 1) * sampleGround.transform.localScale.z);
        }
    }

    void Update()
    {
        if (gameData.gameFinished) return;

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

        float leftLimit = characterTransform.gameObject.GetComponent<Character>().leftLimit+0.5f;
        float rightLimit = characterTransform.gameObject.GetComponent<Character>().rightLimit-0.5f;

        float downLimit = zPosition - sampleGround.transform.localScale.z / 2 + 0.5f;
        float upLimit = zPosition + sampleGround.transform.localScale.z / 2 - 0.5f;

        int speciallyGeneratedFruitLine = Random.Range(0, numberOfGroundLinesForFruitGeneration-1);

        for (int i = 0; i < numberOfGroundLinesForFruitGeneration; i++)
        {
            float fruitLineWidth = sampleGround.transform.localScale.z / numberOfGroundLinesForFruitGeneration;
            float fruitZPosition = fruitLineWidth * i + fruitLineWidth / 2 + (zPosition - sampleGround.transform.localScale.z / 2);
            
            Vector3 fruitPosition = new Vector3(Random.Range(leftLimit, rightLimit),
            characterTransform.position.y,
            fruitZPosition);

            if (i == speciallyGeneratedFruitLine)
            {
                fruitGenerator.generate(gameData.getUnclaimedFruitType(), fruitPosition);
            }
            else
            {
                float dice = Random.Range(0f, 1f);
                if(dice<fruitGenerationPropabability)
                    fruitGenerator.generateRandom(fruitPosition);
            }
        }

        GameObject newTree=Instantiate(tree);
        newTree.transform.position = new Vector3(0,0,zPosition);
    }
}
