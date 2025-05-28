using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if(!collision.gameObject.CompareTag("Head") && !collision.gameObject.CompareTag("Enemy"))
                Destroy(gameObject);            
        }
    }
}
