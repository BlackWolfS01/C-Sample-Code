using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTest1 : MonoBehaviour
{
    public Swipe swipeControls;

    public void Start()
    {
        swipeControls = this.GetComponent<Swipe>();
    }

    public void Update()
    {
        if (swipeControls.SwipeUp)
            Debug.Log("Swipe Up");
        if (swipeControls.SwipeDown)
            Debug.Log("Swipe Down");
        if (swipeControls.SwipeLeft)
            Debug.Log("Swipe Left");
        if(swipeControls.SwipeRight)
            Debug.Log("Swipe Right");
        if(swipeControls.SwipeUpLeft)
            Debug.Log("Swo[e Up and Left");
        if (swipeControls.SwipeUpRight)
            Debug.Log("Swipe Up and Right");
        if(swipeControls.SwipeDownLeft)
            Debug.Log("Swipe Down and Left");
        if (swipeControls.SwipeDownRight)
            Debug.Log("Swipe Down and Right");
    }
}
