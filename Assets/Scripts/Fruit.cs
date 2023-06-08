using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private const int numberOfMeshes = 13;
    public Mesh appleMesh;
    public Mesh bananaMesh;
    public Mesh carrotMesh;
    public Mesh cherryMesh;
    public Mesh purpleGrapesMesh;
    public Mesh greenGrapesMesh;
    public Mesh lemonMesh;
    public Mesh orangeMesh;
    public Mesh pearMesh;
    public Mesh pineAppleMesh;
    public Mesh strawberryMesh;
    public Mesh tomatoMesh;
    public Mesh watermelonMesh;

    private FruitType fruitType;

    void Start()
    {
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();

        int randomIndex = Random.Range(0, numberOfMeshes-1);
        fruitType = getFruitTypeByIndex(randomIndex);
        meshFilter.mesh = getMeshOfFruitType(fruitType);

        Debug.Log(randomIndex);
    }

    public Mesh getMeshOfFruitType(FruitType type)
    {
        switch(type)
        {
            case FruitType.APPLE:
                return appleMesh;
            case FruitType.BANANA:
                return bananaMesh;
            case FruitType.CARROT:
                return carrotMesh;
            case FruitType.CHERRY:
                return cherryMesh;
            case FruitType.PURPLE_GRAPES:
                return purpleGrapesMesh;
            case FruitType.GREEN_GRAPES:
                return greenGrapesMesh;
            case FruitType.LEMON:
                return lemonMesh;
            case FruitType.ORANGE:
                return orangeMesh;
            case FruitType.PEAR:
                return pearMesh;
            case FruitType.PINE_APPLE:
                return pineAppleMesh;
            case FruitType.STRAWBERRY:
                return strawberryMesh;
            case FruitType.TOMATO:
                return tomatoMesh;
            case FruitType.WATERMENON:
                return watermelonMesh;
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
    public FruitType GetFruitType()
    {
        return fruitType;
    }
}
