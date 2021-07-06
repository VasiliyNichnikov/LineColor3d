using System.Collections.Generic;
using UnityEngine;

public class CreateMeshByTwoPoints : MonoBehaviour
{
    [SerializeField] private Material _material;

    [SerializeField] [Range(5, 10)] private float _sideLengthMainQuad;
    [SerializeField] [Range(0, 5)] private float _heightMeshY;
    
    public void CreateNewObject(Vector3 p0, Vector3 p1)
    {
        GameObject newObject = new GameObject("Object",typeof(MeshRenderer), typeof(MeshFilter));
        Mesh mesh = GetCreatingMesh(p0, p1);
        ChangeMeshAndMaterial(ref newObject, mesh);
    }

    private void ChangeMeshAndMaterial(ref GameObject obj, Mesh mesh)
    {
        obj.GetComponent<MeshFilter>().mesh = mesh;
        obj.GetComponent<MeshRenderer>().material = _material;
    }
    
    private Mesh GetCreatingMesh(Vector3 p0, Vector3 p1)
    {
        List<Vector3> verticles = new List<Vector3>();
        List<int> triangles = new List<int>();
        
        float halfSideLengthMainQuad = _sideLengthMainQuad / 2.0f;
        InitVerticlesAndAddArray(ref verticles, p0, p1, halfSideLengthMainQuad);
        InitTriangles(ref triangles);


        Mesh mesh = new Mesh();
        
        mesh.vertices = verticles.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
        return mesh;
    }

    private void InitVerticlesAndAddArray(ref List<Vector3> verticles, Vector3 p0, Vector3 p1, float halfSideLengthMainQuad)
    {
        // main quad
        Vector3 vert1 = new Vector3(p0.x - halfSideLengthMainQuad, 0, p0.z);
        Vector3 vert2 = new Vector3(p0.x + halfSideLengthMainQuad, 0, p0.z);
        Vector3 vert3 = new Vector3(p1.x - halfSideLengthMainQuad, 0, p1.z);
        Vector3 vert4 = new Vector3(p1.x + halfSideLengthMainQuad, 0, p1.z);
        // left quad 
        Vector3 vert5 = new Vector3(p0.x + halfSideLengthMainQuad, _heightMeshY, p0.z);
        Vector3 vert6 = new Vector3(p1.x + halfSideLengthMainQuad, _heightMeshY, p1.z);
        // right quad 
        Vector3 vert7 = new Vector3(p0.x - halfSideLengthMainQuad, _heightMeshY, p0.z);
        Vector3 vert8 = new Vector3(p1.x - halfSideLengthMainQuad, _heightMeshY, p1.z);
        
        verticles.Add(vert1);
        verticles.Add(vert2);
        verticles.Add(vert3);
        verticles.Add(vert4);
        
        verticles.Add(vert5);
        verticles.Add(vert6);
        
        verticles.Add(vert7);
        verticles.Add(vert8);
    }

    private void InitTriangles(ref List<int> triangles)
    {
        triangles.Add(2);
        triangles.Add(3);
        triangles.Add(0);
     
        triangles.Add(3);
        triangles.Add(1);
        triangles.Add(0);
        
        triangles.Add(3);
        triangles.Add(5);
        triangles.Add(1);
        
        triangles.Add(5);
        triangles.Add(4);
        triangles.Add(1);
        
        triangles.Add(7);
        triangles.Add(2);
        triangles.Add(6);
        
        triangles.Add(2);
        triangles.Add(0);
        triangles.Add(6);
    }
    
}
