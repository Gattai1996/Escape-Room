using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private Event _gameStartEvent;
    public static HUDManager Singleton { get; private set; }
    private TextMeshProUGUI _interactionText;
    private TextMeshProUGUI _messageText;
    private Image _pointer;
    private GameObject _winScreen, _gameOverScreen, _timer;
    private Color pointerNormalColor = new Color(255, 255, 255, 255);
    private Color pointerHoverColor = new Color(0, 200, 0, 255);

    void Start()
    {
        Singleton = this;
        _interactionText = transform.Find("Interaction Text").GetComponent<TextMeshProUGUI>();
        _messageText = transform.Find("Message Text").GetComponent<TextMeshProUGUI>();
        _pointer = transform.Find("Pointer").GetComponent<Image>();
        _winScreen = transform.Find("Win Screen").gameObject;
        _gameOverScreen = transform.Find("Game Over Screen").gameObject;
        _timer = transform.Find("Timer").gameObject;
        _pointer.gameObject.SetActive(false);
        _winScreen.SetActive(false);
        _gameOverScreen.SetActive(false);
        HideAllTexts();
        Time.timeScale = 1f;
    }

    public void GameStart()
    {
        _pointer.gameObject.SetActive(true);
        _gameStartEvent.TriggerEvent();
    }

    public void ShowInteractionText(string message)
    {
        _interactionText.text = message;
        _pointer.color = pointerHoverColor;
    }

    public void HideInteractionText()
    {
        _interactionText.text = "";    
        _pointer.color = pointerNormalColor;
    }

    public void ShowMessageText(string message, float timeToShow)
    {
        _messageText.text = message;
        StartCoroutine(HideMessageCoroutine(timeToShow));
    }

    public void HideMessageText()
    {
        _messageText.text = "";
    }

    private IEnumerator HideMessageCoroutine(float timeToShow)
    {
        yield return new WaitForSeconds(timeToShow);
        HideMessageText();
    }

    private void HideAllTexts()
    {
        HideInteractionText();
        HideMessageText();
    }

    public void HideAllHUDObjects()
    {
        HideAllTexts();
        _pointer.transform.gameObject.SetActive(false);
        _timer.SetActive(false);
    }

    public void Win()
    {
        HideAllTexts();
        _winScreen.SetActive(true);
    }

    public void GameOver()
    {
        HideAllTexts();
        _gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
