using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float damage;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if(!collision.gameObject.CompareTag("Head") && !collision.gameObject.CompareTag("Enemy"))
                Destroy(gameObject);
            

            if(collision.gameObject.CompareTag("Player"))
            {
                if (PlayerMovement.Instance != null)
                    PlayerMovement.Instance.TakeDamage(damage);
            }

        }
    }
}
