using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snin : MonoBehaviour
{
    [SerializeField] float xVal;

    [SerializeField] float speed, amplitude, clampedAmp;
    [SerializeField] float changePerSec;

    [SerializeField] float minAmplitude, maxAmplitude;

    [SerializeField] bool isReverse;

    bool isOver;
    [SerializeField] TrailRenderer secondTrail;
    [SerializeField] GameObject particles;

    private void Start() 
    {
        isOver = false;
    }

    void Update()
    {
        if(!isOver)
        {
            // formerly there was Horizontal instead of vertical here
            if (Input.GetButtonUp("Vertical"))
            {
                if(amplitude > maxAmplitude)
                {
                    amplitude = maxAmplitude;
                }
            }

            if (Input.GetButtonDown("Vertical"))
            {
                if(amplitude < minAmplitude)
                {
                    amplitude = minAmplitude;
                }
            }

            if(Input.GetAxis("Vertical") == 1)
            {
                amplitude += changePerSec * Time.deltaTime;
            }
            else if(Input.GetAxis("Vertical") == 0)
            {
                amplitude -= changePerSec * Time.deltaTime;
            }

            clampedAmp = Mathf.Clamp(amplitude, minAmplitude,maxAmplitude);

            xVal = Mathf.Sin(Time.time * speed) * clampedAmp;

            if(isReverse)
                xVal *= -1;

            transform.position = new Vector3(xVal,transform.position.y,transform.position.z);
        }
        else if(isOver)
        {
            if(Mathf.Abs(xVal)  > 0)
            {
                    // amplitude -= changePerSec * Time.deltaTime;

                    
                    // clampedAmp = Mathf.Clamp(amplitude, minAmplitude,maxAmplitude);

                    // xVal = Mathf.Sin(Time.time * speed) * clampedAmp;

                    // if(isReverse)
                    //     xVal *= -1;

                    // transform.position = new Vector3(xVal,transform.position.y,transform.position.z);
            } 
        }
    }

    public GoFor _over;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("coll"))
        {
            _over.over= true;
            var main =_over.particlesBG.main;
            main.gravityModifier = 0;
            main.simulationSpeed = 0;
            isOver = true;
            GetComponent<TrailRenderer>().enabled = false;
            secondTrail.enabled = false;
            
            if(particles != null)
                particles.SetActive(true);
        }    
    }
}
