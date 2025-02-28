using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
namespace IdleGame
{
public class SelectUIController : MonoBehaviour
{
 #region Variables
    public GameObject selectUI;


    public Button monsterButton;
    public Button skillButton;
    public Button relicButton;
    #endregion

    void Start()
    {
        // Add button listeners
        monsterButton.onClick.AddListener(OnMonsterButtonClicked);
        skillButton.onClick.AddListener(OnSkillButtonClicked);
        relicButton.onClick.AddListener(OnRelicButtonClicked);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleSelectUI(true);
        }
    }

    private void ToggleSelectUI(bool isActive)
    {
        selectUI.SetActive(isActive);
        Time.timeScale = isActive ? 0 : 1;
    }

    private void OnMonsterButtonClicked()
    {
        ToggleSelectUI(false);
        EnemySpawnSelector enemySpawnSelector = FindAnyObjectByType<EnemySpawnSelector>();
        if (enemySpawnSelector != null)
        {
            enemySpawnSelector.ShowMonsterChoices();
        }
        else
        {
            Debug.LogWarning("EnemySpawnSelector not found");
        }
    }

    private void OnSkillButtonClicked()
    {
        ToggleSelectUI(false);
        // SkillSelector skillSelector = FindAnyObjectByType<SkillSelector>();
        // skillSelector.ShowSkillChoices();
    }

    private void OnRelicButtonClicked()
    {
        ToggleSelectUI(false);
        // RelicSelector relicSelector = FindAnyObjectByType<RelicSelector>();
        // relicSelector.ShowRelicChoices();
    }
}   
}
