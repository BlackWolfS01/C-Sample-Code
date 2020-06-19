using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public bool kidTrigger;
    public bool motherTrigger;
    public GameController gameController;
    private Material material;

    private bool changeColor = false;
    public void Update()
    {
        material = this.gameObject.GetComponent<MeshRenderer>().material;
        material.color = Color.green;
        if(changeColor)
            material.color = Color.blue;
    }

    public void OnCollisionEnter(Collision collision)
    {
        var objectTag = collision.gameObject.tag;
        
        if(objectTag == "Marshmallow" && this.gameObject.tag == "Floor")
        {
            collision.gameObject.GetComponent<ThrowObject>().Destroy();
        }

        if(objectTag == "Marshamllow" && this.gameObject.tag == "TArget 1")
        {
            gameController.playerScore += 10;
            collision.gameObject.GetComponent<ThrowObject>().Destroy();
        }
    }

}
