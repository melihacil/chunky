using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Positions and Valus")]
    [SerializeField] private Transform pos1;
    [SerializeField] private Transform pos2;
    [SerializeField] private float checkingRadius;
    [SerializeField] private float range;
    [SerializeField] private Transform playerPos;
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
    private float minZ;
    private float maxZ;


    [Header("GameObjects")]
    [SerializeField] private GameObject spawnFood;
    [SerializeField] private GameObject spawnFood_2;
    [SerializeField] private GameObject spawnEnemy;

    [Header("Timers")]
    [SerializeField] private float foodSpawnTime;
    [SerializeField] private float minFoodTimer;
    [SerializeField] private float enemySpawnTime;
    [SerializeField] private float minEnemyTimer;
    [SerializeField] private float reduceTimers;
    //Bools
    private bool didSpawnFood = false;
    private bool didSpawnEnemy;

    private void Awake()
    {
        FindObjectOfType<SoundManager>().PlaySource(0);
        Time.timeScale = 0f;
        Time.timeScale = 1f;
    }
    private void Start()
    {
        minX = pos1.position.x;
        maxX = pos2.position.x;
        minY = pos1.position.y;
        maxY = pos2.position.y;
        minZ = pos1.position.z;
        maxZ = pos2.position.z;



        Instantiate(spawnEnemy, pos1.position, Quaternion.identity);
    }

    private void Update()
    {

        if (!didSpawnEnemy)
        {
            Debug.Log("Spawning enemy");
            didSpawnEnemy = true;
            Invoke(nameof(SpawnEnemy), enemySpawnTime);
            enemySpawnTime -= reduceTimers;
            if (enemySpawnTime < minEnemyTimer)
                enemySpawnTime = minEnemyTimer;
        }

        if(!didSpawnFood)
        {
            Debug.Log("Spawning food");
            didSpawnFood = true;
            Invoke(nameof(SpawnFood), foodSpawnTime);
            foodSpawnTime -= reduceTimers;
            if (foodSpawnTime < minFoodTimer)
                foodSpawnTime = minFoodTimer;
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
        Debug.Log("Spawning");
        while (checking)
        {
            randomPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
            checking = CheckingMeasures(randomPos);
        }
        Debug.Log(randomPos);

        if(Random.Range(0,10) > 6)
            RandomSpawn(spawnFood,randomPos);
        else
            RandomSpawn(spawnFood_2, randomPos);
        //Invoke()
        didSpawnEnemy =false;
    }
    private void SpawnEnemy()
    {
        bool checking = true;
        Vector3 randomPos = new Vector3(0,0,0);
        Debug.Log("Spawning Enemy");
        randomPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        while (checking && ((randomPos - playerPos.position).magnitude < range))
        {
            randomPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
            checking = CheckingMeasures(randomPos);
        }
        Debug.Log(randomPos);
        RandomSpawn(spawnEnemy,randomPos);
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
