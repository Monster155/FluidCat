using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Vector2Int _mapSize = new Vector2Int(15, 20);
    [SerializeField] private int _density = 1;
    [SerializeField] private MeshController _meshController;

    public Vector2Int MapSize => _mapSize;

    public void Init()
    {
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        int k = 0;
        for (float y = 0; y < _mapSize.y; y += 1f / _density)
        {
            for (float x = 0; x < _mapSize.x; x += 1f / _density)
            {
                vertices.Add(new Vector3(x, y));
                vertices.Add(new Vector3(x + 1, y));
                vertices.Add(new Vector3(x, y + 1));
                vertices.Add(new Vector3(x + 1, y + 1));
                vertices.Add(new Vector3(x + 0.5f, y + 0.5f));

                triangles.Add(k + 0);
                triangles.Add(k + 2);
                triangles.Add(k + 4);

                triangles.Add(k + 4);
                triangles.Add(k + 2);
                triangles.Add(k + 3);

                triangles.Add(k + 3);
                triangles.Add(k + 1);
                triangles.Add(k + 4);

                triangles.Add(k + 4);
                triangles.Add(k + 1);
                triangles.Add(k + 0);

                k += 5;
            }
        }

        Mesh mesh = new Mesh();
        mesh.Clear();
        mesh.name = "GroundMesh";
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        _meshController.SetMesh(mesh);
    }
}