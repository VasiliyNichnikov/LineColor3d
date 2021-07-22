using System;
using UnityEngine;

public class ChangeSizeCar : MonoBehaviour
{
    [SerializeField] private ParametersAnimation _heightAnimation;
    [SerializeField] private ParametersAnimation _widthAnimation;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        EventManager.EventSelectingAnimationCar += SelectingAnimation;
    }

    private void OnDisable()
    {
        EventManager.EventSelectingAnimationCar -= SelectingAnimation;
    }

    private void SelectingAnimation(AnimationsType type, float time)
    {
        switch (type)
        {
            case AnimationsType.Width:
                PlayClipFromFrame(_widthAnimation.Clip, _widthAnimation.Layer, time);
                break;

            case AnimationsType.Height:
                PlayClipFromFrame(_heightAnimation.Clip, _heightAnimation.Layer, time);
                break;
            case AnimationsType.None:
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }

    private void PlayClipFromFrame(AnimationClip clip, int layer, float time)
    {
        time = Mathf.Clamp01(time);
        _animator.Play(clip.name, layer, time);
    }
}