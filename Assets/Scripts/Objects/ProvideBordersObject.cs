using System;
using UnityEngine;

public class ProvideBordersObject : MonoBehaviour, IProvideBordersObject
{
    [SerializeField, HideInInspector] public int SelectedPointId;

    private Mesh Mesh
    {
        get
        {
            SkinnedMeshRenderer meshRenderer = GetComponent<SkinnedMeshRenderer>();
            if (meshRenderer != null)
            {
                return meshRenderer.sharedMesh;
            }
            else
            {
                MeshFilter meshFilter = GetComponent<MeshFilter>();
                if (meshFilter != null)
                {
                    return meshFilter.sharedMesh;
                }
            }

            throw new Exception("Mesh filter and skinned mesh renderer not found");
        }
    }

    public Vector3 GetPositionMeshPoint(SideMeshObject side)
    {
        Vector3 center = Mesh.bounds.center;
        BorderPoint point = GetBorderPoint(side);

        Vector3 selectedPoint = point.GetPoint(center);
        return Mesh.bounds.ClosestPoint(selectedPoint);
    }

    private BorderPoint GetBorderPoint(SideMeshObject side)
    {
        switch (side)
        {
            case SideMeshObject.Left:
                return new BorderPointLeft();

            case SideMeshObject.Right:
                return new BorderPointRight();

            case SideMeshObject.Forward:
                return new BorderPointForward();

            case SideMeshObject.Behind:
                return new BorderPointBehind();

            case SideMeshObject.Up:
                return new BorderPointUp();

            case SideMeshObject.Center:
                return new BorderPointCenter();
            
            default:
                throw new Exception("Side not found");
        }
    }
    
}