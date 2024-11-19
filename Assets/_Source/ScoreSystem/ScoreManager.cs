using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ScoreSystem
{
    public class ScoreManager : MonoBehaviour
    {
        public int PowerupScore;
        public int LevelFinishScore;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI levelText;
        private int score;
        private int level;

        public int Level
        {
            get { return level; }
            set { level = value; UpdateText(); }
        }

        public void SaveScore()
        {
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.SetInt("Level", level);
        }
        public void LoadScore()
        {
            score = PlayerPrefs.GetInt("Score");
            level = PlayerPrefs.GetInt("Level");
            UpdateText();
        }
        public void ResetScore()
        {
            score = 0;
            level = 1;
            PlayerPrefs.SetInt("Difficulty", 1);
            SaveScore();
            UpdateText();
        }
        public void UpdateText()
        {
            scoreText.text = $"Score: {score}";
            levelText.text = $"Level: {level}";
        }
        public void AddToScore(int add)
        {
            score += add;
            UpdateText();
        }
        public void AddToLevel()
        {
            level++;
            UpdateText();
        }
    }
}
