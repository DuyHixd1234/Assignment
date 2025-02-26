using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyTime = 2f;  // Thời gian tự hủy đạn

    private void Start()
    {
        Debug.Log("Bullet spawned!");
        Invoke("DestroyBullet", destroyTime);  // Hủy đạn sau 2 giây
    }

    private void DestroyBullet()
    {
        Debug.Log("DestroyBullet() called!");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bullet hit: " + collision.gameObject.name);

        if (collision.CompareTag("Enemy"))  // Nếu trúng Enemy
        {
            Debug.Log("Hit Enemy! Destroying...");

            collision.gameObject.SetActive(false);  // Ẩn Enemy ngay lập tức
            Destroy(collision.gameObject, 0.1f);  // Hủy Enemy sau 0.1 giây để tránh lỗi vật lý

            DestroyBullet();  // Hủy Bullet
        }
    }
}
