using UnityEngine;
using UnityEngine.SceneManagement;

namespace IdleGame
{
    public class GameController : MonoBehaviour
    {
        public void WinGame()
        {
            // �¸� ó��
            Debug.Log("You win!");
            // �ʿ��� ��� ���⼭ �ٸ� �¸� ó�� ������ �߰��մϴ�.
        }

        public void LoseGame()
        {
            // �й� ó��
            Debug.Log("You lose!");
            // �ʿ��� ��� ���⼭ �ٸ� �й� ó�� ������ �߰��մϴ�.
        }
    }
}

