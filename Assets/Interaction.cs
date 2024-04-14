using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    [SerializeField] private PlayerInput input;

    private void Awake()
    {

        input = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        input.actions["Primary Interact"].performed += DoPrimaryInteract;
        input.actions["Secondary Interact"].performed += DoSecondaryInteract;
    }

    private void OnDisable()
    {
        input.actions["Primary Interact"].performed -= DoPrimaryInteract;
        input.actions["Secondary Interact"].performed -= DoSecondaryInteract;
    }

    private void DoPrimaryInteract(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("PRIMARY INTERACTION");
    }

    private void DoSecondaryInteract(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("SECONDARY INTERACTION");
    }
}
