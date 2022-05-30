using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] GameObject LoadingScreen;

    private bool IsLoad = false;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 0);
        }
    }
    private void OnEnable()
    {
        LoadingScreen.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (IsLoad)
        {
            StartCoroutine(LoadScene(PlayerPrefs.GetInt("Level")));
            Debug.Log(Time.time);
        }
    }
    public void NewGame()
    {
        LoadingScreen.SetActive(true);
        PlayerPrefs.SetInt("Level", 0);
        StartCoroutine(LoadScene(PlayerPrefs.GetInt("Level")));
    }

    private IEnumerator LoadScene(int number)
    {
        if (number == 0)
            number = 1;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(number);

        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);

            LoadingScreen.transform.GetChild(0).GetComponent<Slider>().value = progress;

            yield return null;
        }
    }

    public void Continue()
    {
        LoadingScreen.SetActive(true);
        StartCoroutine(LoadScene(PlayerPrefs.GetInt("Level")));
    }
}
