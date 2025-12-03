using UnityEngine;
using System.Collections;

public class PlayerActionsController : MonoBehaviour
{
    public WeaponData weapon;

    public bool isAttacking = false;
    public bool isPowerAttacking = false;
    public float cooldownTime;

    public void AttackManager(){
        WeaponData.tiposDeArmas currentWeapon = weapon.armaAtual; 
        if(Time.time < cooldownTime) return;

        switch(currentWeapon)
        {
            case WeaponData.tiposDeArmas.None:
                isAttacking = true;
                cooldownTime = Time.time + weapon.cooldown;

                StartCoroutine(ResetAttackState(weapon.cooldown * 0.5f));
            break;

        }
    }

     IEnumerator ResetAttackState(float delay)
    {
        yield return new WaitForSeconds(delay);
        isAttacking = false;
        isPowerAttacking = false;
    }
}
