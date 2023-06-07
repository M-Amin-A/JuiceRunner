using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitMeshAssign : MonoBehaviour
{
    private const int numberOfMeshes = 3;
    public Mesh appleMesh;
    public Mesh bananaMesh;
    public Mesh pineAppleMesh;

    private FruitType fruitType;

    void Start()
    {
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        int randomIndex = Random.Range(0, numberOfMeshes-1);
        fruitType = getFruitTypeByIndex(randomIndex);
        meshFilter.mesh = getMeshOfFruitType(fruitType);
    }

    public enum FruitType
    {
        APPLE,
        BANANA,
        PINE_APPLE
    }

    public Mesh getMeshOfFruitType(FruitType type)
    {
        switch(type)
        {
            case FruitType.APPLE:
                return appleMesh;
            case FruitType.BANANA:
                return bananaMesh;
            case FruitType.PINE_APPLE:
                return pineAppleMesh;
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
                return FruitType.PINE_APPLE;
        }
        return FruitType.PINE_APPLE;
    }

    public FruitType GetFruitType()
    {
        return fruitType;
    }

}
