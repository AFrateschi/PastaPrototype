using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    [SerializeField] public CircleCollider2D knob;
    [SerializeField] public BoxCollider2D burner;
    [SerializeField] private bool Hot;
    [SerializeField] private SpriteRenderer knobSprite;
    [SerializeField] private SpriteRenderer burnerSprite;
    private void Awake()
    {
        knob = GetComponent<CircleCollider2D>();
        burner = GetComponentInChildren<BoxCollider2D>();
        BurnerOff();
    }

    private void OnMouseDown()
    {

        if(Hot!=true)
        {
            BurnerOn();
         }
        else
        {
            BurnerOff();
        }
    }

    private void BurnerOn()
    {
        Hot = true;
        knobSprite.color = Color.red;
        burnerSprite.color = Color.red;
    }
    private void BurnerOff()
    {
        Hot = false;
        knobSprite.color = Color.gray;
        burnerSprite.color = Color.gray;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLLISION ENTER");
        foreach (ContactPoint2D contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
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
