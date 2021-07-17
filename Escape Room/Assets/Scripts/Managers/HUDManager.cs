using UnityEngine;
using TMPro;
using System.Collections;

public class HUDManager : MonoBehaviour
{
    private TextMeshProUGUI _interactionText;
    private TextMeshProUGUI _messageText;
    public static HUDManager Singleton { get; private set; }

    void Start()
    {
        Singleton = this;
        _interactionText = GameObject.FindWithTag("Interaction Text").GetComponent<TextMeshProUGUI>();
        _messageText = GameObject.FindWithTag("Message Text").GetComponent<TextMeshProUGUI>();
        HideInteractionText();
        HideMessageText();
    }

    public void ShowInteractionText(string message)
    {
        _interactionText.text = message;    
    }

    public void HideInteractionText()
    {
        _interactionText.text = "";    
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
}
