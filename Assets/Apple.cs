using UnityEngine;
using UnityEngine.UI; // Thêm thư viện UI

public class Apple : MonoBehaviour
{
    public GameObject winText; // Gán UI "You Win!" vào đây

    void Start()
    {
        winText.SetActive(false); // Ẩn chữ "YOU WIN!" lúc đầu
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("🍏 Đã ăn táo!");
            winText.SetActive(true); // Hiện chữ "YOU WIN!"
            Destroy(gameObject); // Xóa quả táo
            Time.timeScale = 0; // Dừng game
        }
    }
}
