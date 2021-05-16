using UnityEngine;

namespace Script.RenderScripts
{
    [RequireComponent(typeof(Animator))]
    public class PlayerRenderer : MonoBehaviour
    {
        public static readonly string[] DirectionArray =
        {
            "DirUp",  "DirLeft",  "DirDown",  "DirRight"
        };

        private int _lastDirection;
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetDirection(Vector2 direction)
        {
            if (direction.magnitude > 0.01f)
            {
                _lastDirection = DirectionToIndex(direction, 4);
                _animator.Play(DirectionArray[_lastDirection]);
            }
        }

        private int DirectionToIndex(Vector2 direction, int sliceCount)
        {
            Vector2 nomrDir = direction.normalized;
            float step = 360f / sliceCount;
            float halfStep = step / 2;
            float angle = Vector2.SignedAngle(Vector2.up, nomrDir);
            angle += halfStep;
            if (angle < 0)
            {
                angle += 360;
            }
            float stepCount = angle / step;
            return Mathf.FloorToInt(stepCount);
        }
    }
}
