using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/SpawnSettings", fileName = "SpawnSettings")]
public class SpawnSettings : ScriptableObject
{
    [SerializeField] private List<Material> cubesList;

    public List<Material> CubesList => cubesList;
}
