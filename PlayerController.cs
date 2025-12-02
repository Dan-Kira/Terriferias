using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float cooldownTime;
    public bool isAttacking = false;
    public bool haveAnItemEquipped = false;
    public bool isPickingItem = false;
    public bool isPowerAttacking;
    public bool isRecharging;

    private Vector2 currentMoveInput;

    [SerializeField] private string inputNameHorizontal;
    [SerializeField] private string inputNameVertical;
    [SerializeField] private KeyCode attackKey;
    [SerializeField] private KeyCode actionKey;
    
    
    private Rigidbody2D rb;
    public WeaponData weapon;
    public GameObject bulletPrefab;
    public GameObject specialWeaponPrefab;
    public Transform shotPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {   
        currentMoveInput = new Vector2(Input.GetAxisRaw(inputNameHorizontal), Input.GetAxisRaw(inputNameVertical)).normalized;

        if (Time.time > cooldownTime)
        {
            if (Input.GetKeyDown(attackKey))
            {
                HandleAttack();
            }

            if (Input.GetKeyDown(actionKey))
            {
                HandleAction();
            }
        }
    }

    public void HandleAttack()
    {
        WeaponData.tiposDeArmas currentWeapon = weapon.armaAtual;
        if(Time.time <cooldownTime) return;

        switch (currentWeapon)
        {
            case WeaponData.tiposDeArmas.Nenhum:
                isAttacking = true;
                cooldownTime = Time.time + weapon.cooldown;

                StartCoroutine(ResetAttackState(weapon.cooldown * 0.5f));
            break;

            case WeaponData.tiposDeArmas.Melee:
                isAttacking = true;
                cooldownTime = Time.time + weapon.cooldown;

                StartCoroutine(ResetAttackState(weapon.cooldown * 0.5f));
            break;

            case WeaponData.tiposDeArmas.Range:
                if (weapon.ammo > 0)
                {
                    GameObject newBullet = Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);

                    weapon.ammo--;
                    cooldownTime = Time.time + weapon.cooldown;
                }
                break;

            case WeaponData.tiposDeArmas.Special:
                    Instantiate(specialWeaponPrefab, shotPoint.position, shotPoint.rotation);
                    cooldownTime = Time.time + weapon.cooldown * 2;
                break;
        }
    }

    public void HandleAction()
    {
        WeaponData.tiposDeArmas currentWeapon = weapon.armaAtual;

        switch (currentWeapon)
        {
            case WeaponData.tiposDeArmas.Nenhum:
                if (!haveAnItemEquipped)
                {
                    isPickingItem = true;
                }
                break;

            case WeaponData.tiposDeArmas.Melee:
                if (isRecharging)
                {
                    isPowerAttacking = true;
                    cooldownTime = Time.time + (weapon.cooldown * 2);
                    isRecharging = false;
                    StartCoroutine(ResetAttackState(weapon.cooldown * 0.5f)); 
                }
                break;

            case WeaponData.tiposDeArmas.Range:
                if (weapon.ammo <= 0)
                {
                    isRecharging = true; 
                    weapon.ammo = 10;
                    isRecharging = false;
                }
                break;

            case WeaponData.tiposDeArmas.Special:
                
                Instantiate(specialWeaponPrefab, shotPoint.position, shotPoint.rotation);
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
