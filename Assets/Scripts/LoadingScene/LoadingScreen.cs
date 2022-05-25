using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        AsyncOperation asyncOperation = new AsyncOperation();
        if (PlayerPrefs.HasKey("Level"))
        {
            if (PlayerPrefs.GetInt("Level") == 0)
            {
                asyncOperation = SceneManager.LoadSceneAsync(1);
            }
            else if (3 + PlayerPrefs.GetInt("Level") != 32)
            {
                asyncOperation = SceneManager.LoadSceneAsync(3 + PlayerPrefs.GetInt("Level"));
            }
            else
            {
                asyncOperation = SceneManager.LoadSceneAsync(0);
            }
        }

        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
