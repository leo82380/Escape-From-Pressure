using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private float _minute, _second;
    private float _time = 0;
    void Update()
    {
        if(_minute <= 0 && Mathf.Round(_second - _time) <= 0 )
        {
            print("게임오버");
            return;
        }
        _time += Time.deltaTime;

        string _secondTotal = Mathf.Round(_second - _time).ToString();

        if (Mathf.Round(_second - _time) < 10) _secondTotal = "0" + _secondTotal;

        if (_minute < 10)
        {
            _timerText.text = "0" + _minute + ":" + _secondTotal;
        }
        else
        {
            _timerText.text = _minute + ":" + Mathf.Round(_second - _time).ToString();
        }

        if (_second - _time <= 0 )
        {
            if(_minute > 0)
            {
                _second = 60;
                _time = 0;
                _minute--;
            }
        }
    }
}
