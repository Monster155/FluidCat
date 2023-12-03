using UnityEngine;

public class MeshController : MonoBehaviour
{
    [SerializeField] private MeshFilter _meshFilter;
    [SerializeField] private MeshCollider _meshCollider;

    public Mesh Mesh => _meshFilter.mesh;

    public void SetMesh(Mesh mesh)
    {
        _meshFilter.mesh = mesh;
        _meshCollider.sharedMesh = mesh;
    }
}