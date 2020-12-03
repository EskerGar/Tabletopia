using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private float spawnRadius;
    [SerializeField] private SpawnSettings spawnSettings;
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Button buttonPrefab;
    [SerializeField] private RectTransform buttonSpawnPoint;
    [SerializeField] private float buttonOffset;

    private Vector3 _buttonPosition;

    private void Start()
    {
        _buttonPosition = buttonSpawnPoint.position;
        GenerateCubes();
    }

    private void GenerateCubes()
    {
        foreach (var cube in spawnSettings.CubesList)
        {
            SpawnCube(cube);
        }
    }
    
    private void SpawnCube(Material material)
    {
       var cube = Instantiate(cubePrefab);
       var halfRadius = spawnRadius * .5f;
       cube.transform.position = new Vector3(Random.Range(-halfRadius, halfRadius), transform.position.y, Random.Range(-halfRadius, halfRadius));
       cube.GetComponent<MeshRenderer>().material = material;
       SpawnButton(material).Init(cube.GetComponent<CubeBehaviour>());
    }

    private ButtonBehaviour SpawnButton(Material material)
    {
        var button = Instantiate(buttonPrefab, buttonSpawnPoint, true);
        button.transform.localScale = Vector3.one;
        button.transform.position = _buttonPosition;
        button.image.color = material.color;
        _buttonPosition += new Vector3(buttonOffset, 0f,0f);
        return button.GetComponent<ButtonBehaviour>();
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
        Gizmos.DrawCube(transform.position, Vector3.one);
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(buttonSpawnPoint.position, Vector3.one * .1f);
    }
}