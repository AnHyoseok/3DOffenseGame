using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

namespace IdleGame
{
    public class EnemySpawnSelector : MonoBehaviour
    {
        public GameObject spawnSelectionUI;
        public Transform[] monsterObjects = new Transform[3];
        private Image[] monsterImages;
        private TextMeshProUGUI[] monsterNameTexts;
        private TextMeshProUGUI[] monsterInfoTexts;

        [Header("Monster Data")]
        [SerializeField] private MonsterData[] allMonsterData;
        private MonsterData[] currentChoices = new MonsterData[3];

        public GameObject[] monsterBoxButtons; // 6개의 오브젝트
        private EnemySpawnMouse spawnMouse;

        private void Start()
        {
            spawnSelectionUI.SetActive(false);
            InitializeMonsterBox();

            monsterImages = new Image[3];
            monsterNameTexts = new TextMeshProUGUI[3];
            monsterInfoTexts = new TextMeshProUGUI[3];

            for (int i = 0; i < monsterObjects.Length; i++)
            {
                Transform monster = monsterObjects[i];
                monsterImages[i] = monster.Find("MonsterImage").GetComponent<Image>();
                monsterNameTexts[i] = monster.Find("MonsterName").GetComponent<TextMeshProUGUI>();
                monsterInfoTexts[i] = monster.Find("info").GetComponent<TextMeshProUGUI>();
            }

            spawnMouse = FindAnyObjectByType<EnemySpawnMouse>();
        }

        private void InitializeMonsterBox()
        {
            for (int i = 0; i < monsterBoxButtons.Length; i++)
            {
                int index = i;
                Button button = monsterBoxButtons[i].GetComponent<Button>();
                if (button != null)
                {
                    button.onClick.AddListener(() => OnMonsterBoxButtonClick(index));
                }
            }
        }

        private void OnMonsterBoxButtonClick(int index)
        {
            if (index < currentChoices.Length)
            {
                MonsterData monsterData = currentChoices[index];
                spawnMouse.SetSelectedMonster(monsterData);
            }
        }

        public void ShowMonsterChoices()
        {
            if (allMonsterData == null || allMonsterData.Length < 3)
            {
                Debug.LogError("Not enough monster data!");
                return;
            }

            GetRandomMonsters();
            spawnMouse.SetCurrentChoices(currentChoices);
            UpdateMonsterUI();
            spawnSelectionUI.SetActive(true);
            Time.timeScale = 0;
        }

        private void GetRandomMonsters()
        {
            HashSet<int> selectedIndices = new HashSet<int>();
            for (int i = 0; i < currentChoices.Length; i++)
            {
                int randomIndex;
                do
                {
                    randomIndex = Random.Range(0, allMonsterData.Length);
                } while (selectedIndices.Contains(randomIndex));

                selectedIndices.Add(randomIndex);
                currentChoices[i] = allMonsterData[randomIndex];
            }
        }

        private void UpdateMonsterUI()
        {
            for (int i = 0; i < currentChoices.Length; i++)
            {
                MonsterData monster = currentChoices[i];
                if (monsterImages[i] != null && monster.monsterIcon != null)
                {
                    monsterImages[i].sprite = monster.monsterIcon;
                }
                if (monsterNameTexts[i] != null)
                {
                    monsterNameTexts[i].text = monster.monsterName;
                }
                if (monsterInfoTexts[i] != null)
                {
                    monsterInfoTexts[i].text = $"Type: {monster.type}\nHealth: {monster.maxHealth}\nCost: {monster.spawnCost}\nSpawn Count: {monster.spawnCount}\nLevel: {monster.level}";
                }
            }
        }

        private void AddToMonsterBox(MonsterData monster)
        {
            for (int i = 0; i < monsterBoxButtons.Length; i++)
            {
                Image buttonImage = monsterBoxButtons[i].GetComponent<Image>();
                if (buttonImage.sprite == null)
                {
                    buttonImage.sprite = monster.monsterIcon;
                    TextMeshProUGUI nameText = monsterBoxButtons[i].transform.Find("MonsterName").GetComponent<TextMeshProUGUI>();
                    TextMeshProUGUI cooldownText = monsterBoxButtons[i].transform.Find("Cooldown").GetComponent<TextMeshProUGUI>();

                    if (nameText != null)
                    {
                        nameText.text = monster.monsterName;
                    }
                    if (cooldownText != null)
                    {
                        cooldownText.text = $"Cooldown: {monster.cooldown}s";
                    }

                    Button button = monsterBoxButtons[i].GetComponent<Button>();
                    if (button != null)
                    {
                        button.onClick.AddListener(() => spawnMouse.SetSelectedMonster(monster));
                    }
                    break;
                }
            }
        }

        public void SetCurrentChoices(MonsterData[] choices)
        {
            currentChoices = choices;
        }

        public void SelectEnemy(int index)
        {
            if (currentChoices != null && index >= 0 && index < currentChoices.Length)
            {
              
                spawnMouse.SetSelectedMonster(currentChoices[index]);
            }
            else
            {
                Debug.LogError("Invalid monster index selected.");
            }
        }
    }
} 