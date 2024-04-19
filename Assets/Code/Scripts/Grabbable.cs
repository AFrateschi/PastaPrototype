using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : InteractableObject
{
    private bool isHeld;
    private Rigidbody2D rigidbody;
    private GameManager gameManager;

    private void Awake()
    {
        isHeld = false;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ToggleGrab()
    {
        if (isHeld)
        {
            Drop();
        }
        else
        {
            PickUp();
        }
    }

    private void PickUp()
    {
        Debug.Log(gameObject.name + " Is Picked Up");

        isHeld = true;
        rigidbody.velocity = Vector2.zero;
        rigidbody.angularVelocity = 0;
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }

    private void Drop()
    {
        Debug.Log(gameObject.name + " Is Dropped");

        isHeld = false;
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }

    public void DoRotate(int _input)
    {
        Vector3 rot = transform.rotation.eulerAngles;
        rot.z += _input;
        transform.rotation = Quaternion.Euler(rot);
    }


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(isHeld)
        {
            // TODO: add offset for mouse postion on object
            Vector2 mouse = gameManager.GetMousePos();

            transform.position = mouse;
        }
    }
}
