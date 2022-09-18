using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private Transform pos1;
    [SerializeField] private Transform pos2;
    [SerializeField] private float checkingRadius;
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
    private float minZ;
    private float maxZ;

    private bool didSpawnFood;
    private bool didSpawnEnemy;


    [SerializeField] private GameObject spawnFood;
    [SerializeField] private GameObject spawnEnemy;


    private void Start()
    {
        minX = pos1.position.x;
        maxX = pos2.position.x;
        minY = pos1.position.y;
        maxY = pos2.position.y;
        minZ = pos1.position.z;
        maxZ = pos2.position.z;
    }

    private void Update()
    {
          
        if(!didSpawnEnemy)
        {
            didSpawnFood = true;
        }

        if(!didSpawnFood)
        {
            didSpawnFood = true;
            Invoke(nameof(SpawnFood), 3f);
        }
    }

    private void ResetSpawn()
    {
        didSpawnFood=false;
    }
    private void SpawnFood()
    {
        bool checking = true;
        Vector3 randomPos = new Vector3(0,0,0);
        while (checking)
        {
            randomPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
            checking = CheckingMeasures(randomPos);
        }
        Debug.Log(randomPos);
        RandomSpawn(spawnFood,randomPos);
        //Invoke()
        ResetSpawn();
    }

    private bool CheckingMeasures(Vector3 pos)
    {
        Collider2D collision = Physics2D.OverlapCircle(pos, checkingRadius);

        if (collision != null)
            return true;
        return false;
    }

    private void RandomSpawn(GameObject obj, Vector3 pos)
    {
        Instantiate(obj, pos, Quaternion.identity);
    }
}
