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

            throw new Exception("Mesh renderer not found");
        }
    }

    public Vector3 GetPositionMeshPoint(SideMeshObject side)
    {
        Vector3 center = Mesh.bounds.center;
        Vector3 selectedPoint;
        switch (side)
        {
            case SideMeshObject.Left:
                selectedPoint = new Vector3(-Mathf.Infinity, center.y, center.z);
                break;

            case SideMeshObject.Right:
                selectedPoint = new Vector3(Mathf.Infinity, center.y, center.z);
                break;

            case SideMeshObject.Forward:
                selectedPoint = new Vector3(center.x, center.y, Mathf.Infinity);
                break;

            case SideMeshObject.Behind:
                selectedPoint = new Vector3(center.x, center.y, -Mathf.Infinity);
                break;

            case SideMeshObject.Up:
                selectedPoint = new Vector3(center.x, Mathf.Infinity, center.z);
                break;
            
            case SideMeshObject.Center:
                return center;

            default:
                throw new Exception("Side not found");
        }

        return Mesh.bounds.ClosestPoint(selectedPoint);
    }
    
}