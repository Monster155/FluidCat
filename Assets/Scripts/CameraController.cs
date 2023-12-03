using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public void Init(Vector2Int mapSize)
    {
        _camera.orthographicSize = mapSize.x + 1;
        transform.position = new Vector3(mapSize.x / 2f - 0.5f, mapSize.y / 2f + 3.5f, -10f);
    }
}