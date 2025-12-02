using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public WeaponData weapon;
    public int damage;

    void Start()
    {
        damage = weapon.damage;
    }
}
