using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private Transform pos1;
    [SerializeField] private Transform pos2;
    private bool didSpawnFood;
    private bool didSpawnEnemy;


    [SerializeField] private GameObject spawnFood;
    [SerializeField] private GameObject spawnEnemy;

    private void Update()
    {
          
        if(!didSpawnEnemy)
        {
            didSpawnFood = true;
        }

        if(!didSpawnFood)
        {
            didSpawnFood = true;
            Invoke()
        }
    }


    private void RandomSpawn(GameObject obj)
    {

    }
}
