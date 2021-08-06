using System;
using UnityEngine;

public class ProvideBordersObject : MonoBehaviour
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
        BorderPoint point;
        switch (side)
        {
            case SideMeshObject.Left:
                point = new BorderPointLeft();
                break;

            case SideMeshObject.Right:
                point = new BorderPointRight();
                break;

            case SideMeshObject.Forward:
                point = new BorderPointForward();
                break;

            case SideMeshObject.Behind:
                point = new BorderPointBehind();
                break;

            case SideMeshObject.Up:
                point = new BorderPointUp();
                break;

            case SideMeshObject.Center:
                return center;

            default:
                throw new Exception("Side not found");
        }

        Vector3 selectedPoint = point.GetPoint(center);
        return Mesh.bounds.ClosestPoint(selectedPoint);
    }
}