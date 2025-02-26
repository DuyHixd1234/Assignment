using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;  // Prefab của đạn
    public Transform firePoint;  // Vị trí bắn đạn
    public float bulletSpeed = 10f;  // Tốc độ đạn
    private AudioSource audioSource;  // Âm thanh bắn

    private Animator animator;
    private Rigidbody2D rb;
    private float moveInput;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();  // Lấy AudioSource từ Player
        animator = GetComponent<Animator>();  // Lấy Animator từ Player
        rb = GetComponent<Rigidbody2D>();  // Lấy Rigidbody2D từ Player
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        // 🔹 Điều khiển animation chạy
        if (Mathf.Abs(moveInput) > 0.1f)
        {
            animator.Play("crun");  // Nếu di chuyển → chạy animation "crun"
        }
        else
        {
            animator.Play("cstay");  // Nếu đứng yên → quay về animation "cstay"
        }

        // 🔹 Điều khiển animation nhảy
        if (rb.linearVelocity.y > 0.1f)
        {
            animator.Play("cjump");  // Nếu đang nhảy → animation "cjump"
        }

        // 🔹 Nếu nhấn Space thì bắn
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(bulletSpeed * transform.localScale.x, 0);  // Bắn theo hướng nhân vật

        if (audioSource != null)
        {
            audioSource.Play();  // Phát âm thanh khi bắn
        }

        // 🔹 Chạy animation bắn (nếu bạn có animation bắn)
        animator.SetTrigger("Shoot");
    }
}
