using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgraundSvipe : MonoBehaviour
{
    [SerializeField] private List<Sprite> Backgraunds;
    [SerializeField] private int LevelNumber;

    private void Swipe(int level)
    {
        if(TryGetComponent<Image>(out var image))
        {
            if(LevelNumber == 0)
                image.sprite = Backgraunds[PlayerPrefs.GetInt("Level")];
            else
                image.sprite = Backgraunds[LevelNumber - 1];
        }
    }

    private void OnEnable()
    {
        EventList.LevelStart += Swipe;

        Swipe(1);
    }

    private void OnDestroy()
    {
        EventList.LevelStart -= Swipe;
    }
}
