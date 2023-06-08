using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustumerRequest
{
    private ArrayList fruitCountPairsQueue = new ArrayList(); 

    public CustumerRequest(KeyValuePair<Fruit.FruitType,int>[] fruitPairs)
    {
        for (int i = 0; i < fruitPairs.Length; i++)
            fruitCountPairsQueue.Add(fruitPairs[i]);
    }
}
