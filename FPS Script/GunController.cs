using UnityEngine;

public class GunController : MonoBehaviour
{
    public float Range;
    public Camera _cam;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {   
        RaycastHit hit;
        if(Physics.Raycast(_cam.transform.position,_cam.transform.forward,out hit,Range))
        {
            Debug.Log("Shoot........");
            if (hit.collider.tag.Equals("Vehicle"))
            {
                Debug.Log("hit vehicle name = " + hit.collider.gameObject.name);

                GameObject parent = hit.collider.gameObject.transform.parent.gameObject;
                Destroy(parent);
            }

            if (hit.collider.tag.Equals("Enemy"))
            {
                Debug.Log("hit Enemy name = " + hit.collider.gameObject.name);

                Destroy(hit.collider.gameObject);
            }
        }

    }

}
