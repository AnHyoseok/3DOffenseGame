using UnityEngine;

namespace IdleGame
{
    public enum AttackType
    {
        Stay,   //  
        Move    // ŸӸ ü ߻
    }

    [CreateAssetMenu(fileName = "NewSkill", menuName = "Scriptable Objects/SkillData")]
    public class SkillData : ScriptableObject
    {
        public Sprite icon;
        public AttackType attackType; // ų  
        public bool isAcquired;    // ų ȹ 
        public bool isProjectile;  // ü 
        public int skillCount;     // ü  ų 
        public float cooldown;     // ų Ÿ
        public int level;          // ų 
        public float size;         // ų ũ
        public float damage;       // ų 
        public float attackRange; //ü Ÿ
    }
}
