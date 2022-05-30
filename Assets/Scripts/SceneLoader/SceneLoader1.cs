using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader1 : MonoBehaviour
{
    [SerializeField] private Texture2D[] mapCreateScene;

    [SerializeField] private ColorToPrefab[] ColorMapings; //delete

    [SerializeField] private MapLevels[] NumberMaping;

    public static int[,] LevelMapCreator, LevelMap;

    private int NextLevel = 0;



    private void Start()
    {
        EventList.LevelStart += GenerateScene;

        while (EventList.LevelStart != null)
            EventList.LevelStart.Invoke(0);
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

            LevelMapCreator = new int[mapCreateScene[NextLevel].width, mapCreateScene[NextLevel].height];//delete
            Camera.main.orthographicSize = LevelMapCreator.GetLength(0) - 1f;

            for (int x = 0; x < mapCreateScene[NextLevel].width; x++)
                for (int y = 0; y < mapCreateScene[NextLevel].height; y++)
                {
                    ColorTileGenerate(x, y, NextLevel);
                }//delete
            TileGenerate(LevelMapCreator, NextLevel);
            PlayerMoving.isStartGame = true;
        }
        else
        {
            yield return null;
        }
    }

    private void CleanScene(int x, int y, int levelNumber)
    {
        if(levelNumber >= 0)
        {
            foreach (Transform child in transform)
                Destroy(child.gameObject);
        }
    }

    private void ColorTileGenerate(int x, int y, int levelNumber) //delete
    {

        Color pixelColor = mapCreateScene[levelNumber].GetPixel(x, y);

        if (pixelColor.a == 0)
            return;

        foreach (ColorToPrefab colorMaping in ColorMapings)
        {
            if (colorMaping.Color.Equals(pixelColor))
            {
                if (colorMaping.Color == Color.black)
                {
                    LevelMapCreator[x, y] = 1;
                }
                else if (colorMaping.Color == Color.red)
                {
                    LevelMapCreator[x, y] = 2;
                }
                else if (colorMaping.Color == Color.blue)
                {
                    LevelMapCreator[x, y] = 3;
                }
                else if (colorMaping.Color == Color.magenta)
                {
                    LevelMapCreator[x, y] = 4;
                }
                else if (colorMaping.Color == new Color(1f, 1f, 0f, 1f))
                {
                    LevelMapCreator[x, y] = 5;
                }
                else if (colorMaping.Color == Color.white)
                {
                    LevelMapCreator[x, y] = 6;
                }
                else if (colorMaping.Color == Color.green)
                {
                    LevelMapCreator[x, y] = 7;
                }

                else
                {
                    LevelMapCreator[x, y] = 0;
                }
            }
        }

    }

    public void TileGenerate(int[,] tileMap, int levelNumber)
    {
        LevelMap = new int[LevelMapCreator.GetLength(0), LevelMapCreator.GetLength(1)];
        for (int x = 0; x < mapCreateScene[levelNumber].width; x++)
            for (int y = 0; y < mapCreateScene[levelNumber].height; y++) 
            {
                int tileNumber = tileMap[x, y];
                foreach (MapLevels numberMap in NumberMaping)
                {
                    
                    
                } 
            }

    }
}
