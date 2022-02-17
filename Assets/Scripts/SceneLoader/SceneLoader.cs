using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    MapLevels mapLevels = new MapLevels();

    [SerializeField] private GameObject[] ArrowMapings;

    public static int[,] builderMap, navigationMap;

    private int NextLevel = 0;

    private void Awake()
    {
        
        GameManager.LevelStart += GenerateScene;

        GameManager.LevelStart.Invoke(0);

    }
    private void GenerateScene(int level)
    {
        
        if (level != -1)
        {
            if (level != 2 && PlayerMoving.isStartGame)
            {
                if (level == -2)
                    NextLevel = 0;
                else
                    NextLevel += level;
            }
                UINumbersControl.roundAction.Invoke(NextLevel);
                UINumbersControl.timeAction.Invoke(999);
                Player.IsFinishGame = false;
                MirrorPlayer.IsFinishGame = false;
                StartCoroutine(LoadNextLevel(level));
        }
    }

    private IEnumerator LoadNextLevel(int level)
    {
        builderMap = mapLevels.Levels(NextLevel);
        if (NextLevel - 1 >= 0 || level == 2 || level == -2)
        {
            yield return new WaitForSeconds(2f);
            for (int x = 0; x < builderMap.GetLength(0); x++)
                for (int y = 0; y < builderMap.GetLength(1); y++)
                {
                    CleanScene(x, y);
                }
        }
        Camera.main.orthographicSize = builderMap.GetLength(0) - 1f;

        builderMap = mapLevels.Levels(NextLevel);

        PlayerMoving.isStartGame = true;

        navigationMap = new int[builderMap.GetLength(0), builderMap.GetLength(1)];

        for (int x = 0; x < builderMap.GetLength(0); x++)
            for (int y = 0; y < builderMap.GetLength(1); y++)
            {
                GenerateTIle(x, y);
            }
        yield return null;
    }

    private void CleanScene(int x, int y)
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
    }

    private void GenerateTIle(int x, int y)
    {
        if (builderMap[x,y] != 0){
            Vector2 positionPrefab = new Vector2(x + this.transform.localPosition.x, y + this.transform.localPosition.y);
            Instantiate(ArrowMapings[builderMap[x,y]], positionPrefab, Quaternion.identity, transform);
        }
        switch (builderMap[x,y])
        {
            case 0:
                navigationMap[x, y] = 0;
                break;
            case 1:
            case 2:
            case 10:
            case 11:
            case 12:
                navigationMap[x, y] = 1;
                break;
            case 3:
                navigationMap[x, y] = 2;
                break;
            case 4:
            case 9:
                navigationMap[x, y] = 3;
                break;
            case 5:
            case 8:
                navigationMap[x, y] = 4;
                break;
            case 6:
            case 7:
                navigationMap[x, y] = 0;
                break;
        }
    }
}
