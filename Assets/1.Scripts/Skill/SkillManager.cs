using UnityEngine;
namespace IdleGame{
public class SkillManager : MonoBehaviour
{
    public GameObject skillPrefab;  // SkillProjectile ������
    public Transform hero;  // Hero�� ��ġ
    public SkillSystem skillSystem;  // SkillSystem ��ü
    public SkillData someSkillData;

    void Start()
    {

        skillSystem = new SkillSystem();  // SkillSystem ��ü ����
        skillSystem.skillData = someSkillData;  
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))  // QŰ�� ������ ��
        {
            CreateSkill();  // ��ų ����
        }
        skillSystem.Update();  // �� ������ Update ȣ��
    }
    void CreateSkill()
    {
        // Hero ��ġ���� SkillProjectile ����
        Instantiate(skillPrefab, hero.position, Quaternion.identity);
    }
    // ��ų Ȱ��ȭ
    public void ActivateSkill()
    {
        skillSystem.ActivateSkill();  // ��ų Ȱ��ȭ
    }

    // ��ų ��Ȱ��ȭ
    public void DeactivateSkill()
    {
        skillSystem.DeactivateSkill();  // ��ų ��Ȱ��ȭ
    }
}
}