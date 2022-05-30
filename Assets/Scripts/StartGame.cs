using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void GameLoad()
    {
        StartCoroutine(Load());
    }

    public void Restart()
    {
        this.gameObject.transform.parent.gameObject.SetActive(false);

        if (EventList.LevelStart != null)
            EventList.LevelStart.Invoke(-2);
    }

    private IEnumerator Load()
    {
        this.gameObject.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(0.15f);
        PlayerMoving.isStartGame = true;
        this.gameObject.transform.parent.gameObject.SetActive(false);
    }
}
