using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IInterface
{
    public UnityEvent OnPrimary { get; protected set; }
    public UnityEvent OnSecondary { get; protected set; }
    public UnityEvent OnScrollUp { get; protected set; }
    public UnityEvent OnScrollDown { get; protected set; }
    public void PrimaryInteract();
    public void SecondaryInteract();
    public void ScrollUp();
    public void ScrollDown();
}
