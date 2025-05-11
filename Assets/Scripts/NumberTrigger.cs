using UnityEngine;

public class NumberTrigger : MonoBehaviour
{
    [SerializeField] private float number = 1f; // Число, которое будем инвертировать

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            number = -number; // Инвертируем знак числа
            Debug.Log($"Знак числа изменен на: {number}"); // Для проверки в консоли
        }
    }

    // Метод для получения текущего значения числа
    public float GetNumber()
    {
        return number;
    }
} 