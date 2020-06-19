 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThrow : MonoBehaviour
{

    public Swipe swipeControl;
    public Transform player;
    private Vector3 desiredPosition;

    private Rigidbody m_Rigidbody;
    private bool grav;
    void Start()
    {
        player = this.transform;
        /*
        m_Rigidbody = GetComponent<Rigidbody>();
        grav = false;
        m_Rigidbody.useGravity = false;*/
    }

    void Update()
    {
        if (swipeControl.SwipeUp)
            desiredPosition += Vector3.up;
        else if (swipeControl.SwipeDown)
            desiredPosition += Vector3.down;
        else if (swipeControl.SwipeLeft)
            desiredPosition += Vector3.left;
        else if (swipeControl.SwipeRight)
            desiredPosition += Vector3.right;
        player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, 3.0f * Time.deltaTime);
        /*
        if (m_Rigidbody.useGravity == false)
            grav = true;

        if (grav)
        {
            m_Rigidbody.useGravity = true;
            if (m_Rigidbody.useGravity == true)
                ApplyForce(10.0f, 10.0f, 500.0f);
           
        }

        if(Input.GetKey(KeyCode.Space))
        {
            ApplyDirectionalForce();
        }
        */
    }

    public void ApplyForce(float forwardMomentum, float upwardMomentum, float rotateSpeed)
    {
        m_Rigidbody.AddRelativeForce(Vector3.forward * forwardMomentum);
        m_Rigidbody.AddRelativeForce(Vector3.up * forwardMomentum);
        m_Rigidbody.AddRelativeTorque(Vector3.right * rotateSpeed);
    }

    public void ApplyDirectionalForce()
    {
        var randDir = Random.Range(0.0f, 1.0f);
        var randStr = Random.Range(100.0f, 500.0f);
        if (randDir >= 0.0f && randDir <= 0.5f)
            m_Rigidbody.AddRelativeForce(Vector3.left * randStr);
        else if (randDir >= 0.51f && randDir <= 1.0f)
            m_Rigidbody.AddRelativeForce(Vector3.right * randStr);
    }
}