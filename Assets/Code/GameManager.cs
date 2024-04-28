using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /* (<--- btw this is another way to leave a comment across multiple lines)
    This is a GameManager a very important script, this is how you will transfer
    information between objects and call on it's various submanagers for things like:
    Playing Audio
    Checking Game State
    Scoreing/Time keeping
    User Interfaces
    Saving and loading
    Inventories
    Interactable Objects
    Player Controllers
    Enemies Stats (if we had any)
    and just about anything else that needs to hold data really


    Bellow here you'll see a summmary tag, this can be used to give information in visual studio
    via the IntelliSense, which is the "autocorrect" and tooltip system you see while coding
    hover you mouse over the public static variable "Instance" and you'll see a tooltip.
    */
    /// <summary>
    /// This is how you get a reference to the one and only Game Manager, You should set this in your classes on Start()
    /// </summary>
    public static GameManager Instance;
    public Grabbable currentlyHeld;

    private void Awake()
    {
        if(Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            currentlyHeld = null;
        }
        else if (gameObject != this)
        {
            Destroy(gameObject);
        }

        /*
        What we have here is called a Singleton or Singleton pattern, this makes it so there can only
        be one instance of this object at all times, additionally we use the DontDestroyOnLoad()
        function so that when we load a new scene this object instance will persist along with the data
        */
    }

    public Vector3 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
