using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace IdleGame
{
    public class StageSelectController : MonoBehaviour
    {
        #region Variables
        public GameObject baseCanvas;
        public GameObject stageCanvas;
        public GameObject informationUI;
        public Image informationUIImage;
        public TextMeshProUGUI mapNameText;
        public TextMeshProUGUI bossNameText;
        public Button startButton;
        public Button backButton;

        public Button[] stageButtons;
        public Sprite[] stageImages;
        public string[] stageNames;
        public string[] bossNames;

        private string selectedMapName; 
        #endregion

        void Start()
        {
            for (int i = 0; i < stageButtons.Length; i++)
            {
                int index = i;
                stageButtons[i].onClick.AddListener(() => OnStageButtonClicked(index));
            }

          
            startButton.onClick.AddListener(OnStartButtonClicked);
            backButton.onClick.AddListener(OnBackButtonClicked);
            // �⺻������ ���� UI ��Ȱ��ȭ
            informationUI.SetActive(false);
        }

        void OnStageButtonClicked(int index)
        {
            // ���� UI Ȱ��ȭ
            informationUI.SetActive(true);

            // �̹��� �� �ؽ�Ʈ �� ��ų ���� Ȱ��ȭ
            if (index < stageImages.Length)
            {
                informationUIImage.sprite = stageImages[index];
            }

            if (index < stageNames.Length)
            {
                mapNameText.text = stageNames[index];
                selectedMapName = stageNames[index]; 
            }

            if (index < bossNames.Length)
            {
                bossNameText.text = bossNames[index];
            }
        }

        void OnStartButtonClicked()
        {
            
            if (!string.IsNullOrEmpty(selectedMapName))
            {
                SceneManager.LoadScene(selectedMapName);
            }
        }

        void OnBackButtonClicked()
        {
            informationUI.SetActive(false);
            baseCanvas.SetActive(true);
            //���߿� �ִϸ��̼����� ����
            stageCanvas.SetActive(false);
           
        }
    }
}
