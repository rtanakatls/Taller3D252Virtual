using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Pattern", menuName = "Game/Pattern")]
public class Patterns : ScriptableObject
{
    public List<GameObject> objectPrefab;
}
