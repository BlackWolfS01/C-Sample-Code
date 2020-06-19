using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Swipe SwipeControls;
    private ThrowObject throwObject;
    public Slider slider;

    public GameObject prefabMarshmallow;
    public Transform startPoint;
    private Vector3 startPosition;
    private Vector3 desiredPosition;
    private GameObject clone;

    public static bool ReadyToThrow;
    public bool Thrown;
    public void Start()
    {
        SwipeControls = this.GetComponent<Swipe>();
        desiredPosition = startPoint.transform.position;
        CreateObject();
    }

    public void Update()
    {
        if (clone != null)
        {
            float sliderValue = slider.value;
            float sliderValueNormalized = slider.normalizedValue;
            ThrowObject throwObject = clone.GetComponent<ThrowObject>();

            if (SwipeControls.SwipeUp)
            {
                Debug.Log("Player swipes up.");
                throwObject.ApplyForwardInertia(sliderValue, sliderValueNormalized);
                ReadyToThrow = false;
            }
            if (SwipeControls.SwipeUpLeft)
            {
                Debug.Log("Player swipes up to the left");
                throwObject.ApplyLeftInertia(sliderValue, sliderValueNormalized);
                ReadyToThrow = false;
            }
            if (SwipeControls.SwipeUpRight)
            {
                Debug.Log("Player swipes up to the right.");
                throwObject.ApplyRightInertia(sliderValue, sliderValueNormalized);
                ReadyToThrow = false;
            }
            if (SwipeControls.SwipeLeft)
            {
                Debug.Log("Player swipe to the left.");
                desiredPosition += new Vector3(-0.5f, 0, 0);
            }
            if (SwipeControls.SwipeRight)
            {
                Debug.Log("Player swipe to the right.");
                desiredPosition += new Vector3(0.5f, 0, 0);
            }

            if (ReadyToThrow)
                clone.transform.position = Vector3.MoveTowards(clone.transform.position, desiredPosition, 5.0f * Time.deltaTime);
        }
        
    }

    public void Reset()
    {
        ReadyToThrow = true;
        CreateObject();
        if(ReadyToThrow)
            Debug.Log("Reset Works");
    }

    public void CreateObject()
    {
       
        clone = Instantiate(prefabMarshmallow, startPoint.transform.position, startPoint.transform.rotation) as GameObject;
        
        //Thrown = false;
    }
}
