using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{

    [SerializeField] float minRandomTime, maxRandomTime;

    [SerializeField] GameObject _prefab;

    public void Start()
    {
        Invoke("RandomThing", 0.5f);
    }
 
    public void RandomThing()
    {
      float randomTime = Random.Range(minRandomTime, maxRandomTime);
 
      CreateObstacles();
 
      Invoke("RandomThing", randomTime);
 
    }

    public void CreateObstacles()
    {
        Instantiate(_prefab, transform.position, Quaternion.identity);
    }

    
}
