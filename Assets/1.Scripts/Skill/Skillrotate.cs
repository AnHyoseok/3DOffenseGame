using UnityEngine;

namespace IdleGame.Skil
{
    public class Skillrotate : MonoBehaviour
    {
        public float rotationSpeed = 50f; // ȸ�� �ӵ�
        private Transform heroTransform;

        void Start()
        {
            heroTransform = transform.parent; 
            if (heroTransform == null)
            {
                Debug.LogError("Skill�� Hero�� �ڽ��� �ƴմϴ�!");
                return;
            }
        }

        void Update()
        {
            if (heroTransform != null)
            {
                //  Hero�� Scale.x ���� ���� ȸ�� ���� ����
                float direction = heroTransform.localScale.x > 0 ? -1f : 1f;
                transform.Rotate(0, 0, direction * rotationSpeed * Time.deltaTime);
            }
        }
    }
}
