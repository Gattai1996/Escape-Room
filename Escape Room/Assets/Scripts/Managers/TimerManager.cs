using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private float _minutes;
    [SerializeField] private Event _gameOverEvent;
    private float _seconds;
    private float _secondsLimit = 59;
    private TextMeshProUGUI _minutesText;
    private TextMeshProUGUI _secondsText;

    void Start()
    {
        _minutesText = transform.Find("Minutes Text").GetComponent<TextMeshProUGUI>();
        _secondsText = transform.Find("Seconds Text").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        _seconds -= Time.deltaTime;

        if (_seconds < 1)
        {
            _seconds = _secondsLimit;

            if (_minutes > 0)
            {
                _minutes--;
            }
            else
            {
                _gameOverEvent.TriggerEvent();
            }
        }

        _secondsText.text = _seconds.ToString("00");
        _minutesText.text = _minutes.ToString("00");
    }
}
