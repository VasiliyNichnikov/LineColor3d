using UnityEngine;

public class AnimationCar
{
    private readonly Animator _animator;
    private readonly AnimationClip _clip;
    private readonly int _layer;
    private float _time;
    
    public AnimationCar(Animator animator, AnimationClip clip, int layer, float time)
    {
        _animator = animator;
        _clip = clip;
        _layer = layer;
        _time = time;
    }
    public void PlayClipFromFrame()
    {
        _time = Mathf.Clamp01(_time);
        _animator.Play(_clip.name, _layer, _time);
    }
}
