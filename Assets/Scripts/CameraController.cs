using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector2 offset;
    private float smoothSpeed = 0125f;

    public void SetFollowTarget(Transform player)
    {
        // Желаемая позиция камеры с учетом смещения 
        Vector2 desiredPosition = player.position; 
        
        // Интерполяция позиции камеры для плавного следования 
        Vector2 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, smoothSpeed); 
        
        // Обновление позиции камеры 
        transform.position = smoothedPosition; 
    }
}
