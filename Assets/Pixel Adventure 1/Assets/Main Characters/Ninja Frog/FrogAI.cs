using UnityEngine;

public class FrogAI : MonoBehaviour
{
    public float speed = 2f;  // Tốc độ di chuyển
    public float moveDistance = 3f;  // Khoảng cách di chuyển tối đa
    private Vector2 startPosition;
    private int direction = 1;  // 1: đi sang phải, -1: đi sang trái

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * direction * Time.deltaTime);

        // Nếu quái đi quá khoảng cách quy định -> đổi hướng
        if (Mathf.Abs(transform.position.x - startPosition.x) >= moveDistance)
        {
            direction *= -1;  // Đảo hướng
            FlipSprite();  // Lật hình ảnh quái vật
        }
    }

    private void FlipSprite()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;  // Lật hình ảnh quái vật
        transform.localScale = scale;
    }
}
