using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
namespace IdleGame
{
    public class MainBaseController : MonoBehaviour
    {
        #region Variables
        public GameObject baseCanvas;
        public GameObject stageCanvas;
        public GameObject warrensCanvas;
        public GameObject academyCanvas;
        public Button stageGoButton;
        public Button warrensButton;
        public Button academyButton;
        #endregion
        
        
        void Start()
        {

            // Start ��ư�� Ŭ�� �̺�Ʈ �߰�
            stageGoButton.onClick.AddListener(OnStageGo);
            warrensButton.onClick.AddListener(OnWarrens);
            academyButton.onClick.AddListener(OnAcademy);

        }
        void OnStageGo()
        {
            baseCanvas.SetActive(false);
            stageCanvas.SetActive(true);
        }

        void OnWarrens()
        {
            
            warrensCanvas.SetActive(true);
        }
        void OnAcademy()
        {
          
            academyCanvas.SetActive(true);
        }
    }
}