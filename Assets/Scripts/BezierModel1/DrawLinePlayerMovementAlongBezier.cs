using UnityEngine;

public class DrawLinePlayerMovementAlongBezier : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] private float _t;
    [SerializeField] private CreateMeshUsePoints _meshUsePoints;
    [SerializeField] private BeziersFirstOrder _line;

    private float _saveT;
    private GameObject _newObject;

    private void Start()
    {
        _saveT = _t;
    }

    private void Update()
    {
        if (_saveT != _t)
        {
            if (_newObject != null)
                Destroy(_newObject);

            _newObject = _meshUsePoints.GetNewObject(_line.P0, _line.GetPoint(_t));
            _saveT = _t;
        }
    }
}