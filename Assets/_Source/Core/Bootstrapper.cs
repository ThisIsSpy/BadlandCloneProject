using LevelGenerator;
using PlayerSystem;
using ScoreSystem;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Object playerPrefab;
        [SerializeField] private Object startSection;
        [SerializeField] private Object endSection;
        [SerializeField] private Object startingPoint;
        [SerializeField] private float flyingSpeed;
        [SerializeField] private float movingSpeed;
        [SerializeField] private InputListener inputListener;
        [SerializeField] private SceneManager sceneManager;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private List<Object> levelSectionList;
        [SerializeField] private RandomLevelGenerator randomLevelGenerator;
        [SerializeField] private GameOverPanel gameOverPanel;
        [SerializeField] private ScoreManager scoreManager;
        private PlayerModel model;
        private LevelSectionPool pool;
        private PlayerView view;
        private PlayerController controller;
        private FollowPlayer followPlayer;
        private CollisionDetector collisionDetector;
        private int difficulty;
        private void Start()
        {
            model = new(flyingSpeed, movingSpeed);
            pool = new(levelSectionList);
            difficulty = PlayerPrefs.GetInt("Difficulty");
            if (difficulty < 1) { difficulty = 1; }
            randomLevelGenerator.Construct(pool, levelSectionList.Count,startSection,endSection, startingPoint, difficulty);
            Object player = Instantiate(playerPrefab, new Vector3(0, -4), Quaternion.identity);
            view = player.GetComponent<PlayerView>();
            controller = player.GetComponent<PlayerController>();
            followPlayer = mainCamera.GetComponent<FollowPlayer>();
            collisionDetector = player.GetComponent<CollisionDetector>();
            followPlayer.Construct(player);
            view.Construct(player.GetComponent<Rigidbody2D>(), player.GetComponent<Collider2D>().bounds.extents.y, collisionDetector);
            controller.Construct(view, model);
            inputListener.Construct(controller,view,sceneManager);
            gameOverPanel.Construct(view);           
            sceneManager.Construct(view);
            collisionDetector.Construct(player.GetComponent<Rigidbody2D>(), view, scoreManager);
            scoreManager.LoadScore();
            if (scoreManager.Level < 1) { scoreManager.Level++; }
            randomLevelGenerator.GenerateLevel();
        }
    }
}