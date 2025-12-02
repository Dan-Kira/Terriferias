using UnityEngine;

public class SpecialWeapon : MonoBehaviour
{
    public WeaponData weapon;
    public int damage;

    void Start()
    {
        damage = weapon.damage;
    }
}
