using NUnit.Framework;
using UnityEngine;

public class TestCreateMesh
{
    [Test]
    public void TestCreateSquareMesh()
    {
        // ARRANGE
        GameObject obj = new GameObject("Line", typeof(MeshFilter));
        CreateMesh createSquare = obj.AddComponent<CreateMesh>();

        Vector3[] verticles =
        {
            new Vector3(0, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(1, 0, 0),
            new Vector3(1, 1, 0)
        };

        int[] triangles =
        {
            0, 1, 2, 1, 2, 3
        };
        
        createSquare.SetVerticlesUVTriangles(verticles, triangles);
        Mesh mesh = createSquare.Creating();

        // ASSERT
        Assert.AreEqual(mesh.vertices.Length, verticles.Length);
    }
}