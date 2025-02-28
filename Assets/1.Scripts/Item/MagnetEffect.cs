
using UnityEngine;

namespace IdleGame
{
    // �ڼ� ȿ���� ó���ϴ� Ŭ����
    public class MagnetEffect : MonoBehaviour
    {
        public float magnetRange = 5f;  // �ڼ��� ����
        public float magnetSpeed = 2f;  // �ڼ��� ������� �ӵ�
        private Transform hero;

        void Start()
        {

            GameObject heroObject = GameObject.FindGameObjectWithTag("Hero");
            if (heroObject != null)
            {
                hero = heroObject.transform;
            }
        }

        protected virtual void Update()
        {
            if (hero != null)
            {
                AttractExperienceItems();
            }
        }

        //���߿� �÷��̾��ʿ��� range �� ��������
        protected void AttractExperienceItems()
        {
            GameObject[] experienceItems = GameObject.FindGameObjectsWithTag("Item");

            foreach (GameObject item in experienceItems)
            {
                float distance = Vector2.Distance(hero.position, item.transform.position);

                if (distance <= magnetRange)
                {
                    // Hero ��ġ�� �������� �������
                    Vector2 direction = (hero.position - item.transform.position).normalized;
                    item.transform.position = Vector2.MoveTowards(item.transform.position, hero.position, magnetSpeed * Time.deltaTime);
                }
            }
        }
    }
}