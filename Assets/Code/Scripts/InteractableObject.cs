using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour, IInterface
{
    [SerializeField] private UnityEvent primaryInteraction;
    [SerializeField] private UnityEvent secondaryInteraction;

    UnityEvent IInterface.OnPrimary
    {
        get => primaryInteraction;
        set => primaryInteraction = value;
    }

    UnityEvent IInterface.OnSecondary
    {
        get => secondaryInteraction;
        set => secondaryInteraction = value;
    }

    public void PrimaryInteract() => primaryInteraction.Invoke();
    public void SecondaryInteract() => secondaryInteraction.Invoke();

    public void PrimaryTest()
    {
        Debug.Log("Testing Primary Interactable Object");
    }

    public void SecondaryTest()
    {
        Debug.Log("Testing Secondary Interactable Object");
    }

}
