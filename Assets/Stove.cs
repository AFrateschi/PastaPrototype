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
        Hot = false;
    }

    private void OnMouseDown()
    {
        Hot = !Hot;
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
