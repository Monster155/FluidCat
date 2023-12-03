using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private MapGenerator _mapGenerator;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private CatsGenerator _catsGenerator;

    void Start()
    {
        _mapGenerator.Init();
        // _cameraController.Init(_mapGenerator.MapSize);
        _catsGenerator.Init(_mapGenerator.MapSize);
    }
}