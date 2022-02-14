using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Texture2D mapCreateScene;

    [SerializeField] private ColorToPrefab[] ColorMapings;

    public static int[,] levelMap;

    private void Awake()
    {
        levelMap = new int[mapCreateScene.width, mapCreateScene.height];
        GenerateScene();
    }
    private void GenerateScene()
    {
        for (int x = 0; x < mapCreateScene.width; x++)
            for (int y = 0; y < mapCreateScene.height; y++)
            {
                GenerateTIle(x, y);
            }
    }

    private void GenerateTIle(int x, int y)
    {
        Color pixelColor = mapCreateScene.GetPixel(x, y);

        if (pixelColor.a == 0)
            return;

        foreach (ColorToPrefab colorMaping in ColorMapings)
        {
            if (colorMaping.Color.Equals(pixelColor))
            {
                Vector2 positionPrefab = new Vector2(x, y);
                Instantiate(colorMaping.Prefab, positionPrefab, Quaternion.identity, transform);

                if (colorMaping.Color == Color.black || colorMaping.Color == Color.red)
                {
                    levelMap[x, y] = 1;
                }
                else if(colorMaping.Color == Color.blue)
                {
                    levelMap[x, y] = 2;
                }
                else
                {
                    levelMap[x, y] = 0;
                }
            }
        }
    }
}
