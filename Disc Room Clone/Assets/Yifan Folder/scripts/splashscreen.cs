using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splashscreen : MonoBehaviour
{
    public void switchToSplashScreen(string sceneName)
    {

        Application.LoadLevel(sceneName);
    }
}
