using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingPot : MonoBehaviour
{
    // when declaring variables we need to determine their access, normally it would just be with things like "public" or "private" but with Unity we have some more options
    // public - Show up in inspector and accessible by other scripts
    // [SerialiseField] private - Show up in inspector, not accessible by other scripts
    // [HideInInspector] public - Doesn't show in inspector, accessible by other scripts
    // private - Doesn't show in inspector, not accessible by other scripts
    public int currentTemp;
    [SerializeField] private float currentFill;
    [HideInInspector] public bool isFull;
    private float maxCapacity;
    private int frameCount;

    // Start is called before the first frame update
    void Start()
    {
        currentFill = 500;
        frameCount = 600;
    }

    // Update is called once per frame
    void Update()
    {
        if(frameCount == 60)
        {
            frameCount = 0;
            currentTemp = currentTemp + 1;
        }
        else if (frameCount > 60)
        {
            Debug.LogError("We messed up, frameCount went to high");
            frameCount = 0;
        }
        else
        {
            frameCount++;
        }
          
       
    }
}