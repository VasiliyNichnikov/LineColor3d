using UnityEngine;

public class ChangeSizeCar : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _clipHeight, _clipWidth;
    
    private float _hValue;
    private float _wValue;

    private void Start()
    {
        print(_clipHeight.length);
    }

    private void OnGUI()
    {
        _hValue = GUI.VerticalSlider(new Rect(0, Screen.height / 2 - 150, 20, 300), _hValue, 1.0f, 0.0f);
        _wValue = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 90, 10, 180, 20), _wValue, 0.0f, 1.0f);
    }

    private void Update()
    {
        PlayClipFromFrame(_clipHeight, 1, _hValue);
        PlayClipFromFrame(_clipWidth, 2, _wValue);
    }

    private void PlayClipFromFrame(AnimationClip clip, int layer, float time)
    {
        _animator.Play(clip.name, layer, time);
    }
    
}
