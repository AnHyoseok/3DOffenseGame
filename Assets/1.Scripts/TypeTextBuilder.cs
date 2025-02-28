using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IdleGame
{
    public class TypeTextBuilder : MonoBehaviour
    {
        #region Variables
        public TextMeshProUGUI textComponent;
        public string[] textsToType;
        public Image spriteToChange;
        public Sprite[] sprites; 
        private int currentIndex = 0;
        #endregion

        private void Start()
        {
            StartCoroutine(TypeTextEffect(textsToType[currentIndex]));
        }

        IEnumerator TypeTextEffect(string text)
        {
            textComponent.text = string.Empty;

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                stringBuilder.Append(text[i]);
                textComponent.text = stringBuilder.ToString();
                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(1.0f); 

            // 이미지 스프라이트 교체
            if (sprites.Length > currentIndex)
            {
                spriteToChange.sprite = sprites[currentIndex];
            }

            //yield return new WaitForSeconds(1.0f); 

            // 텍스트 초기화
            textComponent.text = string.Empty;

            // 다음 타이핑 
            currentIndex++;
            if (currentIndex < textsToType.Length)
            {
                StartCoroutine(TypeTextEffect(textsToType[currentIndex]));
            }
        }
    }
}
