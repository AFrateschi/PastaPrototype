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

    [SerializeField] public Color32 knobOn;
    [SerializeField] public Color32 knobOff;
    [SerializeField] public Color32 burnerOn;
    [SerializeField] public Color32 burnerOff;

    [SerializeField] public float transferTemp;
    public CookingPot currentlyCooking;

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
        knobSprite.color = knobOn;
        burnerSprite.color = burnerOn;

        if (currentlyCooking != null)
        {
            currentlyCooking.StartCooking(transferTemp);
        }
    }
    private void BurnerOff()
    {
        Hot = false;
        knobSprite.color = knobOff;
        burnerSprite.color = burnerOff;

        if (currentlyCooking != null)
        {
            currentlyCooking.StopCooking();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.rigidbody.gameObject.CompareTag("Heatable"))
            {
                if (currentlyCooking == null)
                {
                    currentlyCooking = contact.rigidbody.gameObject.GetComponent<CookingPot>();
                }
                else
                {
                    Debug.Log("This Burner is already occupied!");
                }

                if (Hot)
                {
                    Debug.Log("Cooking at " + transferTemp + "...");
                    currentlyCooking.StartCooking(transferTemp);
                }
                else
                {
                    Debug.Log("Man's not hot");
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.rigidbody.gameObject == currentlyCooking.gameObject)
        {
            Debug.Log("Stopping Cooking...");
            currentlyCooking.StopCooking();
            currentlyCooking = null;
        }
    }
}
