using UnityEngine;

namespace Platformer.Mechanics
{
    public class Score : MonoBehaviour
    {
        private static int score = 0;

        // Change the score by the input amount, or increment it by 1 by default.
        public static void UpdateScore(int value = 1)
        {
            score += value;
        }

        public static int GetScore()
        {
            return score;
        }
    }
}