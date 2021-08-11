using UnityEngine;

public class AnimationCar
{
    private readonly Animator _animator;
    private readonly AnimationClip _clip;
    private readonly int _layer;
    
    public AnimationCar(Animator animator, AnimationClip clip, int layer)
    {
        _animator = animator;
        _clip = clip;
        _layer = layer;
    }
    public void PlayClipFromFrame(float time)
    {
        time = Mathf.Clamp01(time);
        _animator.Play(_clip.name, _layer, time);
    }
}
