using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Texture2D[] mapCreateScene;

    [SerializeField] private ColorToPrefab[] ColorMapings;

    public static int[,] levelMap;

    private int NextLevel = 0;



    private void Awake()
    {
        GameManager.LevelStart += GenerateScene;

        GameManager.LevelStart.Invoke(0);
    }
    private void GenerateScene(int level)
    {
        if (mapCreateScene.Length - 1 >= NextLevel+level)
        {
            //UINumbersControl.roundAction.Invoke(1);
            //UINumbersControl.timeAction.Invoke(999);
            Player.IsFinishGame = false;
            MirrorPlayer.IsFinishGame = false;
            NextLevel += level;
            StartCoroutine(LoadNextLevel(level));
        }
    }

    private IEnumerator LoadNextLevel(int level)
    {
        if (NextLevel - 1 >= 0)
        {
            yield return new WaitForSeconds(5f);
            for (int x = 0; x < mapCreateScene[NextLevel - 1].width; x++)
                for (int y = 0; y < mapCreateScene[NextLevel - 1].height; y++)
                {
                    CleanScene(x, y, NextLevel - 1);
                }
        }
        levelMap = new int[mapCreateScene[NextLevel].width, mapCreateScene[NextLevel].height];
        Camera.main.orthographicSize = mapCreateScene[NextLevel].width - 1f;

        for (int x = 0; x < mapCreateScene[NextLevel].width; x++)
            for (int y = 0; y < mapCreateScene[NextLevel].height; y++)
            {
                GenerateTIle(x, y, NextLevel);
            }
        PlayerMoving.isStartGame = true;
        yield return null;
    }

    private void CleanScene(int x, int y, int levelNumber)
    {
        if(levelNumber >= 0)
        {
            foreach (Transform child in transform)
                Destroy(child.gameObject);
        }
    }

    private void GenerateTIle(int x, int y, int levelNumber)
    {
        Color pixelColor = mapCreateScene[levelNumber].GetPixel(x, y);

        if (pixelColor.a == 0)
            return;

        foreach (ColorToPrefab colorMaping in ColorMapings)
        {
            if (colorMaping.Color.Equals(pixelColor))
            {
                Vector2 positionPrefab = new Vector2(x + this.transform.localPosition.x, y + this.transform.localPosition.y);
                Instantiate(colorMaping.Prefab, positionPrefab, Quaternion.identity, transform);

                if (colorMaping.Color == Color.black || colorMaping.Color == Color.red)
                {
                    levelMap[x, y] = 1;
                }
                else if(colorMaping.Color == Color.blue)
                {
                    levelMap[x, y] = 2;
                }
                else if(colorMaping.Color == Color.magenta)
                {
                    levelMap[x, y] = 3;
                }
                else
                {
                    levelMap[x, y] = 0;
                }
            }
        }
    }
}
