using UnityEngine;
using UnityEngine.Serialization;

namespace Script.ProjectileScripts
{
    public class ExplodingProjectile : ProjectileType
    {
        public GameObject explosionObject;
        
        public override void OnHit(ContactPoint2D hit)
        {
            GameObject explosion = Instantiate(explosionObject, hit.point, Quaternion.identity);
            explosion.name = "projectile";
            Destroy(this.gameObject);
        }
    }
}
