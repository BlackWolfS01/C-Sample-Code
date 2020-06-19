using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject playerCon;

    public float BaseModifier;
    private Rigidbody m_Rigidbody;
    public void Awake()
    {
        playerController = playerCon.GetComponent<PlayerController>();
        m_Rigidbody = this.GetComponent<Rigidbody>();
        m_Rigidbody.useGravity = false;
    }

    public void ApplyLeftInertia(float throwMultiplier, float strengthMultiplier)
    {
        if (!m_Rigidbody.useGravity)
            m_Rigidbody.useGravity = true;
        m_Rigidbody.AddRelativeForce((Vector3.forward * ((throwMultiplier * BaseModifier) * 
            (1.0f + strengthMultiplier))) + (Vector3.up * ((throwMultiplier * BaseModifier 
                * (1.0f + strengthMultiplier))) + (Vector3.left * ((throwMultiplier * BaseModifier)) 
                    * (1.0f + strengthMultiplier))));
        m_Rigidbody.AddRelativeTorque(Vector3.right * ((throwMultiplier * BaseModifier) 
            * (1.0f + strengthMultiplier)));
    }

    public void ApplyForwardInertia(float throwMultiplier, float strengthMultiplier)
    {
        if (!m_Rigidbody.useGravity)
            m_Rigidbody.useGravity = true;
        m_Rigidbody.AddRelativeForce((Vector3.forward * ((throwMultiplier * BaseModifier) * 
            (1.0f + strengthMultiplier))) + (Vector3.up * ((throwMultiplier * BaseModifier) 
                * (1.0f + strengthMultiplier))));
        m_Rigidbody.AddRelativeTorque(Vector3.right * ((throwMultiplier * BaseModifier) 
            * (1.0f + strengthMultiplier)));
    }

    public void ApplyRightInertia(float throwMultiplier, float strengthMultiplier)
    {
        if (!m_Rigidbody.useGravity)
            m_Rigidbody.useGravity = true;
        m_Rigidbody.AddRelativeForce((Vector3.forward * ((throwMultiplier * BaseModifier)
            * (1.0f + strengthMultiplier))) + (Vector3.up * ((throwMultiplier * BaseModifier) 
                * (1.0f + strengthMultiplier))) + (Vector3.right * ((throwMultiplier * BaseModifier) 
                    * (1.0f + strengthMultiplier))));
        m_Rigidbody.AddRelativeTorque(Vector3.right * ((throwMultiplier * BaseModifier) 
            * (1.0f + strengthMultiplier)));
    }

    public void Destroy()
    {
        StartCoroutine(DestroyTimer());
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
        playerController.GetComponent<PlayerController>().Reset();
    }
}
