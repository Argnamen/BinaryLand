using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.SceneManagement.SceneManager;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Joystick;

    [SerializeField] private GameObject FinalLabel;

    private bool isJoysctick = false;

    private void EndGame(int time)
    {
        if (time <= 0)
            LoadScene(0);
    }

    private void FinalLabelActivate(int level)
    {
        if(level == -1)
            FinalLabel.SetActive(true);
    }
    private void JoysctickEnabled()
    {
        if (Input.GetMouseButton(0) && !isJoysctick)
        {
            Joystick.transform.position = Input.mousePosition;
            isJoysctick = true;
        }
        else if (!Input.GetMouseButton(0))
        {
            Joystick.transform.position = new Vector3(10000f, 10000f, 0f);
            isJoysctick = false;
        }
    }

    private IEnumerator GameLoop()
    {
        yield return new WaitForSeconds(1f);
    }

    private void Awake()
    {
        UINumbersControl.timeAction += EndGame;
        EventList.LevelStart += FinalLabelActivate;
    }

    private void FixedUpdate()
    {
        JoysctickEnabled();
    }

    private void OnDestroy()
    {
        UINumbersControl.timeAction -= EndGame;
        EventList.LevelStart -= FinalLabelActivate;
    }
}
