using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleFruitsType : MonoBehaviour
{
    public FruitGenerator.FruitType fruitType;

    private void Update()
    {
        transform.Rotate(0, 0.5f, 0, Space.World);
    }
}
