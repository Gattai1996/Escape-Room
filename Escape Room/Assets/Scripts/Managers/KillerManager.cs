using UnityEngine;
using UnityEngine.Playables;

public class KillerManager : MonoBehaviour
{
    private PlayableDirector _directorControlPlayable;

    public void SetActive()
    {
        _directorControlPlayable = GetComponent<PlayableDirector>();
        _directorControlPlayable.enabled = true;
    }
}
