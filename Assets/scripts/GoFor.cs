using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoFor : MonoBehaviour {
    [SerializeField] float speed, clampedSpeed;

    [SerializeField] float minSpeed,maxSpeed;

    [SerializeField] float changeSpeed;

    public bool over;
    int x;
    [SerializeField] GameObject UI1,UI2;

    public ParticleSystem particlesBG;
    

    private void Start() {
        over = false;
        x= 0;
    }
    
    void Update()
    { 
        if(!over)
        {
            if (Input.GetButtonUp("Vertical"))
            {
                if(speed > maxSpeed)
                {
                    speed = maxSpeed;
                }
            }

            if (Input.GetButtonDown("Vertical"))
            {
                if(speed < minSpeed)
                {
                    speed = minSpeed;
                }
            }

            if(Input.GetAxis("Vertical") == 1)
            {
                speed += changeSpeed * Time.deltaTime;
            }
            else if(Input.GetAxis("Vertical") == 0)
            {
                speed -= changeSpeed * Time.deltaTime;
            }

            clampedSpeed = Mathf.Clamp(speed, minSpeed,maxSpeed);

            transform.position += new Vector3(0,clampedSpeed,0);   
        }
        else if(over)
        {
            if(speed > 0.001f)
            {
                if(x == 0)
                {
                    x++;
                    Invoke("BringUI", 2);
                }

                speed -= changeSpeed * 2 * Time.deltaTime;
            }
        }
    }



    public void BringUI()
    {
        if(x == 1)
        {
            UI1.SetActive(true);
            UI2.SetActive(true);
        }
    }
}
