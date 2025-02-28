using UnityEngine;
using UnityEngine.UI;

namespace IdleGame
{
public class EnemySellectUI : MonoBehaviour
{
public EnemySpawnMouse spawnManager;
    public Button[] enemyButtons;

    void Start()
    {
        for (int i = 0; i < enemyButtons.Length; i++)
        {
            int index = i;
            enemyButtons[i].onClick.AddListener(() => spawnManager.SelectEnemy(index));
        }
    }
}
}