using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    private int levelNumber;
    public Queue customerRequestsQueue=new Queue();

    public LevelData(CustumerRequest[] custumerRequests)
    {
        for (int i = 0; i < custumerRequests.Length; i++)
            customerRequestsQueue.Enqueue(custumerRequests[i]);
    }

}
