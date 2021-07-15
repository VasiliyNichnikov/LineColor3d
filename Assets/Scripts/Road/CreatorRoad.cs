using System;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class CreatorRoad : MonoBehaviour
{
    [SerializeField] private BezierCurve _bezier;
    [SerializeField] [Range(0.05f, 1f)] private float _spacing = 1;
    [SerializeField] private float _roadWidtgh = 1;
    [SerializeField] private float _tiling = 1;


    public void UpdateRoad()
    {
        Vector2[] points = CalculatePoints.GetEventlySpacedPoints(_bezier, _spacing);
        for (int i = 0; i < points.Length; i++)
        {
            print($"Point: {points[i]}");
        }
        GetComponent<MeshFilter>().mesh = CreateRoadMesh(points);

        int textureRepeat = Mathf.RoundToInt(_tiling * points.Length * _spacing * 0.05f);
        GetComponent<MeshRenderer>().sharedMaterial.mainTextureScale = new Vector2(1, textureRepeat);
    }

    private Mesh CreateRoadMesh(Vector2[] points)
    {
        Vector3[] vertices = new Vector3[points.Length * 2];
        Vector2[] uvs = new Vector2[vertices.Length];
        int[] triangles = new int[2 * (points.Length - 1) * 3];
        int vertixIndex = 0;
        int triangleIndex = 0;

        for (int i = 0; i < points.Length; i++)
        {
            Vector2 forward = Vector2.zero;
            if (i < points.Length - 1)
            {
                forward += points[(i + 1) % points.Length] - points[i];
            }

            if (i > 0)
            {
                forward += points[i] - points[(i - 1 + points.Length) % points.Length];
            }

            forward.Normalize();
            Vector2 left = new Vector2(-forward.y, forward.x);

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
                triangles[triangleIndex + 5] = (vertixIndex + 3) % vertices.Length;;
            }

            vertixIndex += 2;
            triangleIndex += 6;
        }

        Mesh mesh = new Mesh {vertices = vertices, triangles = triangles, uv = uvs};
        return mesh;
    }
}