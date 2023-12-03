using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private string _groundTag;

    private float _rayRadius = 1f;
    private Vector3 _lastMousePosition;

    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
            if (Input.GetTouch(i).phase.Equals(TouchPhase.Began)
                || Input.GetTouch(i).phase.Equals(TouchPhase.Moved))
            {
                if (Input.GetTouch(i).phase.Equals(TouchPhase.Began))
                    _lastMousePosition = Input.mousePosition;

                float distance = Vector3.Distance(_lastMousePosition, Input.mousePosition);
                
                float delta = (_rayRadius / 2) / distance;
                
                float t = 1;
                while (t > 0)
                {
                    UseRaycast(Vector3.Lerp(
                        _lastMousePosition,
                        Input.mousePosition,
                        t + 0));
                
                    t -= delta;
                }

                _lastMousePosition = Input.mousePosition;
            }
    }

    private void UseRaycast(Vector3 mousePosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit[] hits = Physics.SphereCastAll(ray, _rayRadius, 100);
        if (hits.Length > 0)
            foreach (RaycastHit hit in hits)
                if (hit.transform.tag.Equals(_groundTag))
                {
                    Mesh mesh = hit.transform.GetComponent<MeshController>().Mesh;
                    var verts = mesh.vertices;
                    var tris = mesh.triangles;
                    mesh.Clear();
                    print(hit.triangleIndex);
                    tris = RemoveTriangle(hit.triangleIndex, tris);
                    mesh.vertices = verts;
                    mesh.triangles = tris;
                    hit.transform.GetComponent<MeshController>().SetMesh(mesh);
                }
    }

    private int[] RemoveTriangle(int triangle, int[] tris)
    {
        tris[triangle * 3] = -1;
        tris[triangle * 3 + 1] = -1;
        tris[triangle * 3 + 2] = -1;

        tris = tris.Where(val => val >= 0).ToArray();

        return tris;
    }
}