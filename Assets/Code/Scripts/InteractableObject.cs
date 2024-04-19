using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour, IInterface
{
    [SerializeField] private UnityEvent primaryInteraction;
    [SerializeField] private UnityEvent secondaryInteraction;
    [SerializeField] private UnityEvent mouseScrollUp;
    [SerializeField] private UnityEvent mouseScrollDown;

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

    UnityEvent IInterface.OnScrollUp
    {
        get => mouseScrollUp;
        set => mouseScrollUp = value;
    }

    UnityEvent IInterface.OnScrollDown
    {
        get => mouseScrollDown;
        set => mouseScrollDown = value;
    }

    public void PrimaryInteract() => primaryInteraction.Invoke();
    public void SecondaryInteract() => secondaryInteraction.Invoke();
    public void ScrollUp() => mouseScrollUp.Invoke();
    public void ScrollDown() => mouseScrollDown.Invoke();

    public void PrimaryTest()
    {
        Debug.Log("Testing Primary Interactable Object");
    }

    public void SecondaryTest()
    {
        Debug.Log("Testing Secondary Interactable Object");
    }

    public void ScrollUpTest()
    {
        Debug.Log("Scroll Up");
    }

    public void ScrollDownTest()
    {
        Debug.Log("Scroll Down");
    }
}
