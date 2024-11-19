using LevelGenerator;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace LevelGenerator
{
    public class RandomLevelGenerator : MonoBehaviour
    {
        private LevelSectionPool _pool;
        private LevelSection _startSection;
        private LevelSection _endSection;
        private Transform _startingPoint;
        private int _maxLevelLength;
        private int _difficulty;


        public void Construct(LevelSectionPool pool, int maxLevelLength, LevelSection startSection, LevelSection endSection, Transform startingPoint, int difficulty)
        {
            _pool = pool;
            _maxLevelLength = maxLevelLength;
            _startSection = startSection;
            _endSection = endSection;
            _startingPoint = startingPoint;
            _difficulty = difficulty;
        }
        public void GenerateLevel()
        {
            int levelLength;
            if(_difficulty > _maxLevelLength)
            {
                levelLength = _maxLevelLength;
            }
            else
            {
                levelLength = _difficulty;
            }
            Vector3 generatingPos = _startingPoint.position;
            Instantiate(_startSection, generatingPos, Quaternion.identity);
            generatingPos.x += 22f;
            for (int i = 0; i < levelLength; i++)
            {
                if (_pool.TryGetLevelSection(out var levelSection))
                {
                    levelSection.GameObject().SetActive(true);
                    levelSection.GameObject().transform.position = generatingPos;
                    generatingPos.x += 22f;
                }
            }
            Instantiate(_endSection, generatingPos, Quaternion.identity);
            _difficulty++;
            PlayerPrefs.SetInt("Difficulty",_difficulty);
        }
    }
}
