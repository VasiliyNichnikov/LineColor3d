using System;
using UnityEngine;

public class CalculatorBoxColliderCarBody : MonoBehaviour
{
    [SerializeField] private SidePointCar[] _sidePoinsCar;
    private Mesh _meshCar;

    public Mesh MeshCar
    {
        get
        {
            SkinnedMeshRenderer meshRenderer = GetComponent<SkinnedMeshRenderer>();
            if (meshRenderer != null)
            {
                return meshRenderer.sharedMesh;
            }

            throw new Exception("Skinned Mesh Renderer не найден");
        }
    }

    private void Awake()
    {
        _meshCar = GetComponent<SkinnedMeshRenderer>().sharedMesh;
    }

    public Vector3 GetPositionPointMesh(SideCar side)
    {
        Vector3 center = _meshCar.bounds.center;
        Vector3 selectedPoint;
        switch (side)
        {
            case SideCar.Left:
                selectedPoint = new Vector3(-Mathf.Infinity, center.y, center.z);
                break;

            case SideCar.Right:
                selectedPoint = new Vector3(Mathf.Infinity, center.y, center.z);
                break;

            case SideCar.Forward:
                selectedPoint = new Vector3(center.x, center.y, Mathf.Infinity);
                break;

            case SideCar.Behind:
                selectedPoint = new Vector3(center.x, center.y, -Mathf.Infinity);
                break;

            case SideCar.Up:
                selectedPoint = new Vector3(center.x, Mathf.Infinity, center.z);
                break;

            default:
                throw new Exception("Сторона не найдена");
        }

        return _meshCar.bounds.ClosestPoint(selectedPoint);
    }

    /// <summary>
    /// Получает позицию точки из массива с точками
    /// </summary>
    /// <param name="side">выбранная сторона</param>
    /// <returns>Возвращает точку в локальных координатах</returns>
    public Vector3 GetPositionPointFromArrayPoints(SideCar side)
    {
        return transform.InverseTransformPoint(GetPointCarFromArrayPoints(side).Position);
    }
    
    public Transform GetTransformPointFromArrayPoints(SideCar side)
    {
        return GetPointCarFromArrayPoints(side).Transform;
    }

    private SidePointCar GetPointCarFromArrayPoints(SideCar side)
    {
        foreach (var pointCar in _sidePoinsCar)
        {
            if (pointCar.Side == side)
            {
                return pointCar;
            }
        }

        throw new Exception($"Не найдена сторона: {side.ToString()}");
    }
    
}