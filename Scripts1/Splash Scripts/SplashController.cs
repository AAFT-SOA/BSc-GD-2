using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadHomeScene());
    }

    IEnumerator LoadHomeScene()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("Home");
    }
}
