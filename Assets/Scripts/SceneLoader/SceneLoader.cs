using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private MapLevels mapLevels = new MapLevels();

    [SerializeField] private GameObject[] ArrowMapings;

    public static int[,] builderMap, navigationMap;

    private static int NextLevel = 0;

    [SerializeField] private GameObject FinishMenu;

    private void OnEnable()
    {
        EventList.LevelStart += GenerateScene;

        EventList.LevelStart.Invoke(0);
    }

    private void OnDisable()
    {
        EventList.LevelStart -= GenerateScene;
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

            CatSceneLoad();

            if (NextLevel == 7)
            {
                SceneManager.LoadScene(2);
            }
            if(UINumbersControl.roundAction != null)
                UINumbersControl.roundAction.Invoke(NextLevel);
            if(UINumbersControl.timeAction != null)
                UINumbersControl.timeAction.Invoke(999);

            Player.IsFinishGame = false;
            MirrorPlayer.IsFinishGame = false;
            if(!isStartCoroutine)
                StartCoroutine(LoadNextLevel(level));
        }
    }

    private bool isStartCoroutine = false;

    private static bool CatSceneActivate = true;
    private void CatSceneLoad()
    {
        if (CatSceneActivate)
        {
            CatSceneActivate = false;
            SceneManager.LoadScene(3);
        }
        else
        {
            CatSceneActivate = true;
        }
    }
    private IEnumerator LoadNextLevel(int level)
    {
        isStartCoroutine = true;
        builderMap = mapLevels.Levels(NextLevel);

        if(builderMap == null)
        {
            CleanScene();
            FinishMenu.SetActive(true);
            NextLevel = 0;
            yield return null;
        }

        if (NextLevel - 1 >= 0 || level == 2 || level == -2)
        {
            yield return new WaitForSeconds(0.5f);
            CleanScene();

            //CatSceneLoad();

        }
        Screen.fullScreen = false;
        Screen.SetResolution(9 * 50, 20 * 50, false);
        if (builderMap.GetLength(0) > builderMap.GetLength(1))
        {
            Camera.main.transform.position = new Vector3((builderMap.GetLength(0) / 2) - 0.5f, builderMap.GetLength(1) / 2, Camera.main.transform.position.z);
            Camera.main.orthographicSize = builderMap.GetLength(0) - 1f;
        }
        else
        {
            Camera.main.transform.position = new Vector3((builderMap.GetLength(0) / 2) - 0.5f, builderMap.GetLength(1) / 2, Camera.main.transform.position.z);
            Camera.main.orthographicSize = builderMap.GetLength(1) - 6f;
        }

        builderMap = mapLevels.Levels(NextLevel);

        PlayerMoving.isStartGame = true;

        navigationMap = new int[builderMap.GetLength(0), builderMap.GetLength(1)];

        for (int x = 0; x < builderMap.GetLength(0); x++)
            for (int y = 0; y < builderMap.GetLength(1); y++)
            {
                GenerateTIle(x, y);
            }

        isStartCoroutine = false;

        yield return null;
    }

    private void CleanScene()
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
    }

    private void GenerateTIle(int x, int y)
    {
        if (builderMap[x, y] != 0)
        {
            Vector2 positionPrefab = new Vector2(x, y);
            if (builderMap[x, y] > 12 && builderMap[x, y] != 20)
                ArrowMapings[builderMap[x, y]].gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);

            GameObject ins = Instantiate(ArrowMapings[builderMap[x, y]], positionPrefab, Quaternion.identity, transform);
            ins.AddComponent<RotateObject>();

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
            case 13:
            case 20:
                navigationMap[x, y] = 1;
                break;
            case 3:
                navigationMap[x, y] = 2;
                break;
            case 4:
            case 9:
            case 14:
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