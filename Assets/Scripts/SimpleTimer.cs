using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleTimer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Text timerText;
    [SerializeField] private Text message;
    [SerializeField] private Canvas endCanvas;

    private float _timeLeft = 0f;
    private bool _timerOn = false;

    private void Start()
    {
        endCanvas.enabled = false;
        _timeLeft = time;
        _timerOn = true;
    }

    private void Update()
    {
        if (_timerOn)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                UpdateTimeText();
            }
            else
            {
                _timeLeft = time;
                _timerOn = false;
                message.text = "Вы опоздали на занятие!";
                Time.timeScale = 0;
                endCanvas.enabled = true;
            }
        }
    }

    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
