using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Script.ControllerScripts
{
    public class GameController : MonoBehaviour
    {

        public PlayerController playerCharacter;
        public List<EnemyController> enemyCharacters;
        public Text score;
        
        public float wight;
        public float height;

        
        private bool _gameOver = false;
        private float _playerScore = 0;
        private PlayerController _playerController;
        private List<EnemyController> _enemyControllers;
        
        // Start is called before the first frame update
        void Start()
        {
            _enemyControllers = new List<EnemyController>();
            _playerController = Instantiate(playerCharacter, Vector3.zero, Quaternion.identity);
            _playerController.PlayerDie += GameOver;
            InvokeRepeating("SpawnAnEnemy",2, StaticController.SPAWN_SPEED);
            InvokeRepeating("IncrementPoint",0,1);
        }
        
        private void IncrementPoint()
        {
            if (!_gameOver)
            {
                _playerScore++;
                score.text = _playerScore.ToString();
            }
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(Vector3.zero, new Vector3(wight,height,0));
        }

        private void SpawnAnEnemy()
        {
            if(!_gameOver){
                Vector2 position = new Vector2(
                    (Random.value - 0.5f) * wight * 0.8f,
                    (Random.value - 0.5f) * height * 0.8f);
                float type = Random.value * 10 % enemyCharacters.Count;
                var enemy = Instantiate(enemyCharacters[(int) type], position, Quaternion.identity);
                enemy.playerObject = _playerController;
                enemy.EnemyDie += EnemyDie;
                _enemyControllers.Add(enemy);
            }
        }

        public void GameOver()
        {
            Destroy(_playerController.gameObject);
            for (int i = _enemyControllers.Count - 1; i >= 0; i--)
            {
                Destroy(_enemyControllers[i].gameObject);
            }
            _gameOver = true;
            score.text = "Game Over\n" + _playerScore.ToString();
            score.color = Color.black;
        }

        public void EnemyDie(EnemyController enemyController)
        {
            Debug.Log("Enemy Die");
            _playerScore += StaticController.POINT_ENEMY_DIE;
            score.text = _playerScore.ToString();
            _enemyControllers.Remove(enemyController);
            Destroy(enemyController.gameObject);
        }
    }
}
