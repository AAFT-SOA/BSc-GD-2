using System.Collections;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float Range;
    public int TotalBullets;
    int currentBulletCount;
    public Camera _cam;

    public float FireRate;
    float nextBullet;

    bool isReloadingGun;

    AudioSource audioSource;

    public AudioClip shootClip, reloadClip;

    public ParticleSystem MuzzleFlash;
    private void Awake()
    {
        currentBulletCount = TotalBullets;
    }

    private void Start()
    {
        if (GameUIController.instance != null)
            GameUIController.instance.UpdateBulletsCountUI(currentBulletCount);

        if (GameUIController.instance != null)
            GameUIController.instance.UpdateGunStatusTextUI("");

        audioSource = GetComponentInChildren<AudioSource>();
        audioSource.clip = shootClip;
    }


    void Update()
    {
        if (isReloadingGun)
            return;

        if (currentBulletCount <= 0)
        {
            if (GameUIController.instance != null)
                GameUIController.instance.UpdateGunStatusTextUI("Press \"R\" to Reload.");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }


        if (Input.GetButton("Fire1") && Time.time > nextBullet && currentBulletCount > 0)
        {
            nextBullet = Time.time + 1f / FireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        //------------------------------------ Muzzle Flash -------------------------------//
        if (MuzzleFlash != null)
        {
            MuzzleFlash.Play();
        }
        //---------------------------------------------------------------------------------//

        if (audioSource != null)
        {
            if (audioSource.clip == null)
                audioSource.clip = shootClip;

            if (audioSource.clip != null)
                audioSource.PlayOneShot(audioSource.clip);
        }


        //------------------------------------ Bullet Count --------------------------------//
        if (currentBulletCount > 0)
            currentBulletCount--;
        else
            currentBulletCount = 0;

        if (GameUIController.instance != null)
            GameUIController.instance.UpdateBulletsCountUI(currentBulletCount);
        //---------------------------------------------------------------------------------//


        //------------------------------------ Shoot --------------------------------------//
        RaycastHit hit;
        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, Range))
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
        //---------------------------------------------------------------------------------//
    }

    IEnumerator Reload()
    {
        isReloadingGun = true;

        if (audioSource != null)
        {
            if (audioSource.clip != null)
            {
                audioSource.clip = reloadClip;
                audioSource.PlayOneShot(audioSource.clip);
            }
        }


        if (GameUIController.instance != null)
            GameUIController.instance.UpdateGunStatusTextUI("Reloading gun ...");

        yield return new WaitForSeconds(2.5f);

        currentBulletCount = TotalBullets;
        if (GameUIController.instance != null)
            GameUIController.instance.UpdateBulletsCountUI(currentBulletCount);

        if (GameUIController.instance != null)
            GameUIController.instance.UpdateGunStatusTextUI("");

        isReloadingGun = false;

        audioSource.clip = null;
    }

}