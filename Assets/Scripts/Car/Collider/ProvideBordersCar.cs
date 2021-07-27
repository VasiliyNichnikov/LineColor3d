using System;
using UnityEngine;

public class ProvideBordersCar : MonoBehaviour
{
    private Mesh Mesh
    {
        get
        {
            SkinnedMeshRenderer meshRenderer = GetComponent<SkinnedMeshRenderer>();
            if (meshRenderer != null)
            {
                return meshRenderer.sharedMesh;
            }

            throw new Exception("Mesh renderer not found");
        }
    }
    [SerializeField, HideInInspector] public int SelectedPointId;
    
    public Vector3 GetPositionMeshPoint(SideMeshCar side)
    {
        Vector3 center = Mesh.bounds.center;
        Vector3 selectedPoint;
        switch (side)
        {
            case SideMeshCar.Left:
                selectedPoint = new Vector3(-Mathf.Infinity, center.y, center.z);
                break;

            case SideMeshCar.Right:
                selectedPoint = new Vector3(Mathf.Infinity, center.y, center.z);
                break;

            case SideMeshCar.Forward:
                selectedPoint = new Vector3(center.x, center.y, Mathf.Infinity);
                break;

            case SideMeshCar.Behind:
                selectedPoint = new Vector3(center.x, center.y, -Mathf.Infinity);
                break;

            case SideMeshCar.Up:
                selectedPoint = new Vector3(center.x, Mathf.Infinity, center.z);
                break;
            
            case SideMeshCar.Center:
                return center;

            default:
                throw new Exception("Сторона не найдена");
        }

        return Mesh.bounds.ClosestPoint(selectedPoint);
    }
    
}