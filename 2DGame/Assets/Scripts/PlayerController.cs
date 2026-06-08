using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float force = 5f;
    private AudioSource audioSource;
    private Rigidbody2D rb;
    private float horizontalMovement;
    private SpriteRenderer sr;
    private Animator anim;
    private Canvas winScr;
    private Canvas loseScr;
    void Start()
    {
        winScr = GameObject.Find("WinScr").GetComponent<Canvas>();
        loseScr = GameObject.Find("LoseScr").GetComponent<Canvas>();
        winScr.enabled = false;
        loseScr.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * force, ForceMode2D.Impulse);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        if (horizontalMovement < 0)
        {
            transform.localScale = new Vector3(3.76949f, 3.4509f, 1);
        }
        else if (horizontalMovement > 0)
        {
            transform.localScale = new Vector3(-3.76949f, 3.4509f, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death"))
        {
            Destroy(gameObject);
            loseScr.enabled = true;
        }
        else if(collision.gameObject.CompareTag("Skarner"))
        {
            Destroy(gameObject);
            winScr.enabled = true;
        }
    }
}
