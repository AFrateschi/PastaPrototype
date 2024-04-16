using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    [SerializeField] public CircleCollider2D knob;
    [SerializeField] public BoxCollider2D burner;
    [SerializeField] private bool Hot;

    // Sprite renderers for Knob an Burner objects
    [SerializeField] private SpriteRenderer knobSprite;
    [SerializeField] private SpriteRenderer burnerSprite;

    // colors for knob sprites
    [SerializeField] public Color32 knobOn;
    [SerializeField] public Color32 knobOff;
    [SerializeField] public Color32 burnerOn;
    [SerializeField] public Color32 burnerOff;

    [SerializeField] public float transferTemp;
    public CookingPot currentlyCooking;

    [SerializeField] GameObject snapPos;
    [SerializeField] float snapTolerance;
    public bool doSnap;
    Vector3 targetPos;

    private void Update()
    {
        if (doSnap)
        {
            SnapPot();
        }
    }

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



    private void SnapPot()
    {
        if (Vector3.Distance(currentlyCooking.snapOffset.position, snapPos.transform.position) <= snapTolerance && currentlyCooking != null)
        {
            Transform temp = currentlyCooking.transform;
            Vector2 vec = currentlyCooking.transform.position - targetPos;
            currentlyCooking.GetComponent<Rigidbody2D>().AddForce(vec);
        }
        else
        {
            doSnap = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("entered");
      //foreach (type ofName in Collection)
      //    do this
      // 
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.rigidbody.gameObject.CompareTag("Heatable"))
            {
                if (currentlyCooking == null && Vector2.Distance(contact.rigidbody.gameObject.GetComponent<CookingPot>().snapOffset.transform.position, snapPos.transform.position) <= snapTolerance)
                {
                    currentlyCooking = contact.rigidbody.gameObject.GetComponent<CookingPot>();

                    doSnap = true;
                    currentlyCooking.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    currentlyCooking.transform.rotation = Quaternion.Euler(0, 0, 0);
                    targetPos = snapPos.transform.position - currentlyCooking.snapOffset.localPosition;
                    currentlyCooking.transform.position = targetPos;
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
        Debug.Log("exit");
        if (collision.rigidbody.gameObject == currentlyCooking.gameObject && currentlyCooking != null)
        {
            Debug.Log("Stopping Cooking...");
            currentlyCooking.StopCooking();
            currentlyCooking = null;
            doSnap = false;
        }
    }
}
