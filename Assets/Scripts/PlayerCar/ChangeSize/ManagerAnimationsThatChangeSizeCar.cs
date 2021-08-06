using System;
using UnityEngine;


public class ManagerAnimationsThatChangeSizeCar : MonoBehaviour
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
        EventManagerPlayerCar.EventSelectingAnimationAndStartTimeCar += SelectingAnimationAndStartTime;
    }

    private void OnDisable()
    {
        EventManagerPlayerCar.EventSelectingAnimationAndStartTimeCar -= SelectingAnimationAndStartTime;
    }

    private void SelectingAnimationAndStartTime(AnimationsType type, float time)
    {
        AnimationCar animationCar = GetAnimationCar(type, time);
        animationCar.PlayClipFromFrame();
    }

    private AnimationCar GetAnimationCar(AnimationsType type, float time)
    {
        switch (type)
        {
            case AnimationsType.Width:
                return new AnimationCar(_animator, _widthAnimation.Clip, _widthAnimation.Layer, time);

            case AnimationsType.Height:
                return new AnimationCar(_animator, _heightAnimation.Clip, _heightAnimation.Layer, time);

            case AnimationsType.None:
                return new AnimationCar(_animator, null, -1, time);

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