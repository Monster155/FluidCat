using UnityEngine;

public class CatsGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _catPrefab;

    public void Init(Vector2Int mapSize)
    {
        for (int i = 0; i < mapSize.x; i+=2)
        {
            Instantiate(_catPrefab, new Vector3(i, mapSize.y + 2), Quaternion.identity, transform);
        }
    }
}
