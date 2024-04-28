using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    // the layer mask helps us differentiate between objects when we raycast
    [SerializeField] private LayerMask interactableLayer;
    // this is how we're recieving our input data
    [SerializeField] private PlayerInput input;

    private GameManager gameManager;

    // on awake we get input, this script should be attached to the Main camera, our "player body"
    private void Awake()
    {
        input = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    // when this is enabled subscribe the events to the input
    private void OnEnable()
    {
        input.actions["Primary Interact"].performed += DoPrimaryInteract;
        input.actions["Secondary Interact"].performed += DoSecondaryInteract;
        input.actions["Scroll Up"].performed += DoScrollUp;
        input.actions["Scroll Down"].performed += DoScrollDown;
    }

    // when disabled unsubscribe events to input
    private void OnDisable()
    {
        input.actions["Primary Interact"].performed -= DoPrimaryInteract;
        input.actions["Secondary Interact"].performed -= DoSecondaryInteract;
        input.actions["Scroll Up"].performed -= DoScrollDown;
        input.actions["Scroll Down"].performed -= DoScrollDown;
    }

    // just a simple funciton to return our raycast from our mosue for u, this function goes (Orgin, Direction, Distance and layer mask
    private RaycastHit2D HandleRaycast()
    {
        return Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1000f, interactableLayer);
    }

    // We get our raycast information, check if the data is valid, then check to see if we can find the right base object so that we can call our interface
    private void DoPrimaryInteract(InputAction.CallbackContext callbackContext)
    {
        RaycastHit2D hit = HandleRaycast();
        
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.TryGetComponent(out InteractableObject interactable))
            {
                interactable.PrimaryInteract();
            }
        }
        else
        {
            // do dust particle effect if nothing to interact with
        }
    }

    // same as above for secondary interacation.
    private void DoSecondaryInteract(InputAction.CallbackContext callbackContext)
    {
        RaycastHit2D hit = HandleRaycast();

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.TryGetComponent(out InteractableObject interactable))
            {
                interactable.SecondaryInteract();
            }
        }
        else
        {
            // open context menu?
        }
    }

    private void DoScrollUp(InputAction.CallbackContext callbackContext)
    {
        RaycastHit2D hit = HandleRaycast();

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.TryGetComponent(out InteractableObject interactable))
            {
                interactable.ScrollUp();
            }
        }
    }

    private void DoScrollDown(InputAction.CallbackContext callbackContext)
    {
        RaycastHit2D hit = HandleRaycast();

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.TryGetComponent(out InteractableObject interactable))
            {
                interactable.ScrollDown();
            }
        }
    }
}