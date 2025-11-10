using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10.0f;
    protected Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ResetPosition()
    {
        _rigidbody.position = new Vector2(0.0f, _rigidbody.position.y);
        _rigidbody.linearVelocity = Vector2.zero;
    }

    private Vector2 _direction;

    // Factor to control how fast the paddle follows touch
    [SerializeField] private float touchFollowSpeed = 10f;

    // Update is called once per frame
    private void Update()
    {
        _direction = Vector2.zero;

        // Keyboard input
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _direction = Vector2.right;
        }

        // Touch input with smoothing
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchWorldPos = Camera.main.ScreenToWorldPoint(touch.position);

            // Calculate difference along Y-axis
            float deltaY = touchWorldPos.x - transform.position.x;

            // Normalize to direction (-1 or 1)
            _direction = new Vector2(0, Mathf.Clamp(deltaY * touchFollowSpeed, -1f, 1f));
        }
    }

    private void FixedUpdate()
    {
        if (_direction.sqrMagnitude != 0)
        {
            _rigidbody.AddForce(_direction * this.speed);
        }
    }

}
