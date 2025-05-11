using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    private SliderJoint2D movingPlatform;
    private JointMotor2D motor;

    private void Start()
    {
        movingPlatform = platform.GetComponent<SliderJoint2D>();
        
        // Проверяем, что компонент найден
        if (movingPlatform == null)
        {
            Debug.LogError("SliderJoint2D не найден на объекте платформы!");
            return;
        }

        // Инициализируем мотор
        motor = movingPlatform.motor;
        movingPlatform.useMotor = true; // Убеждаемся, что мотор включен
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            Debug.Log("Триггер вход");
            
            // Получаем текущий мотор
            motor = movingPlatform.motor;
            
            motor.motorSpeed = -motor.motorSpeed;
            
            movingPlatform.motor = motor;
        }
    }
}
