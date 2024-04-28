using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions inputs;
    private InputAction primaryInteract;
    private InputAction secondaryInteract;

    private void Awake()
    {
        inputs = new PlayerInputActions();
    }

    private void OnEnable()
    {
        primaryInteract = inputs.Player.PrimaryInteract;
        secondaryInteract = inputs.Player.SecondaryInteract;
    }
    private void OnDisable()
    {
        primaryInteract.Disable();
        secondaryInteract.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
