using System;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Spline))]
public class CreatorRoad : MonoBehaviour
{
    [SerializeField] private bool _autoUpdateRoad;
    [SerializeField, Range(0.05f, 1f)] private float _spacing = 1;
    [SerializeField] private float _roadWidtgh = 1;
    [SerializeField] private float _tiling = 1;
    [SerializeField] private Spline _spline;

    public bool AutoUpdateRoad => _autoUpdateRoad;

    public void UpdateRoad()
    {
        if (_spline == null)
            throw new Exception($"Скрипт {nameof(Spline)} не найден");
        
        Vector3[] points = CalculatePoints.GetEventlySpacedPoints(_spline, _spacing);
        GetComponent<MeshFilter>().mesh = CreateRoadMesh(points);

        int textureRepeat = Mathf.RoundToInt(_tiling * points.Length * _spacing * 0.05f);
        GetComponent<MeshRenderer>().sharedMaterial.mainTextureScale = new Vector2(1, textureRepeat);
    }


    private Mesh CreateRoadMesh(Vector3[] points)
    {
        Vector3[] vertices = new Vector3[points.Length * 2];
        Vector2[] uvs = new Vector2[vertices.Length];
        int[] triangles = new int[2 * (points.Length - 1) * 3];
        int vertixIndex = 0;
        int triangleIndex = 0;
   
        for (int i = 0; i < points.Length; i++)
        {
            Vector3 forward = Vector3.zero;
            if (i < points.Length - 1)
            {
                forward += points[i + 1] - points[i];
            }

            if (i > 0)
            {
                forward += points[i] - points[i - 1];
            }
            forward.Normalize();
            
            Vector3 left = new Vector3(-forward.z, 0,forward.x);
            
            vertices[vertixIndex] = points[i] + left * _roadWidtgh * 0.5f;
            vertices[vertixIndex + 1] = points[i] - left * _roadWidtgh * 0.5f;

            float completePercent = i / (float) (points.Length - 1);
            float v = 1 - Mathf.Abs(2 * completePercent - 1);
            uvs[vertixIndex] = new Vector2(0, v);
            uvs[vertixIndex + 1] = new Vector2(1, v);

            if (i < points.Length - 1)
            {
                triangles[triangleIndex] = vertixIndex;
                triangles[triangleIndex + 1] = (vertixIndex + 2) % vertices.Length;
                triangles[triangleIndex + 2] = vertixIndex + 1;

                triangles[triangleIndex + 3] = vertixIndex + 1;
                triangles[triangleIndex + 4] = (vertixIndex + 2) % vertices.Length;
                triangles[triangleIndex + 5] = (vertixIndex + 3) % vertices.Length;
                ;
            }

            vertixIndex += 2;
            triangleIndex += 6;
        }


        Mesh mesh = new Mesh {vertices = vertices, triangles = triangles, uv = uvs};
        return mesh;
    }
}