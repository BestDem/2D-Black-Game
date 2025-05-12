using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject deathMenu;
    public void ImageDeathPlayer()
    {
        PlayerMovement.Instance.SetCanMove(false);
        animator.SetBool("isDeath",true);

        deathMenu.SetActive(true);
    }
}
