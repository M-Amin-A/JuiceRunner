using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustumerRequest
{
    public Dictionary<FruitGenerator.FruitType, int> fruitCountPairs = new(); 
    public CustumerRequest(KeyValuePair<FruitGenerator.FruitType,int>[] fruitPairs)
    {
        for (int i = 0; i < fruitPairs.Length; i++)
            fruitCountPairs.Add(fruitPairs[i].Key, fruitPairs[i].Value);
    }
}
