using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private Vector3 _p0, _p1;

    public Vector3 p0
    {
        get => _p0;
        set { _p0 = value; }
    }

    public Vector3 p1
    {
        get => _p1;
        set { _p1 = value; }
    }

}
