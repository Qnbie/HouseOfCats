using UnityEngine;

namespace Script.ProjectileScripts
{
    public class CloneProjectile : ProjectileType
    {
        public ProjectileController cloneObjectA;
        public ProjectileController cloneObjectB;
        
        public override void OnHit(ContactPoint2D hit)
        {
            //First clone
            ProjectileController projectileController = GetComponent<ProjectileController>();
            var oldPath = projectileController.Path;
            Ray2D newPath1 = new Ray2D();
            newPath1.origin = hit.point;
            newPath1.direction = Vector2.Reflect(oldPath.direction, hit.normal);
            ProjectileController projectile1 = Instantiate(cloneObjectA, newPath1.origin + newPath1.direction*0.5f, Quaternion.identity);
            projectile1.Path = newPath1;
            projectile1.name = "projectile";
            //Second clone
            Ray2D newPath2 = new Ray2D();
            newPath2.origin = hit.point;
            newPath2.direction = -oldPath.direction;
            ProjectileController projectile2 = Instantiate(cloneObjectB, newPath2.origin+ newPath2.direction*0.5f, Quaternion.identity);
            projectile2.Path = newPath2;
            projectile2.name = "projectile";

            Destroy(this.gameObject);
        }
        
    }
}
