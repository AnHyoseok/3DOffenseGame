using UnityEngine;

namespace IdleGame{
    
public class SkillSystem
{
    public SkillData skillData;  // SkillManager���� ������ ��ų ������
    private float lastUsedTime = 0f;  // ���������� ���� �ð�
    private bool isSkillActive = false; // ��ų�� Ȱ��ȭ �������� üũ

    // �� �����Ӹ��� ȣ��Ǵ� ������Ʈ �޼���
    public void Update()
    {
        if (skillData.isAcquired)  // ��ų�� ȹ��Ǿ��� ���� ��� ����
        {
            if (skillData.attackType == AttackType.Stay)
            {
                HandleStaySkill();  // �������� �� ó��
            }
            else if (skillData.attackType == AttackType.Move)
            {
                HandleMoveSkill();  // ��Ÿ�Ӹ��� �߻� ó��
            }
        }
    }

    // Stay Ÿ��: 0.1�ʸ��� ���������� ������ �ֱ�
    void HandleStaySkill()
    {
        if (isSkillActive)
        {
            if (Time.time - lastUsedTime >= 0.1f)  // 0.1�ʸ��� ������
            {
                ApplyDamage(skillData.damage);  // ������ ����
                lastUsedTime = Time.time;  // �ð� ����
            }
        }
    }

    // Move Ÿ��: ��ų�� ��Ÿ�ӿ� ���� �߻�
    void HandleMoveSkill()
    {
        if (Time.time - lastUsedTime >= skillData.cooldown)  // ��Ÿ�Ӹ��� �߻�
        {
            lastUsedTime = Time.time;  // �ð� ����
            FireSkill();  // ��ų �߻�
        }
    }

    // ������ ���� (����: ������ ������ �ִ� �Լ�)
    void ApplyDamage(float damage)
    {
        Debug.Log("Damage applied: " + damage);
    }

    // ��ų �߻� (����: ����ü �߻�)
    void FireSkill()
    {
        if (skillData.isProjectile)
        {
            Debug.Log("Fire projectile skill!");  // ����ü ��ų �߻�
        }
        else
        {
            Debug.Log("Fire non-projectile skill!");  // ������ü ��ų �߻�
        }

        ApplyDamage(skillData.damage);  // ������ ����
    }

    // ��ų Ȱ��ȭ
    public void ActivateSkill()
    {
        isSkillActive = true;
        lastUsedTime = Time.time;  // Ȱ��ȭ �� �ð� �ʱ�ȭ
    }

    // ��ų ��Ȱ��ȭ
    public void DeactivateSkill()
    {
        isSkillActive = false;
    }
}

}