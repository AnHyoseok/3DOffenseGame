
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IdleGame
{
    /// <summary>
    /// ������ ü�� ����
    /// </summary>
    public class HeroHealth : MonoBehaviour, IDamageable
    {
        
        #region Variables
        private GameController gameController;

        [Header("Hero Stats")]
        public int maxHealth = 100;      // �ִ� ü��
        private int currentHealth;       // ���� ü��

        [Header("UI Elements")]
        public Image imageBackground;    // ü�¹� ��� �̹���
        public Image imageFill;          // ü�¹� ä��� �̹���
        public TextMeshProUGUI hpText;              // ü�� ǥ�� �ؽ�Ʈ


        #endregion

        void Start()
        {
          
            gameController = FindAnyObjectByType<GameController>();
            currentHealth = maxHealth;  // ���� �� ü���� �ִ� ü������ ����
            UpdateHealthUI();           // �ʱ� ü�� UI ������Ʈ
        }


        //void OnTriggerEnter2D(Collider2D collider)
        //{
        //    //'Enemy' �±׸� ���� Ʈ���ſ� ����� �� ü�� ����
        //    if (collider.CompareTag("Enemy"))
        //    {

        //        EnemyStatus enemy = collider.GetComponent<EnemyStatus>();
        //        if (enemy != null)
        //        {
        //            TakeDamage(enemy.damage);
        //        }
        //    }
        //}

        // �������� �޾��� �� ȣ��
        public void TakeDamage(int amount)
        {
            currentHealth -= amount;

            // ü�� �ּҰ� ����
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
 
            Debug.Log($"Hero  {amount} damage. Current Health: {currentHealth}");
          
            UpdateHealthUI(); // ü�� UI ������Ʈ

            if (currentHealth <= 0)
            {
                Die();

            }
        }

        // ���� ��� ó��
        void Die()
        {
            Debug.Log("Hero Died");
            gameController.LoseGame();

            Destroy(gameObject); // ���� ������Ʈ �ı� 
        }

        // ü�� UI ������Ʈ
        void UpdateHealthUI()
        {
            if (imageFill != null)
            {
                // ü�� ���� ���
                float healthRatio = (float)currentHealth / maxHealth;
                imageFill.fillAmount = healthRatio;
            }

            if (hpText != null)
            {
                // ü�� �ؽ�Ʈ ������Ʈ
                hpText.text = $"hp : {currentHealth} ";
            }
        }
    }
}
