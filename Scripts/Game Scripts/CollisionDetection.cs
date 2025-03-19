using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Coins"))
        {
            Debug.Log("Collide with = " + collision.gameObject.name);

            //Destroy enemy
            Destroy(collision.gameObject);

            // increase 1 points
            UIController.instance.AddScore(1);
        }

        if (collision.gameObject.tag.Equals("SuperCoins"))
        {
            Debug.Log("Collide with = " + collision.gameObject.name);

            //Destroy enemy
            Destroy(collision.gameObject);

            // increase 2 points
            UIController.instance.AddScore(2);
        }
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log("Collide with = " + collision.gameObject.name);

            // Destroy Player
            Destroy(gameObject);

            if (MusicSoundController.instance != null)
            {
                MusicSoundController.instance.DeadPlayerSound();
            }

            if (UIController.instance != null)
            {
                UIController.instance.OpenLevelFailedPopUp();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collide with = " + other.gameObject.name);
        if (other.gameObject.tag.Equals("FallZone"))
        {
            // game over
            if (UIController.instance != null)
            {
                UIController.instance.OpenLevelFailedPopUp();
            }

            if (MusicSoundController.instance != null)
            {
                MusicSoundController.instance.DeadPlayerSound();
            }

        }
    }
}
