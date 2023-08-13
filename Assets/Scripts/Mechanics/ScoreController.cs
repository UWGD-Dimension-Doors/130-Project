using System;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class ScoreController : MonoBehaviour
    {
        private static int score = 0;

        // Change the score by the input amount, or increment it by 1 by default.
        public static void UpdateScore(float value = 1)
        {
            score += (int) Math.Round(value * 10);
            UI.ScoreUIController.UpdateScoreText();
        }

        public static int GetScore()
        {
            return score;
        }
    }
}