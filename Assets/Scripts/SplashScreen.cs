using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{

    public string sceneToLoad;
    public int secToLoad;

    // Start is called before the first frame update
    void Start()
    {

        Invoke("OpenNextScene", secToLoad);

    }

    void OpenNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
