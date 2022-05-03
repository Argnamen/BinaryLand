using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenshotLoader : MonoBehaviour
{
    public static Texture2D screenshotSceene;
    public static byte[] byteArrayImage;

    [SerializeField] private bool CutUp;

    private void Update()
    {
        if (screenshotSceene != null)
        {
            if (CutUp)
            {
                this.gameObject.GetComponent<Image>().enabled = true;
                screenshotSceene.LoadImage(byteArrayImage);
                this.gameObject.GetComponent<Image>().sprite = Sprite.Create(
                    screenshotSceene, 
                    new Rect(0, screenshotSceene.height/2, screenshotSceene.width, 
                    screenshotSceene.height/2), 
                    Vector2.zero);
            }
            else
            {
                this.gameObject.GetComponent<Image>().enabled = true;
                screenshotSceene.LoadImage(byteArrayImage);
                this.gameObject.GetComponent<Image>().sprite = Sprite.Create(
                    screenshotSceene, 
                    new Rect(0, 0, screenshotSceene.width, 
                    screenshotSceene.height/2), 
                    Vector2.zero);
            }

            PlayANimation.OnAnimation = true;
        }
    }
}
