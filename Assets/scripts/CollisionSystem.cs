using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystem : MonoBehaviour
{
    Vector3 rot;


    // Start is called before the first frame update
    void Start()
    {
        rot = new Vector3(Random.Range(10,80),Random.Range(10,80),Random.Range(10,80));

        float val = Random.Range(.3f,1.4f);

        transform.localScale = new Vector3(val,val,val);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (rot * Time.deltaTime);  
    }
}
