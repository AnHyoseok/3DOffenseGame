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
        public string[] dialogueLines; // �ν����Ϳ��� ������ ��ȭ ���� �迭
        public GameObject clickObject; // Ŭ���� ������Ʈ
        private int currentDialogueIndex = 0;
        private bool isTyping = false;
        private bool skipTyping = false;
        #endregion

        private void Start()
        {
            clickObject.SetActive(false); // �ʱ⿡�� Ŭ�� ������Ʈ�� ��Ȱ��ȭ
            StartCoroutine(DisplayDialogue());
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !isTyping)
            {
                clickObject.SetActive(false); // Ŭ�� �� ������Ʈ ��Ȱ��ȭ
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

                // ĳ���� �̹��� ����
                if (currentDialogueIndex % 2 == 0)
                {
                    // ���� ĳ���� ��ȭ
                    SetCharacterVisibility(leftCharacterImage, rightCharacterImage, leftCharacterSprites);
                }
                else
                {
                    // ������ ĳ���� ��ȭ
                    SetCharacterVisibility(rightCharacterImage, leftCharacterImage, rightCharacterSprites);
                }

                isTyping = true;
                skipTyping = false;
                yield return StartCoroutine(TypeTextEffect(dialogueLines[currentDialogueIndex]));
                isTyping = false;

                // Ŭ�� ���
                clickObject.SetActive(true); // Ŭ�� ������Ʈ Ȱ��ȭ
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

                // �ؽ�Ʈ �����
                dialogueText.text = string.Empty;

                currentDialogueIndex++;
            }

            clickObject.SetActive(false); // ��ȭ�� ���� �� Ŭ�� ������Ʈ ��Ȱ��ȭ
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
