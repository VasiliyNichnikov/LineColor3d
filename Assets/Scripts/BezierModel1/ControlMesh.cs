using System;
using System.Linq;
using UnityEngine;

public static class ControlMesh
{
    public static Vector3[] GetVerticesSelectedSide(Mesh mesh, Side side)
    {
        Vector3 center = mesh.bounds.center;

        return (from vertix in mesh.vertices
            let suitablePoint = DoesVertexFitToTheSide(center, vertix, side)
            where suitablePoint
            select vertix).ToArray();
    }

    private static bool DoesVertexFitToTheSide(Vector3 center, Vector3 vertix, Side side)
    {
        switch (side)
        {
            case Side.UpLeft:
                return vertix.x < center.x && vertix.z > center.z;

            case Side.DownLeft:
                return vertix.x < center.x && vertix.z < center.z;

            case Side.UpRight:
                return vertix.x > center.x && vertix.z > center.z;

            case Side.DownRight:
                return vertix.x > center.x && vertix.z < center.z;

            default:
                throw new Exception("Не найдена сторона");
        }
    }

    // public static void ChangeValueVertices(ControlVertix[] controlVertices, Side side,
    //     Vector3 position)
    // {
    //     ControlVertix[] selectedControlVertices = GetControlVerticesSelectedSide(controlVertices, side);
    //     for(int i = 0; i < selectedControlVertices.Length; i++)
    //     {
    //         CheckVertixAxesX(ref selectedControlVertices[i], position);
    //         CheckVertixAxesZ(ref selectedControlVertices[i], position);
    //     }
    // }
    //
    // public static ControlVertix[] GetControlVerticesSelectedSide(ControlVertix[] controlVertices, Side side)
    // {
    //     return (from vertix in controlVertices
    //         let suitablePoint = DoesVertexFitToTheSide(vertix.Center, vertix.Vertix, side)
    //         where suitablePoint
    //         select vertix).ToArray();
    // }
    //
    // private static void CheckVertixAxesX(ref ControlVertix controlVertix, Vector3 position)
    // {
    //     Vector3 vertix = controlVertix.Vertix;
    //     switch (controlVertix.Sides.x)
    //     {
    //         case Side.Right:
    //             vertix = new Vector3(vertix.x + position.x, position.y, vertix.z);
    //             break;
    //
    //         case Side.Left:
    //             vertix = new Vector3(vertix.x - position.x, position.y, vertix.z);
    //             break;
    //     }
    //
    //     controlVertix.Vertix = vertix;
    // }
    //
    // private static void CheckVertixAxesZ(ref ControlVertix controlVertix, Vector3 position)
    // {
    //     Vector3 vertix = controlVertix.Vertix;
    //     switch (controlVertix.Sides.z)
    //     {
    //         case Side.Up:
    //             vertix = new Vector3(vertix.x, position.y, vertix.z + position.z);
    //             break;
    //
    //         case Side.Down:
    //             vertix = new Vector3(vertix.x, position.y, vertix.z - position.z);
    //             break;
    //     }
    //
    //     controlVertix.Vertix = vertix;
    // }
    
    /// <summary>
    /// Изменяет позиции вершин меша.
    /// </summary>
    /// <param name="mesh">Меш</param>
    /// <param name="side">Сторона меша на которой будут происходить изменения позиции</param>
    /// <param name="position">Позиция вершин</param>
    public static void ChangingPositionVertices(ref Mesh mesh, Side side, Vector3 position)
    {
        Vector3[] vertices = new Vector3[mesh.vertices.Length];
        Vector3 center = mesh.bounds.center;

        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            Vector3 vertix = mesh.vertices[i];
            bool suitablePoint = DoesVertexFitToTheSide(center, vertix, side);
            if (suitablePoint)
            {
                vertix = position;
            }

            vertices[i] = vertix;
        }

        mesh.vertices = vertices;
    }
    
    /// <summary>
    /// Сдвигает позиции вершин меша.
    /// </summary>
    /// <param name="mesh">Меш</param>
    /// <param name="side">Сторона меша на которой будут происходить изменения позиции</param>
    /// <param name="shift">Сдвиг</param>
    public static void ShiftingPositionVertices(ref Mesh mesh, Side side, Vector3 shift)
    {
        Vector3[] vertices = new Vector3[mesh.vertices.Length];
        Vector3 center = mesh.bounds.center;

        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            Vector3 vertix = mesh.vertices[i];
            bool suitablePoint = DoesVertexFitToTheSide(center, vertix, side);
            if (suitablePoint)
            {
                vertix += shift;
            }

            vertices[i] = vertix;
        }

        mesh.vertices = vertices;
    }
}