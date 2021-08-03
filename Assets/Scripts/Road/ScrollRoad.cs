using UnityEngine;

public class ScrollRoad : MonoBehaviour
{
    [SerializeField] private LineMoveCar _lineMove;
    private MeshRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        Vector2 offset = new Vector2(Time.time * _lineMove.Speed, 0);
        _renderer.material.mainTextureOffset = offset;
    }
}
