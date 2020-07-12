using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Enemy Data", menuName ="Enemy/EnemeyData")]
public class EnemyData : ScriptableObject
{
    public GameObject prefab;

    [SerializeField]
    private float _health;
    public Color color;

    public Size enmeySize; 
    public enum Size { 
        Small,
        Big
    }; 
}
