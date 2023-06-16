using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    public float fruitGenerationProbability;
    public int timeInSeconds;
    public Queue customerRequestsQueue=new Queue();

    public LevelData(CustumerRequest[] custumerRequests,int timeInSecond, float fruitGenerationProbablity)
    {
        for (int i = 0; i < custumerRequests.Length; i++)
            customerRequestsQueue.Enqueue(custumerRequests[i]);

        this.timeInSeconds = timeInSecond;
        this.fruitGenerationProbability = fruitGenerationProbablity;
    }

}
