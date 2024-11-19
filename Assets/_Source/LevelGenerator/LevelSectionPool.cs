using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LevelGenerator
{
    public class LevelSectionPool
    {
        private Queue<Object> _levelSectionPool;

        public LevelSectionPool(List<Object> levelSectionPrefabList)
        {
            InitPool(levelSectionPrefabList);
        }
        private void InitPool(List<Object> levelSectionPrefabList)
        {
            _levelSectionPool = new();
            System.Random rand = new();
            List<Object> list = levelSectionPrefabList.OrderBy((item) => rand.Next()).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                Object levelSection = Object.Instantiate(list[i]);
                _levelSectionPool.Enqueue(levelSection);
            }
        }
        public bool TryGetLevelSection(out Object levelSection)
        {
            levelSection = null;
            if (_levelSectionPool.Count > 0)
            {
                levelSection = _levelSectionPool.Dequeue();
                return true;
            }
            return false;
        }
        public void ReturnToPool(Object LevelSection)
        {
            _levelSectionPool.Enqueue(LevelSection);
        }
    }
}
