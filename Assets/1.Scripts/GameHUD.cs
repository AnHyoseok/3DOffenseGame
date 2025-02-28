using UnityEngine;
using UnityEngine.UI;




public class GameHUD : MonoBehaviour
{
  
   
    public GameObject pauseCanvas;

    public Button continueButton;
    public Button restartButton;
    
    public Button backButton;


    private bool isPaused = false;


  
    void Start()
    {
        // 비활성화된 상태로 시작
        pauseCanvas.SetActive(false);
      
        


        // Continue 버튼 클릭 이벤트 연결
        if (continueButton != null)
        {
            continueButton.onClick.AddListener(OnContinueButtonClick);
        }

        // Restart 버튼 클릭 이벤트 연결
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(OnRestartButtonClick);
        }

      
        // Back 버튼 클릭 이벤트 연결
        if (backButton != null)
        {
            backButton.onClick.AddListener(OnBackButtonClick);
        }

     
    }

    void Update()
    {
        // ESC 키를 눌렀을 때 Pause 상태 변경
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    // Pause 상태를 토글하는 함수
    public void TogglePause()
    {
        isPaused = !isPaused;
        pauseCanvas.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }

    // Continue 버튼 클릭 시 호출되는 함수
    public void OnContinueButtonClick()
    {
        // Pause 해제
        isPaused = false;
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    // Restart 버튼 클릭 시 호출되는 함수
    public void OnRestartButtonClick()
    {
      
       
        Time.timeScale = 1; // 타임스케일 초기화
        //현재씬 다시시작
    }



    // Back 버튼 클릭 시 호출되는 함수
    public void OnBackButtonClick()
    {
    
        pauseCanvas.SetActive(true);
    }

}
