using UnityEngine;


public class ManagerAnimationsThatChangeSizeCar : MonoBehaviour
{
    [SerializeField] private ParametersAnimation _heightAnimation;
    [SerializeField] private ParametersAnimation _widthAnimation;
    private Animator _animator;

    private AnimationCar[] _animationsPlayerCar;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _animationsPlayerCar = new []
        {
            new AnimationCar(_animator, _heightAnimation.Clip, _heightAnimation.Layer),
            new AnimationCar(_animator, _widthAnimation.Clip, _widthAnimation.Layer)
        };

    }

    private void OnEnable()
    {
        EventManagerPlayerCar.EventSelectingAnimationAndStartTimeCar += SelectingAnimationAndStartTime;
    }

    private void OnDisable()
    {
        EventManagerPlayerCar.EventSelectingAnimationAndStartTimeCar -= SelectingAnimationAndStartTime;
    }

    private void SelectingAnimationAndStartTime(int index, float time)
    {
        AnimationCar animationCar = _animationsPlayerCar[index];
        animationCar.PlayClipFromFrame(time);
    }
}