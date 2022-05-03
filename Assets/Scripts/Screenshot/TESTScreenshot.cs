using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTScreenshot : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScreenshotHandler.TakeScreenshot_Static(Screen.width, Screen.height);
        }
    }
}
