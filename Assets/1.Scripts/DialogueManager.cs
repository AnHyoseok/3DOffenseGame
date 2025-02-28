using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IdleGame
{
    public class DialogueManager : MonoBehaviour
    {
        #region Variables
        public TextMeshProUGUI dialogueText;
        public Image leftCharacterImage;
        public Image rightCharacterImage;
        public Sprite[] leftCharacterSprites;
        public Sprite[] rightCharacterSprites;
        public string[] dialogueLines; // 인스펙터에서 설정할 대화 내용 배열
        public GameObject clickObject; // 클릭할 오브젝트
        private int currentDialogueIndex = 0;
        private bool isTyping = false;
        private bool skipTyping = false;
        #endregion

        private void Start()
        {
            clickObject.SetActive(false); // 초기에는 클릭 오브젝트를 비활성화
            StartCoroutine(DisplayDialogue());
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !isTyping)
            {
                clickObject.SetActive(false); // 클릭 시 오브젝트 비활성화
                StartCoroutine(DisplayDialogue());
            }
            else if (Input.GetMouseButtonDown(0) && isTyping)
            {
                skipTyping = true;
            }
        }

        IEnumerator DisplayDialogue()
        {
            while (currentDialogueIndex < dialogueLines.Length)
            {
                dialogueText.text = dialogueLines[currentDialogueIndex];

                // 캐릭터 이미지 설정
                if (currentDialogueIndex % 2 == 0)
                {
                    // 왼쪽 캐릭터 대화
                    SetCharacterVisibility(leftCharacterImage, rightCharacterImage, leftCharacterSprites);
                }
                else
                {
                    // 오른쪽 캐릭터 대화
                    SetCharacterVisibility(rightCharacterImage, leftCharacterImage, rightCharacterSprites);
                }

                isTyping = true;
                skipTyping = false;
                yield return StartCoroutine(TypeTextEffect(dialogueLines[currentDialogueIndex]));
                isTyping = false;

                // 클릭 대기
                clickObject.SetActive(true); // 클릭 오브젝트 활성화
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

                // 텍스트 지우기
                dialogueText.text = string.Empty;

                currentDialogueIndex++;
            }

            clickObject.SetActive(false); // 대화가 끝난 후 클릭 오브젝트 비활성화
        }

        void SetCharacterVisibility(Image activeCharacter, Image inactiveCharacter, Sprite[] characterSprites)
        {
            activeCharacter.color = new Color(activeCharacter.color.r, activeCharacter.color.g, activeCharacter.color.b, 1f);
            inactiveCharacter.color = new Color(inactiveCharacter.color.r, inactiveCharacter.color.g, inactiveCharacter.color.b, 0f);
        }

        IEnumerator TypeTextEffect(string text)
        {
            dialogueText.text = string.Empty;

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (skipTyping)
                {
                    dialogueText.text = text;
                    yield break;
                }

                stringBuilder.Append(text[i]);
                dialogueText.text = stringBuilder.ToString();
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
