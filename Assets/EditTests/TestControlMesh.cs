using NUnit.Framework;
using UnityEngine;

public class TestControlMesh
{
    private Mesh _square1, _square2;

    [SetUp]
    public void SetUp()
    {
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


        _square1 = createSquare.Creating();
        _square2 = createSquare.Creating();
    }

    [Test]
    public void TestGetVerticlesUpLeftSide()
    {
        //ACT
        Vector3[] selectedVerticles = ControlMesh.GetVerticlesSelectedSide(_square1, Side.UpLeft);
        Vector3[] resultVerticles = {new Vector3(0, 1, 0)};
        // ASSERT
        Assert.AreEqual(selectedVerticles, resultVerticles);
    }

    [Test]
    public void TestGetVerticlesDownRightSide()
    {
        //ACT
        Vector3[] selectedVerticles = ControlMesh.GetVerticlesSelectedSide(_square1, Side.DownRight);
        Vector3[] resultVerticles = {new Vector3(1, 0, 0)};
        // ASSERT
        Assert.AreEqual(selectedVerticles[0], resultVerticles[0]);
    }

    [Test]
    public void TestOffsetPointMeshUpLeft()
    {
        // ARRANGE

        //ACT
        Vector3 newPosition = new Vector3(0, 2, 0);
        ControlMesh.ChangingPositionVerticalsMeshSelectedSide(ref _square1, Side.UpLeft, newPosition);

        //ASSERT
        Assert.AreNotEqual(_square1.vertices, _square2.vertices);
    }
}