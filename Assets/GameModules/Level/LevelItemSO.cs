using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Level_1" , menuName = "Levels/Level")]
public class LevelItemSO : ScriptableObject
{
    public int LevelIndex;
    public string LevelResourceName;
    public Object LevelScene;
    public Sprite LevelIcon;
}
