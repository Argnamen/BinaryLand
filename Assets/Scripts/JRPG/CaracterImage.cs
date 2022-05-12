using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;

public class CaracterImage : MonoBehaviour
{
    private static List<GameObject> ImageList = new List<GameObject>();

    private void Sort()
    {
        GameObject saveObject;
        for (int k = 0; k < ImageList.Count; k++)
            for (int i = 0; i < ImageList.Count; i++)
            {
                if ((i + 1) < ImageList.Count)
                {
                    if (ImageList[i].transform.localPosition.y < ImageList[i + 1].transform.localPosition.y)
                    {
                        saveObject = ImageList[i];
                        ImageList[i] = ImageList[i + 1];
                        ImageList[i + 1] = saveObject;
                    }
                    else
                    {
                        saveObject = ImageList[i + 1];
                        ImageList[i + 1] = ImageList[i];
                        ImageList[i] = saveObject;
                    }
                }
            }
    }

    private async void ImageSvipeAnimation()
    {
        Sort();

        for(int i = 0; i < ImageList.Count; i++) 
        {

            if (this.gameObject == ImageList[0])
            {
                this.gameObject.transform.DOLocalMoveY(ImageList[ImageList.Count - 1].transform.localPosition.y, 0.5f);
            }
            else if (this.gameObject == ImageList[1])
            {
                this.gameObject.transform.DOLocalMoveY(ImageList[0].transform.localPosition.y, 0.5f);
            }
            else if (this.gameObject == ImageList[2])
            {
                this.gameObject.transform.DOLocalMoveY(ImageList[1].transform.localPosition.y, 0.5f);
            }

            await Task.Delay(1 * 500);
        }
    }

    private async void StartImageSvipeAnimation()
    {
        Sort();


    }

        private void OnEnable()
    {
        ImageList.Add(this.gameObject);

        EventList.Swipe += ImageSvipeAnimation;
    }

    private void OnDestroy()
    {
        ImageList.Clear();

        EventList.Swipe -= ImageSvipeAnimation;
    }
}
