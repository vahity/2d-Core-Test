using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsContainer", menuName = "Levels/Container")]
public class LevelsContainer : ScriptableObject
{
    public List<LevelItemSO> Levels = new List<LevelItemSO>();
}
