using UnityEngine;
using UnityEngine.UI;

namespace BubbleWarsEp4.Components
{
    public sealed class HandDisplay
        : MonoBehaviour
    {
        public Image BubbleBar;
        public float TargetFill;
        public float DepleteRate = 1.0f;

        public void AddToBubbleBar(float step)
        {
            TargetFill += step;
            if (TargetFill > 1.0f)
                TargetFill = 1.0f;

            if (TargetFill < 0.0f)
                TargetFill = 0.0f;
        }

        private void Awake()
        {
            BubbleBar.fillAmount = 0.0f;
            TargetFill = 0.0f;
        }

        private void Update()
        {
            BubbleBar.fillAmount = Mathf.Lerp(BubbleBar.fillAmount, TargetFill, Time.deltaTime*5.0f);
            AddToBubbleBar(-DepleteRate*Time.deltaTime);

        }
    }
}