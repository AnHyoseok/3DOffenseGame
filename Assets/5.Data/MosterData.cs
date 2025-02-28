using UnityEngine;

public enum MonsterType
{
    Tank,
    DPS,
    Speed,
    RangeAtk
}

[CreateAssetMenu(fileName = "MosterData", menuName = "Scriptable Objects/MosterData")]
public class MosterData : ScriptableObject
{
    public Sprite monsterIcon;
      public string monsterName;

    public float maxHealth;
    public int spawnCost;
    public int spawnCount;
    public float powerLevel;
    public float cooldown;
    public MonsterType type; // Tank, DPS, Speed 등
}
