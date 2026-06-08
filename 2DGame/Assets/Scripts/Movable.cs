using UnityEngine;

public class Movable : MonoBehaviour
{
    [SerializeField]private float speed = 3f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private int start = 1;
    [SerializeField] private int current;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        current = start;
    }

    void Update()
    {
        rb.linearVelocity= Vector2.right * speed * current;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MovableTrigger"))
        {
            speed = -speed;
        }
    }
}
