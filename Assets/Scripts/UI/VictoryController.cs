using UnityEngine;
using Platformer.Mechanics;
using TMPro;

namespace Platformer.UI
{

    public class VictoryController : MonoBehaviour
    {
        public TextMeshProUGUI FinalScore;

        private void Start()
        {
            FinalScore = GetComponent<TextMeshProUGUI>();
            UpdateFinalScore();
        }

        public void UpdateFinalScore()
        {
            if (FinalScore != null)
            {
                FinalScore.SetText($"Your Score: {Score.GetScore()}");
            }
        }
    }
}