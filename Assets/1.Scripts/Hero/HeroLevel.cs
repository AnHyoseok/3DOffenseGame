using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IdleGame
{
    public class HeroLevel : MonoBehaviour
    {
        
        public int level = 1;                  // ���� ����
        public int currentExp = 0;             // ���� ����ġ
        public int expToNextLevel = 100;       // ���� �������� �ʿ��� ����ġ
        public bool isLevelUp;

        [Header("UI Elements")]
        public TextMeshProUGUI levelText;      // ������ ǥ���� UI �ؽ�Ʈ
        public TextMeshProUGUI expText;        // ���� ����ġ�� ǥ���� UI �ؽ�Ʈ
        public Slider expSlider;               // ����ġ ���൵�� ǥ���� UI �����̴�

        void Start()
        {
            UpdateUI();
        }

        // ����ġ ȹ�� �޼���
        public void GainExperience(int amount)
        {
            currentExp += amount;

            // ���� �� Ȯ��
            while (currentExp >= expToNextLevel)
            {
                currentExp -= expToNextLevel;
                LevelUp();
            }

            UpdateUI();
        }

        // ���� �� ó��
        void LevelUp()
        {
            level++;
            // �ʿ��� ����ġ ���� (��: 20% ����)
            expToNextLevel = Mathf.RoundToInt(expToNextLevel * 1.2f);
            Debug.Log($"���� ��! ���� ����: {level}");
            isLevelUp = true;
            // ���� �� �� �߰� ȿ���� ���⿡ �߰��ϼ��� (��: ���� ����, ��ų ���� ��)
        }

        // UI ������Ʈ
        void UpdateUI()
        {
            if (levelText != null)
                levelText.text = $"Lvl: {level}";

            if (expText != null)
            {
                int expRemaining = expToNextLevel - currentExp;
                expText.text = $"Next Exp: {expRemaining}";
            }

            if (expSlider != null)
                expSlider.value = (float)currentExp / expToNextLevel;
        }
    }
}
