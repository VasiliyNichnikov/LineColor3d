using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ControlMesh
{
    public static Vector3[] GetVerticlesSelectedSide(Mesh mesh, Side side)
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
                return vertix.x < center.x && vertix.y > center.y;

            case Side.DownLeft:
                return vertix.x < center.x && vertix.y < center.y;

            case Side.UpRight:
                return vertix.x > center.x && vertix.y > center.y;

            case Side.DownRight:
                return vertix.x > center.x && vertix.y < center.y;

            default:
                throw new Exception("Не найдена сторона");
        }
    }

    public static void ChangingPositionVerticalsMeshSelectedSide(ref Mesh mesh, Side side, Vector3 position)
    {
        Vector3[] verticles = new Vector3[mesh.vertices.Length];
        Vector3 center = mesh.bounds.center;

        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            Vector3 vertix = mesh.vertices[i];
            bool suitablePoint = DoesVertexFitToTheSide(center, vertix, side);
            if (suitablePoint)
            {
                vertix = position;
            }
            verticles[i] = vertix;
        }

        mesh.vertices = verticles;
    }
}