using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private SliderJoint2D sliderJoint;
    private JointMotor2D motor;
    private bool isMovingRight = true;

    void Start()
    {
        sliderJoint = GetComponent<SliderJoint2D>();
        motor = sliderJoint.motor;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Меняем направление движения
            isMovingRight = !isMovingRight;
            motor.motorSpeed = -motor.motorSpeed; // Инвертируем скорость мотора
            sliderJoint.motor = motor;
        }
    }
} 