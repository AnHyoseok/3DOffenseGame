using UnityEngine;
namespace IdleGame
{
public class GameManager : MonoBehaviour
{
 public float heroDefeatedTime = 300f; // 5분 생존
    private float currentTime;
    private bool isHeroDefeated = false;
    
    private void Update() 
    {
        if(!isHeroDefeated) 
        {
            currentTime += Time.deltaTime;
            if(currentTime >= heroDefeatedTime) 
            {
                GameLose(); // 시간 내 히어로를 쓰러트리지 못함
            }
        }
    }

    private void GameLose()
    {
        isHeroDefeated = true;
        Debug.Log("Game Over - 시간 초과");
    }
}
}