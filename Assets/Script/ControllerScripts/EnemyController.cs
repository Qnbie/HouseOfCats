using System;
using Script.ProjectileScripts;
using Script.RenderScripts;
using UnityEngine;

namespace Script.ControllerScripts
{
    public delegate void Die(EnemyController enemyController);
    
    [RequireComponent(typeof(Rigidbody2D),typeof(EnemyRenderer))]
    public class EnemyController : MonoBehaviour
    {
        public event Die EnemyDie;
        
        public PlayerController playerObject;
        public ProjectileController projectileObject;

        private EnemyRenderer _enemyRenderer;
        private Transform _playerTransform;
        private float _lastShoot = 0;
    
        private void Start()
        {
            _playerTransform = playerObject.GetComponent<Transform>();
            _enemyRenderer = GetComponent<EnemyRenderer>();
        }

        private void FixedUpdate()
        {
            if (Time.time - _lastShoot > 3)
            {
                Vector2 targetPosition = _playerTransform.position;
                Vector2 position = transform.position;
                Vector2 target = (targetPosition - position).normalized;
                _lastShoot = Time.time;
                Shoot(position, target);
            }
        }

        private void Shoot(Vector3 position, Vector3 target)
        {
            _enemyRenderer.Shoot();
            ProjectileController projectile = Instantiate(projectileObject, position + target * 0.8f, Quaternion.identity);
            projectile.Path = new Ray2D(position, target);
            projectile.name = "projectile";
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (EnemyDie != null && other.collider.name == "projectile") EnemyDie(this);
        }
    }
}
