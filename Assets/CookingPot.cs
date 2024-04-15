using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CookingPot : MonoBehaviour
{
    // when declaring variables we need to determine their access, normally it would just be with things like "public" or "private" but with Unity we have some more options
    // public - Show up in inspector and accessible by other scripts
    // [SerialiseField] private - Show up in inspector, not accessible by other scripts
    // [HideInInspector] public - Doesn't show in inspector, accessible by other scripts
    // private - Doesn't show in inspector, not accessible by other scripts
    public float currentTemp;
    private float transferTemp;
    [SerializeField] private float currentFill;
    [HideInInspector] public bool isFull;
    private float maxCapacity;
    bool isCooking = false;
    bool isFilling = false;
    private float flowRate;
    [SerializeField] public Transform snapOffset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
          
       
    }

    public void StartFilling(float _flowRate)
    { 
        flowRate = _flowRate;
        InvokeRepeating("Fill", 0, 0.3f);
    }
    public void StopFilling() 
    {
        CancelInvoke("Fill");
    }
    void Fill()
    {
        currentFill += flowRate;
    }
    public void StartCooking(float _transferTemp)
    {
        if (isCooking)
        {
            transferTemp = _transferTemp;
            Debug.Log("CookingPot Cooking at " + _transferTemp + " Degrees per second");
            InvokeRepeating("Cooking", 0, 0.3f);
        }
    }

    public void StopCooking()
    {
        CancelInvoke("Cooking");
    }

    void Cooking()
    {
        currentTemp += transferTemp;
    }
}