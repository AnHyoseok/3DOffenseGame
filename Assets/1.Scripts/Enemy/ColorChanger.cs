using System.Collections;
using UnityEngine;

namespace IdleGame
{
    public class ColorChanger : MonoBehaviour
    {
        private MeshRenderer meshRenderer;
        public Color hitColor = Color.red;
        private Color originalColor;
        private bool isDamaged = false;

        void Start()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            originalColor = meshRenderer.material.color;
        }

        void Update()
        {
            if (isDamaged)
            {
                    meshRenderer.material.color = hitColor;
            }
            else
            {
                meshRenderer.material.color = originalColor;
            }
        }

        public void SetDamageState(bool damaged)
        {
            isDamaged = damaged;

            if (isDamaged)
            {
                StopAllCoroutines();  
                StartCoroutine(ResetColorAfterDelay(0.1f));  
            }
        }

        private IEnumerator ResetColorAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            isDamaged = false;
        }
    }
}
