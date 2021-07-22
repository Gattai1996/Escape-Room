using UnityEngine;
using UnityEngine.Playables;

public class KillerManager : MonoBehaviour
{
    private PlayableDirector _directorControlPlayable;
    private Animator _animator;

    public void SetActive()
    {
        _directorControlPlayable = GetComponent<PlayableDirector>();
        _animator = GetComponent<Animator>();
        _directorControlPlayable.enabled = true;
        _animator.enabled = true;
    }
}
