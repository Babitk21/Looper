using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGetter : MonoBehaviour
{
    public Score sc;
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("score"))
        {
            sc.incrementScoreBypassedObstacle();
            sc.GetComponentInChildren<ParticleSystem>().Play();
        }

        if(other.CompareTag("coll"))
        {
            sc.Pause();
            // you can save in playerprefs here
        }
    }
}
