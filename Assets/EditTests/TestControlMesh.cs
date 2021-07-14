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
            new Vector3(0, 0, 1),
            new Vector3(1, 0, 0),
            new Vector3(1, 0, 1)
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
        Vector3[] selectedVerticles = ControlMesh.GetVerticesSelectedSide(_square1, Side.UpLeft);
        Vector3[] resultVerticles = {new Vector3(0, 0, 1)};
        // ASSERT
        Assert.AreEqual(selectedVerticles, resultVerticles);
    }

    [Test]
    public void TestGetVerticlesDownRightSide()
    {
        //ACT
        Vector3[] selectedVerticles = ControlMesh.GetVerticesSelectedSide(_square1, Side.DownRight);
        Vector3[] resultVerticles = {new Vector3(1, 0, 0)};
        // ASSERT
        Assert.AreEqual(selectedVerticles, resultVerticles);
    }
    
    [Test]
    public void TestChangePositionVerticesUpLeft()
    {
        //ACT
        Vector3 newPosition = new Vector3(0, 0, 2);
        ControlMesh.ChangingPositionVertices(ref _square1, Side.UpLeft, newPosition);

        //ASSERT
        Vector3 selectedVertix = ControlMesh.GetVerticesSelectedSide(_square1, Side.UpLeft)[0];
        Assert.AreEqual(selectedVertix, newPosition);
    }

    [Test]
    public void TestShiftingPositionVerticesDownLeft()
    {
        //ACT
        Vector3 shift = new Vector3(-1, 0, 0);
        ControlMesh.ShiftingPositionVertices(ref _square2, Side.DownLeft, shift);
        
        //ASSERT
        Vector3 result = new Vector3(-1, 0, 0);
        Vector3 selectedVertix = ControlMesh.GetVerticesSelectedSide(_square2, Side.DownLeft)[0];
        Assert.AreEqual(selectedVertix, result);
    }
}