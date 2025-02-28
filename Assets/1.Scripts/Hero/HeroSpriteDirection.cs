using UnityEngine;
namespace IdleGame
{
    public class HeroSpriteDirection : MonoBehaviour
    {
        protected SpriteRenderer spriteRenderer;
        public GameObject heroSprite;
        protected Vector3 lastPosition;
        private Vector3 originalScale; // �⺻ ũ�� ����

        protected virtual void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            lastPosition = heroSprite.transform.position;
            originalScale = heroSprite.transform.localScale; // �ʱ� ������ ����
        }

        protected virtual void UpdateSpriteDirection()
        {
            Vector3 movementDirection = heroSprite.transform.position - lastPosition;

            if (movementDirection.x > 0)
            {
                heroSprite.transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
            }
            else if (movementDirection.x < 0)
            {
                heroSprite.transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
            }

            lastPosition = heroSprite.transform.position;
        }
    }
}