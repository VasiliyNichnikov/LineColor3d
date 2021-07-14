using System;
using UnityEngine;

public class CreateMesh : MonoBehaviour
{
    private Vector3[] _verticles;
    private int[] _triangles;

    public void SetVerticlesUVTriangles(Vector3[] verticles, int[] triangles)
    {
        _verticles = verticles;
        _triangles = triangles;
    }

    public Mesh Creating()
    {
        if (_verticles.Length == 0 || _triangles.Length == 0)
        {
            throw new Exception("Не заданы параметры вершин/развертки/треугольников");
        }
        
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = _verticles;
        mesh.triangles = _triangles;
        return mesh;
    }
}