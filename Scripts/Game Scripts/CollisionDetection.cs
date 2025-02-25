using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {        
        if(collision.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log("Collide with = " + collision.gameObject.name);
            
            //Destroy enemy
            Destroy(collision.gameObject);

            UIController.instance.AddScore();
        }
    }
}
