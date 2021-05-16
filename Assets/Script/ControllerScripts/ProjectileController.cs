using System;
using Script.ControllerScripts;
using UnityEngine;

namespace Script.ProjectileScripts
{
    [RequireComponent(typeof(Rigidbody2D), typeof(ProjectileType))]
    public class ProjectileController : MonoBehaviour
    {
        private float movementSpeed = StaticController.PROJECTILE_SPEED;

        [NonSerialized]public Ray2D Path;
        private Rigidbody2D _rbody;
        private ProjectileType _projectalType;
        private float _lifeTime;

        private void Awake()
        {
            _rbody = GetComponent<Rigidbody2D>();
            _projectalType = GetComponent<ProjectileType>();
            _lifeTime = Time.time;
        }

        private void FixedUpdate()
        {
            Vector2 currentPos = _rbody.position;
            Vector2 movement = Path.direction * movementSpeed;
            Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
            _rbody.MovePosition(newPos);
        }

        private void OnCollisionEnter2D(Collision2D collisionInfo)
        {
            if (collisionInfo.collider.name != "projectile")
            {
                _projectalType.OnHit(collisionInfo.GetContact(0));
            }
        }
    }
}
