using Script.ControllerScripts;
using UnityEngine;

namespace Script.ProjectileScripts
{
    public class BouncyProjectile : ProjectileType
    {
        private int _lifeCount = StaticController.BOUNCE_PROJECTILE_LIFE;
        public override void OnHit(ContactPoint2D hit)
        {
            if (_lifeCount == 0) Destroy(this.gameObject);
            ProjectileController projectileController = GetComponent<ProjectileController>();
            var oldPath = projectileController.Path;
            Ray2D newPath = new Ray2D();
            newPath.origin = hit.point;
            newPath.direction = Vector2.Reflect(oldPath.direction, hit.normal);
            projectileController.Path = newPath;
            _lifeCount--;
        }
    }
}
