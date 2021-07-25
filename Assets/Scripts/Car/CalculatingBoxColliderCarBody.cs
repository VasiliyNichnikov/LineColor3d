using UnityEngine;

public class CalculatingBoxColliderCarBody : MonoBehaviour
{
    public Mesh MeshCar => GetComponent<SkinnedMeshRenderer>().sharedMesh;
}
