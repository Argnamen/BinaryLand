using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;

public class CaracterImage : MonoBehaviour
{
    private static List<GameObject> ImageList = new List<GameObject>();
    private static List<Vector3> ImageListTransform = new List<Vector3>();

    private void Sort()
    {
        RandomActionList();

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

        //RandomSort();
    }

    private void RandomSort()
    {
        GameObject saveObject;

        for (int i = 0; i < Buttons.ActionList.Count; i++)
        {
            switch (Buttons.ActionList[i])
            {
                case 1:
                    saveObject = ImageList[i];
                    ImageList[i] = ImageList[1];
                    ImageList[1] = saveObject;
                    break;
                case 2:
                    saveObject = ImageList[i];
                    ImageList[i] = ImageList[2];
                    ImageList[2] = saveObject;
                    break;
                case 50:
                    saveObject = ImageList[i];
                    ImageList[i] = ImageList[0];
                    ImageList[0] = saveObject;
                    break;
            }
        }
    }
    private void RandomActionList()
    {
        //1 - player, 2 - mirplayer, 5 - boss
        switch(Random.Range(0, 3))
        {
            case 0:
                Buttons.ActionList = new List<int>(3) { 1, 2, 50 };
                break;
            case 1:
                Buttons.ActionList = new List<int>(3) { 1, 50, 2 };
                break;
            case 2:
                Buttons.ActionList = new List<int>(3) { 50, 1, 2 };
                break;
        }

        switch (Random.Range(0, 2))
        {
            case 0:
                for(int i = 0; i < Buttons.ActionList.Count; i++)
                {
                    if(Buttons.ActionList[i] == 1)
                    {
                        Buttons.ActionList[i] = 2;
                    }
                    else if (Buttons.ActionList[i] == 2)
                    {
                        Buttons.ActionList[i] = 1;
                    }
                }
                break;
        }

    }

    private void ImageSvipeAnimation()
    {
        Sort();

        for(int i = 0; i < ImageList.Count; i++) 
        {
            switch (Buttons.ActionList[i])
            {
                case 1:
                    ImageList[1].transform.DOLocalMoveY(ImageListTransform[i].y, 0.5f);
                    break;
                case 2:
                    ImageList[2].transform.DOLocalMoveY(ImageListTransform[i].y, 0.5f);
                    break;
                case 50:
                    ImageList[0].transform.DOLocalMoveY(ImageListTransform[i].y, 0.5f);
                    break;
            }
        }
    }

    private void OnEnable()
    {
        ImageList.Add(this.gameObject);
        ImageListTransform.Add(this.gameObject.transform.localPosition);

        EventList.Swipe += ImageSvipeAnimation;

        if (ImageList.Count == 3)
        {
            EventList.Swipe.Invoke();
        }
    }

    private void OnDestroy()
    {
        ImageList.Clear();

        EventList.Swipe -= ImageSvipeAnimation;
    }
}
