using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    int score;
    [SerializeField] TMP_Text scoreTMP;

    private float timer = 0f;
    public float delayAmount;

    bool pause;

    void Start()
    {
        pause = false;
        score = 0;
        timer = 0;

        scoreTMP.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(!pause)
        {
            timer += Time.deltaTime;

            if (timer >= delayAmount)
            {
                timer = 0f;
                score++;
            }

            scoreTMP.text = score.ToString();
        }
    }

    public void ResetScore()
    {
        score = 0;
        timer = 0;
    }

    public void Pause()
    {
        pause = true;
    }

    public void incrementScoreBypassedObstacle()
    {
        score += 5;
    }
}
