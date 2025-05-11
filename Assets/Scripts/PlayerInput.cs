using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Shooter shooter;
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        shooter = GetComponent<Shooter>();
    }

    private void Update()
    {
        float horizontalDirection = Input.GetAxis("Horizontal");
        bool isJumpButtonPress = Input.GetButtonDown("Jump");
        bool isFireButtonPress = Input.GetButtonDown("Fire1");

        playerMovement.Move(horizontalDirection, isJumpButtonPress);
        shooter.FireButtonDown(isFireButtonPress);

    }
}
