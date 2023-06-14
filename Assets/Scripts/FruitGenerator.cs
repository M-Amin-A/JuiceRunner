using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitGenerator : MonoBehaviour
{
    private const int numberOfMeshes = 13;
    public GameObject sampleApple;
    public GameObject sampleBanana;
    public GameObject sampleCarrot;
    public GameObject sampleCherry;
    public GameObject samplePurpleGrapes;
    public GameObject sampleGreenGrapes;
    public GameObject sampleLemon;
    public GameObject sampleOrange;
    public GameObject samplePear;
    public GameObject samplePineapple;
    public GameObject sampleStrawberry;
    public GameObject sampleTomato;
    public GameObject sampleWatermelon;


    public void generateRandom(Vector3 position)
    {
        FruitType fruitType = getRandomFruitType();

        GameObject sampleFruit = getSampleOfFruitType(fruitType);
        GameObject instance=GameObject.Instantiate(sampleFruit);

        instance.GetComponent<SampleFruitsType>().fruitType = fruitType;
        instance.transform.position = position;
    }

    public void generate(FruitType fruitType,Vector3 position)
    {
        GameObject sampleFruit = getSampleOfFruitType(fruitType);
        GameObject instance = GameObject.Instantiate(sampleFruit);

        instance.GetComponent<SampleFruitsType>().fruitType = fruitType;
        instance.transform.position = position;
    }


    public GameObject getSampleOfFruitType(FruitType type)
    {
        switch(type)
        {
            case FruitType.APPLE:
                return sampleApple;
            case FruitType.BANANA:
                return sampleBanana;
            case FruitType.CARROT:
                return sampleCarrot;
            case FruitType.CHERRY:
                return sampleCherry;
            case FruitType.PURPLE_GRAPES:
                return samplePurpleGrapes;
            case FruitType.GREEN_GRAPES:
                return sampleGreenGrapes;
            case FruitType.LEMON:
                return sampleLemon;
            case FruitType.ORANGE:
                return sampleOrange;
            case FruitType.PEAR:
                return samplePear;
            case FruitType.PINE_APPLE:
                return samplePineapple;
            case FruitType.STRAWBERRY:
                return sampleStrawberry;
            case FruitType.TOMATO:
                return sampleTomato;
            case FruitType.WATERMENON:
                return sampleWatermelon;
        }
        return null;
    }
    public FruitType getFruitTypeByIndex(int index)
    {
        switch(index)
        {
            case 0: 
                return FruitType.APPLE;
            case 1:
                return FruitType.BANANA;
            case 2:
                return FruitType.CARROT;
            case 3:
                return FruitType.CHERRY;
            case 4:
                return FruitType.PURPLE_GRAPES;
            case 5:
                return FruitType.GREEN_GRAPES;
            case 6:
                return FruitType.LEMON;
            case 7:
                return FruitType.ORANGE;
            case 8:
                return FruitType.PEAR;
            case 9:
                return FruitType.PINE_APPLE;
            case 10:
                return FruitType.STRAWBERRY;
            case 11:
                return FruitType.TOMATO;
            case 12:
                return FruitType.WATERMENON;
        }
        return FruitType.STRAWBERRY;
    }

    public int getSpriteIndexOfFruitType(FruitType type)
    {
        switch (type)
        {
            case FruitType.APPLE:
                return 3;
            case FruitType.BANANA:
                return 1;
            case FruitType.CARROT:
                return 12;
            case FruitType.CHERRY:
                return 7;
            case FruitType.PURPLE_GRAPES:
                return 6;
            case FruitType.GREEN_GRAPES:
                return 9;
            case FruitType.LEMON:
                return 0;
            case FruitType.ORANGE:
                return 10;
            case FruitType.PEAR:
                return 5;
            case FruitType.PINE_APPLE:
                return 2;
            case FruitType.STRAWBERRY:
                return 8;
            case FruitType.TOMATO:
                return 11;
            case FruitType.WATERMENON:
                return 4;
        }

        return 0;
    }

    public enum FruitType
    {
        APPLE,
        BANANA,
        CARROT,
        CHERRY,
        PURPLE_GRAPES,
        GREEN_GRAPES,
        LEMON,
        ORANGE,
        PEAR,
        PINE_APPLE,
        STRAWBERRY,
        TOMATO,
        WATERMENON
    }
    public FruitType getRandomFruitType()
    {
        int randomIndex = Random.Range(0, numberOfMeshes - 1);
        return getFruitTypeByIndex(randomIndex);
    }

}
