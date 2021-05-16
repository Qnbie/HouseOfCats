using Script.RenderScripts;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Script.ControllerScripts
{
    public delegate void GameOver();
    
    [RequireComponent(typeof(Rigidbody2D),typeof(BoxCollider2D),typeof(PlayerRenderer))]
    public class PlayerController : MonoBehaviour
    {
        public event GameOver PlayerDie;
        
        private float movementSpeed = StaticController.PLAYER_SPEED;

        private Rigidbody2D _rbody;
        private PlayerRenderer _playerRenderer;

        private void Awake()
        {
            _rbody = GetComponent<Rigidbody2D>();
            _playerRenderer = GetComponent<PlayerRenderer>();
        }

        private void FixedUpdate()
        {
            Vector2 currentPos = _rbody.position;
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
            inputVector = Vector2.ClampMagnitude(inputVector, 1);
            Vector2 movement = inputVector * movementSpeed;
            Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
            _rbody.MovePosition(newPos);
            _playerRenderer.SetDirection(movement);
        }

        private void OnCollisionEnter2D(Collision2D collisionInfo)
        {
            if (PlayerDie != null && collisionInfo.collider.name!= "Wall") PlayerDie();
        }
    }
}
