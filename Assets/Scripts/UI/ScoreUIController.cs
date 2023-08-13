using TMPro;
using UnityEngine;
using Platformer.Mechanics;

namespace Platformer.UI
{
    public class ScoreUIController : MonoBehaviour
    {
        public static TextMeshProUGUI CurrentScore;

        public static void UpdateScoreText()
        {
            CurrentScore = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
            if (CurrentScore != null)
            {
                CurrentScore.SetText($"Score: {ScoreController.GetScore()}");
            }
        }

    }
}