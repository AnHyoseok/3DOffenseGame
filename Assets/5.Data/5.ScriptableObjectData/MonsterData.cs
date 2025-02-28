using UnityEngine;

namespace IdleGame
{
    public enum MonsterType
    {
        Tank,
        DPS,
        Speed,
        RangeAtk
    }

    [CreateAssetMenu(fileName = "MonsterData", menuName = "Scriptable Objects/MonsterData")]
    public class MonsterData : ScriptableObject
    {
        public string monsterName;
        public int spawnCost;
        public int maxHealth;
        public int spawnCount;
        public float powerLevel;
        public float cooldown;
        public MonsterType type; // Tank, DPS, Speed 등
        public Sprite monsterIcon; // 몬스터 이미지 추가

        public int level = 1; // 기본 레벨

        // 레벨업 시 수치 증가
        public void LevelUp()
        {
            level++;
            maxHealth = Mathf.RoundToInt(maxHealth * 1.1f); // 예: 10% 증가
            powerLevel *= 1.1f; // 예: 10% 증가
        }
    }
}
