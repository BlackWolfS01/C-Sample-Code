using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool tap, swipeUp, swipeDown, swipeLeft, swipeRight, swipeUpLeft, swipeUpRight, swipeDownLeft, swipeDownRight;
    private bool isDragging = false;
    private Vector2 startTouch, swipeDelta;

    private Vector2 mouseOrigin;
    private Vector2 touchOrigin;

    private void Update()
    {
        tap = swipeUp = swipeDown = swipeLeft = swipeRight = swipeUpLeft = swipeUpRight = swipeDownLeft = swipeDownRight = false;
        #region Standalone Input
        if (Input.GetMouseButtonDown(0))
        {
            mouseOrigin = Input.mousePosition;
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 mouseEnd = Input.mousePosition;
            isDragging = false;
            Reset();
        }
        #endregion
        #region Mobile Input
        if (Input.touches.Length != 0)
        {
            Touch myTouch = Input.touches[0];
            if (myTouch.phase == TouchPhase.Began)
            {
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if (myTouch.phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragging = false;
                Reset();
            }
        }
        #endregion
        //Calculate the distance
        swipeDelta = Vector2.zero;
        if (isDragging)
        {
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        if (swipeDelta.magnitude > 125)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            Debug.Log("X Axis: " + x + "Y Axis: " + y);
            #region Directional Modifiers
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                swipeLeft = (x < 0 && (y > -15 || y < 15)) ? true : false;
                swipeRight = (x > 0 && (y > -15 || y < 15)) ? true : false;
                swipeUpLeft = (x < -15 && y > 15) ? true : false;
                swipeUpRight = (x > 15 && y > 15) ? true : false;
                swipeDownLeft = (x < -15 && y < -15) ? true : false;
                swipeDownRight = (x > 15 && y < -15) ? true : false;
            }
            else
            {
                swipeDown = (y < 0 && (x > -15 || x < 15)) ? true : false;
                swipeUp = (y > 0 && (x > -15 || x < 15)) ? true : false;
            }
            #endregion

            Reset();
        }
    }

    public void Reset()
    {
        startTouch = swipeDelta = Vector3.zero;
        isDragging = false;
    }

    public bool Tap { get { return tap; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUpLeft { get { return swipeUpLeft; } }
    public bool SwipeUpRight { get { return swipeUpRight; } }
    public bool SwipeDownLeft { get { return swipeDownLeft; } }
    public bool SwipeDownRight { get { return swipeDownRight; } }
}
