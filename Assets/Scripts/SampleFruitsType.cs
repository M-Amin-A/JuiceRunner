using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleFruitsType : MonoBehaviour
{
    public FruitGenerator.FruitType fruitType;

    private void Update()
    {
        if (AppData.currentGameData != null && AppData.currentGameData.gameFinished)
            return;

        transform.Rotate(0, 40f * Time.deltaTime, 0, Space.World);

        if (transform.position.z < Camera.main.transform.position.z) 
        {
            enabled = false;
            gameObject.SetActive(false);
        }
    }
}
