using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class UINumbersControl : MonoBehaviour
{
    [SerializeField] private TMP_Text TextScore, TextTime, TextRound;

    public static UnityAction<int> scoreAction, timeAction, roundAction;

    private float timeScale = 999;

    private void ScoreUpdate(int score)
    {
        TextScore.text = score.ToString();
    }

    private void TimeUpdate(int time)
    {
        TextTime.text = time.ToString();
    } 

    private void RoundUpdate(int round)
    {
        TextRound.text = round.ToString();
    }

    private void Awake()
    {
        scoreAction += ScoreUpdate;
        timeAction += TimeUpdate;
        roundAction += RoundUpdate;
    }

    private void FixedUpdate()
    {
        timeScale -= Time.deltaTime;
        timeAction.Invoke((int)timeScale);
    }

    private void OnDestroy()
    {
        scoreAction -= ScoreUpdate;
        timeAction -= TimeUpdate;
        roundAction -= RoundUpdate;
    }
}
