using System;
using UnityEngine;

[Serializable]
public class ParametersAnimation
{
    [SerializeField] private string _name;
    [SerializeField] private AnimationClip _clip;
    [SerializeField] private int _layer;

    public string Name => _name;
    public AnimationClip Clip => _clip;
    public int Layer => _layer;
}                   
                    