using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private MapLevels mapLevels = new MapLevels();

    [SerializeField] private GameObject[] ArrowMapings;

    public static float[,] builderMap, navigationMap;

    private static int NextLevel = 0;

    [SerializeField] private GameObject FinishMenu;

    private static bool IsCameraTrasform = false;

    private void Start()
    {
        NextLevel = PlayerPrefs.GetInt("Level");
    }

    private void OnEnable()
    {
        NextLevel = PlayerPrefs.GetInt("Level");

        IsCameraTrasform = true;

        EventList.LevelStart += GenerateScene;
        
        EventList.LevelStart.Invoke(PlayerPrefs.GetInt("Level"));
    }

    private void OnDisable()
    {
        EventList.LevelStart -= GenerateScene;
    }
    private void GenerateScene(int level)
    {
        if (PlayerPrefs.GetInt("Level") + 1 == 6)
        {
            IsCameraTrasform = true;
            SceneManager.LoadScene(3);
        }

        if (kostil)
        {
            kostil = false;

            Debug.Log(1);
        }
        else
        {
            kostil = true;
        }
        if (level != -1)
        {
            if (level != 2 && PlayerMoving.isStartGame)
            {
                if (level == -2)
                    NextLevel = 0;
                else
                    NextLevel += level;

                if (PlayerPrefs.GetInt("Level") != 0)
                    SceneManager.LoadScene(3 + PlayerPrefs.GetInt("Level"));
                PlayerPrefs.SetInt("Level", NextLevel);
            }

            //CatSceneLoad();

            if(UINumbersControl.roundAction != null)
                UINumbersControl.roundAction.Invoke(PlayerPrefs.GetInt("Level"));
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

    private static bool kostil = true;
    private IEnumerator LoadNextLevel(int level)
    {
        PlayerPrefs.SetInt("Level", NextLevel);
        isStartCoroutine = true;
        builderMap = mapLevels.Levels(PlayerPrefs.GetInt("Level"));

        if(builderMap == null)
        {
            CleanScene();
            if (PlayerPrefs.HasKey("Level"))
            {
                if (PlayerPrefs.GetInt("Level") == 0)
                {
                    //FinishMenu.SetActive(true);
                }
                else
                {
                    //FinishMenu.SetActive(false);
                }
            }
            else
            {
                PlayerPrefs.SetInt("Level", 0);
                //FinishMenu.SetActive(true);
            }
            NextLevel = PlayerPrefs.GetInt("Level");
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

        if(builderMap == null)
        {
            SceneManager.LoadScene(2);
            yield break;
        }

        if (IsCameraTrasform)
        {
            CameraTrasform();
            IsCameraTrasform = false;
        }

        builderMap = mapLevels.Levels(PlayerPrefs.GetInt("Level"));

        if(builderMap == null)
        {
            SceneManager.LoadScene(2);
        }

        PlayerMoving.isStartGame = true;

        navigationMap = new float[builderMap.GetLength(0), builderMap.GetLength(1)];

        for (int x = 0; x < builderMap.GetLength(0); x++)
            for (int y = 0; y < builderMap.GetLength(1); y++)
            {
                GenerateTIle(x, y);
            }

        isStartCoroutine = false;

        yield return null;
    }

    private void CameraTrasform()
    {
        Debug.Log(builderMap.GetLength(0) + " " + builderMap.GetLength(1));
        if (builderMap.GetLength(0) > builderMap.GetLength(1))
        {
            Camera.main.transform.localPosition = new Vector3((
                builderMap.GetLength(0) / 2f) - 0.5f,
                builderMap.GetLength(1) / 2f,
                Camera.main.transform.position.z);

            if (Camera.main.WorldToScreenPoint(Camera.main.transform.position).y < 1200)
            {
                Camera.main.orthographicSize = builderMap.GetLength(0);// - ((builderMap.GetLength(0) / 2f) - 0.5f) / 4f;
            }
            else if (Camera.main.WorldToScreenPoint(Camera.main.transform.position).y >= 1200)
            {
                Camera.main.orthographicSize = builderMap.GetLength(0);// + ((builderMap.GetLength(0) / 2f) - 0.5f) / 4f;
            }

        }
        else
        {
            Camera.main.transform.position = new Vector3((
                builderMap.GetLength(0) / 2f) - 0.5f,
                builderMap.GetLength(1) / 2f,
                Camera.main.transform.position.z);
            //Camera.main.orthographicSize = builderMap.GetLength(1) - 3f;

            if (Screen.height < 1400)
            {
                Camera.main.orthographicSize = builderMap.GetLength(0) - (float)((float)Screen.height / (float)Screen.width);
            }
            else if (Screen.height >= 1400)
            {
                Camera.main.orthographicSize = builderMap.GetLength(0) + (float)((float)Screen.height / (float)Screen.width);
            }
        }
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
                ArrowMapings[(int)builderMap[x, y]].gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);

            GameObject ins = Instantiate(
                ArrowMapings[(int)builderMap[x, y]],
                positionPrefab,
                ArrowMapings[(int)builderMap[x, y]].transform.rotation,
                transform);
            //ins.AddComponent<RotateObject>();

        }
        switch (builderMap[x,y])
        {
            case 0:
                navigationMap[x, y] = 0;
                return;
            case 10:
                navigationMap[x, y] = -1;
                return;
            case 1:
            case 2:
            case 11:
            case 12:
            case 13:
            case 20:
                navigationMap[x, y] = 1;
                return;
            case 3:
                navigationMap[x, y] = 2;
                return;
            case 4:
            case 9:
            case 14:
            case 15:
            case 16:
                navigationMap[x, y] = 3;
                return;
            case 5:
            case 8:
                navigationMap[x, y] = 4;
                return;
            case 6:
            case 7:
                navigationMap[x, y] = 0;
                return;
        }

        navigationMap[x, y] = 1;
    }
}
