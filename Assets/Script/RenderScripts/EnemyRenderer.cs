using UnityEngine;

namespace Script.RenderScripts
{
    [RequireComponent(typeof(Animator))]
    public class EnemyRenderer : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Shoot()
        {
            _animator.Play($"Shoot");
        }
    }
}
