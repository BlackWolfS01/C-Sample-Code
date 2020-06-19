using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeTest : MonoBehaviour {

    public Slider slider;
    public Swipe swipeControls;
    public Transform player;
    public Vector3 desiredPosition;

    private Vector3 startPosition;
    private Rigidbody m_Rigidbody;
    
    public void Start()
    {
        swipeControls = this.GetComponent<Swipe>();
        m_Rigidbody = this.GetComponent<Rigidbody>();
        m_Rigidbody.useGravity = false;
        player = this.transform;
        startPosition = player.transform.position;
        desiredPosition = startPosition;
    }

    public void Update()
    {
        
        #region Test Region One
        if (swipeControls.SwipeUp)
        {
            Debug.Log("Swipe Up");
            ApplyDirectionalForce(0);
        }
        if (swipeControls.SwipeUpLeft)
        {
            Debug.Log("Swipe Up and Left");
            ApplyDirectionalForce(1);
        }
        if (swipeControls.SwipeUpRight)
        {
            Debug.Log("Swipe Up and Right");
            ApplyDirectionalForce(2);
        }
        if(swipeControls.SwipeRight)
        {
            Debug.Log("Swipe Right");
            desiredPosition += Vector3.right;
        }
        if(swipeControls.SwipeLeft)
        {
            Debug.Log("Swipe Left");
            desiredPosition += Vector3.left;
        }
        #endregion
        
        
        player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, 3.0f * Time.deltaTime);   
    }

    private void ApplyDirectionalForce(int directionSelect)
    {
        
        if (!m_Rigidbody.useGravity)
            m_Rigidbody.useGravity = true;
        switch (directionSelect)
        {
            case 0:
                float s = slider.normalizedValue;
                m_Rigidbody.AddRelativeForce((Vector3.forward * (12.5f * (1.0f + s))) + (Vector3.up * (10.0f * (1.0f + s))));
                m_Rigidbody.AddRelativeTorque(Vector3.right * 25.0f);
                float ch1 = Random.Range(0.0f, 1.0f);
                StartCoroutine(AlterTrajectory(ch1));
                break;
            case 1:
                float s1 = slider.normalizedValue;
                m_Rigidbody.AddRelativeForce((Vector3.forward * (12.5f * (1.0f + s1)) + (Vector3.up * (10.0f * (1.0f + s1))) + (Vector3.left * (12.5f * (1.0f + s1)))));
                m_Rigidbody.AddRelativeTorque(Vector3.right * 25.0f);
                float ch2 = Random.Range(0.0f, 1.0f);
                StartCoroutine(AlterTrajectory(ch2));
                break;
            case 2:
                float s2 = slider.normalizedValue;
                m_Rigidbody.AddRelativeForce((Vector3.forward * (12.5f * (1.0f + s2))) + (Vector3.up * (10.0f * (1.0f + s2))) + (Vector3.right * (12.5f * (1.0f + s2))));
                m_Rigidbody.AddRelativeTorque(Vector3.right * 25.0f);
                float ch3 = Random.Range(0.0f, 1.0f);
                StartCoroutine(AlterTrajectory(ch3));
                break;
        }   
    }

    IEnumerator AlterTrajectory(float chance)
    {
        yield return new WaitForSeconds(0.5f);
        if(chance >= 0.8f)
        {
            float dir = Random.Range(0.0f, 1.0f);
            float str = Random.Range(5.0f, 25.0f);
            if (dir <= 0.5f)
                m_Rigidbody.AddRelativeForce(Vector3.left * str);
            else if(dir >= 0.51f )
                m_Rigidbody.AddRelativeForce(Vector3.right * str);
        }
    }
}
