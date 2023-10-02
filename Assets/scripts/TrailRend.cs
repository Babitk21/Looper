using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRend : MonoBehaviour
{
    [Header("Color Change Settings")]
    [SerializeField] Color[] colors = new Color[] { Color.red, Color.green, Color.blue };
    [SerializeField] float changeSpeed = 4;

    [Header("Debug Info")]
    [SerializeField] int currentIndex;
    [SerializeField] Color currentColor;
    [SerializeField] bool canChange;
    TrailRenderer tr;
    Renderer rendererr;

    void Start()
    {
        rendererr = GetComponent<Renderer>();
        tr = GetComponent<TrailRenderer>();
        canChange = true;
        currentColor = Color.white;
    }

    void Update()
    {
        if (!canChange) return;

        if (currentColor != colors[currentIndex])
        {
            currentColor = Color.Lerp(currentColor, colors[currentIndex], changeSpeed * Time.deltaTime);
            tr.endColor = currentColor;
            tr.startColor = currentColor;
            rendererr.material.color = currentColor;
            ChangeColor();
        }
        else
        {
            currentIndex++;
            currentIndex %= colors.Length;
        }
    }

    void ChangeColor()
    {
        //set the target color here to the currentColor

    }
}
