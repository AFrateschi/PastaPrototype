using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Appliance : InteractableObject
{
    private bool isOn;
    [SerializeField] public BoxCollider2D button;
    [SerializeField] public UnityEvent cookwareEnter;

    // collider check on hit enter/exit for interactableObjects
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
