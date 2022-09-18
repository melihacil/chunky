using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private Transform pos1;
    [SerializeField] private Transform pos2;
    private bool didSpawnFood;
    private bool didSpawnEnemy;

    private void Update()
    {
          
        if(!didSpawnEnemy)
        {
            didSpawnFood = true;
        }

        if(!didSpawnFood)
        {
            didSpawnFood = true;
        }
    }
}
