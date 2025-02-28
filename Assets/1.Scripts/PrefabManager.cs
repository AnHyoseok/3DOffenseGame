using System.Collections.Generic;
using UnityEngine;

namespace IdleGame
{
    public class PrefabManager : MonoBehaviour
    {
        private static PrefabManager _instance;
        public static PrefabManager Instance => _instance;

        [SerializeField] private List<GameObject> monsterPrefabs;

        private Dictionary<MonsterType, GameObject> prefabDictionary;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
                InitializePrefabs();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void InitializePrefabs()
        {
            prefabDictionary = new Dictionary<MonsterType, GameObject>();
            foreach (var monsterData in Resources.LoadAll<MonsterData>("MonsterData"))
            {
                if (!prefabDictionary.ContainsKey(monsterData.type))
                {
                    GameObject prefab = Resources.Load<GameObject>($"Prefabs/{monsterData.type}");
                    if (prefab != null)
                    {
                        prefabDictionary[monsterData.type] = prefab;
                    }
                    else
                    {
                        Debug.LogError($"Prefab for {monsterData.type} not found!");
                    }
                }
            }
        }

        public GameObject GetPrefab(MonsterType type)
        {
            if (prefabDictionary.TryGetValue(type, out GameObject prefab))
            {
                return prefab;
            }
            Debug.LogError($"Prefab for {type} not found!");
            return null;
        }
    }
}