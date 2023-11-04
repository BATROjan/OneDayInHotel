using UnityEngine;

[CreateAssetMenu(fileName = "HallConfig", menuName = "Configs/HallConfig")]
public class HallConfig : ScriptableObject
{
    
    [SerializeField] private float allDuraction;
    [SerializeField] private float endPositionX;
    [SerializeField] private float spawnPositionX;
    [SerializeField] private float sumPath;
    
}