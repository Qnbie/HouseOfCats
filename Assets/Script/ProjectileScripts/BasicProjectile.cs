using UnityEngine;

namespace Script.ProjectileScripts
{
    public class BasicProjectile : ProjectileType
    {
        public override void OnHit(ContactPoint2D hit)
        {
            Destroy(this.gameObject);
        }
    }
}
