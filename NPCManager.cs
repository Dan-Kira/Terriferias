using System.Collections;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public int npcHealth;
    public int npcMaxHealth;

    private int baseDamage => player.weapon != null ? player.weapon.damage : 1;

    public PlayerController player;
    public WeaponData weapon;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player.isAttacking)
            {
                npcHealth -= baseDamage;
            }
            else if (player.isPowerAttacking)
            {
                npcHealth -= baseDamage * 2;
            }
        }

        else if (collision.CompareTag("Bullet"))
        {
            BulletScript bulletScript = collision.GetComponent<BulletScript>();
            if (bulletScript != null)
            {
                npcHealth -= bulletScript.damage; 
                Destroy(collision.gameObject);
            }
        }

        else if (collision.CompareTag("SpecialWeapon"))
        {
            SpecialWeapon specialScript = collision.GetComponent<SpecialWeapon>();
            if (specialScript != null)
            {
                npcHealth -= specialScript.damage;
            }   
        }

        if (npcHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Generator generator = FindAnyObjectByType<Generator>();
        if (generator != null)
        {
            generator.DecreaseEnemyCount();
        }
        Destroy(gameObject);
    }
}
