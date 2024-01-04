using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private float _minute, _second;
    [SerializeField] private int day;
    private float _time = 0;
    void Update()
    {
        if(_minute <= 0 && Mathf.Round(_second - _time) <= 0 )
        {
            SceneManager.LoadScene("Jumpscare");
            return;
        }
        _time += Time.deltaTime;

        string _secondTotal = Mathf.Round(_second - _time).ToString();

        if (Mathf.Round(_second - _time) < 10) _secondTotal = "0" + _secondTotal;

        if (_minute < 10)
        {
            _timerText.text = "<size=40>" + day + "일차</size>\n0" + _minute + ":" + _secondTotal;
        }
        else
        {
            _timerText.text = "<size=40>" + day + "일차</size>\n0" + _minute + ":" + Mathf.Round(_second - _time).ToString();
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
