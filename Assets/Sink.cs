using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    [SerializeField] public BoxCollider2D waterCol;
    [SerializeField] public BoxCollider2D sinkKnob;
    [SerializeField] private bool sinkOn;
    [SerializeField] public GameObject water;
    [SerializeField] public float flowRate;
    public CookingPot currentlyFilling;
    // Start is called before the first frame update
    private void Awake()
    {
        WaterOff();    
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (sinkOn != true)
        {
            WaterOn();
        }
        else
        {
            WaterOff();
        }

    }
    private void WaterOn()
    {
        water.SetActive(true);
        sinkOn = true;
        if (currentlyFilling != null) 
        {
            Debug.Log("Water on filling");
            currentlyFilling.StartFilling(flowRate);
        }
    }
    private void WaterOff()
    {
        water.SetActive(false);
        sinkOn = false;
        if(currentlyFilling != null)
        {
            currentlyFilling.StopFilling();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("entered");
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.rigidbody.gameObject.CompareTag("Heatable"))
            {
                Debug.Log("Heatable found");
                if (currentlyFilling == null)
                {
                    Debug.Log("currentlyFilling set");
                    currentlyFilling = contact.rigidbody.gameObject.GetComponent<CookingPot>();

                }
                if(sinkOn)
                {
                    currentlyFilling.StartFilling(flowRate);
                }
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.rigidbody.gameObject == currentlyFilling && currentlyFilling != null) 
        {
            currentlyFilling.StopFilling();
            currentlyFilling = null;
        }
    }

}
