using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LevelGenerator
{
    public class LevelSectionPool
    {
        private Queue<LevelSection> _levelSectionPool;

        public LevelSectionPool(List<LevelSection> levelSectionPrefabList)
        {
            InitPool(levelSectionPrefabList);
        }
        private void InitPool(List<LevelSection> levelSectionPrefabList)
        {
            _levelSectionPool = new();
            System.Random rand = new();
            List<LevelSection> list = levelSectionPrefabList.OrderBy((item) => rand.Next()).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                LevelSection levelSection = Object.Instantiate(list[i]);
                _levelSectionPool.Enqueue(levelSection);
            }
        }
        public bool TryGetLevelSection(out LevelSection levelSection)
        {
            levelSection = null;
            if (_levelSectionPool.Count > 0)
            {
                levelSection = _levelSectionPool.Dequeue();
                return true;
            }
            return false;
        }
        public void ReturnToPool(LevelSection LevelSection)
        {
            _levelSectionPool.Enqueue(LevelSection);
        }
    }
}
