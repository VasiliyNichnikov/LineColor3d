using UnityEngine;

public interface IProvideBordersObject
{
    Vector3 GetPositionMeshPoint(SideMeshObject side);
    Transform Transform { get; }
}
