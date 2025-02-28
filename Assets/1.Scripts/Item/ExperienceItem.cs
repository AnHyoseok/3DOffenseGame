
using UnityEngine;

namespace IdleGame{
public class ExperienceItem : MagnetEffect
{
    public int experienceAmount = 20; // ����ġ ��

    protected override void Update()
    {
        base.Update(); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hero"))
        {
            HeroLevel heroExp = other.GetComponent<HeroLevel>();
            if (heroExp != null)
            {
                heroExp.GainExperience(experienceAmount);  // ����ġ �߰�
                Destroy(gameObject);  // ����ġ ������Ʈ ����
            }
        }
    }
}
}