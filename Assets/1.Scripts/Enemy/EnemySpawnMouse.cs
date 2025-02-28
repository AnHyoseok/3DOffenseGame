using UnityEngine;
using System.Collections.Generic;

namespace IdleGame
{
    public class EnemySpawnMouse : MonoBehaviour
    {
        public GameObject previewPrefab;
        private GameObject previewInstance;
        private MonsterData currentMonsterData;
        private Camera mainCamera;
        private List<GameObject> spawnedEnemies = new List<GameObject>();
        private MonsterData[] currentChoices;

        private float spawnCooldown = 0f;
        private float lastSpawnTime = -Mathf.Infinity;

        void Start()
        {
            mainCamera = Camera.main;
        }

        void Update()
        {
            FollowMouse();

            if (Input.GetMouseButtonDown(0) && currentMonsterData != null && Time.time >= lastSpawnTime + spawnCooldown)
            {
                SpawnMonster();
                lastSpawnTime = Time.time;
                DisablePreview();
            }
        }

        public void SetSelectedMonster(MonsterData monsterData)
        {
            currentMonsterData = monsterData;
            spawnCooldown = monsterData.cooldown;
            if (previewInstance == null)
            {
                previewInstance = Instantiate(previewPrefab);
            }

            SpriteRenderer previewSprite = previewInstance.GetComponent<SpriteRenderer>();
            if (previewSprite != null)
            {
                previewSprite.sprite = monsterData.monsterIcon;
            }
            previewInstance.SetActive(true);
        }

        public void SetCurrentChoices(MonsterData[] choices)
        {
            currentChoices = choices;
        }

        public void SelectEnemy(int index)
        {
            if (currentChoices != null && index >= 0 && index < currentChoices.Length)
            {
                SetSelectedMonster(currentChoices[index]);
            }
            else
            {
                Debug.LogError("Invalid monster index selected.");
            }
        }

        void SpawnMonster()
        {
            if (currentMonsterData == null)
            {
                Debug.LogError("No monster data selected for spawning!");
                return;
            }

            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            GameObject monsterPrefab = PrefabManager.Instance.GetPrefab(currentMonsterData.type);
            if (monsterPrefab != null)
            {
                for (int i = 0; i < currentMonsterData.spawnCount; i++)
                {
                    GameObject spawnedMonster = Instantiate(monsterPrefab, mousePosition, Quaternion.identity);
                    spawnedEnemies.Add(spawnedMonster);
                }
            }
            else
            {
                Debug.LogError($"Prefab for {currentMonsterData.type} not found!");
            }
        }

        void FollowMouse()
        {
            if (previewInstance != null)
            {
                Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;
                previewInstance.transform.position = mousePosition;
            }
        }

        void DisablePreview()
        {
            if (previewInstance != null)
            {
                previewInstance.SetActive(false);
            }
        }

        public List<GameObject> GetSpawnedEnemies()
        {
            return spawnedEnemies;
        }

        public float GetLastSpawnTime()
        {
            return lastSpawnTime;
        }
    }
}
