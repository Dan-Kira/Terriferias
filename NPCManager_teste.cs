using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public PlayerActionsController PlayerAct;
    public WeaponData weapon;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerAct.isAttacking)
            {
                health -= weapon.damage;
            }
            else if (PlayerAct.isPowerAttacking)
            {
                health -= weapon.damage * 2;
            }
        }
    }
}   
