using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject obstacle;
    public float spawnTimer = 1.75f;

    void Start()
    {
        
    }

    void Update()
    {

    }

    void SpawnObstacle()
    {
        Instantiate(obstacle, transform.position, Quaternion.identity);
    }

    public void StartSpawn()
    {
        InvokeRepeating("SpawnObstacle", 0f, spawnTimer);
    }

    public void StopSpawn(bool clean = false)
    {
        CancelInvoke("SpawnObstacle");
        if(clean)
        {
            Object[] allObstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            foreach(GameObject obstacle in allObstacles)
            {
                Destroy(obstacle);
            }
        }
    }
}
