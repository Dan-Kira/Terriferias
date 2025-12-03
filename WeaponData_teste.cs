using UnityEngine;

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public enum tiposDeArmas {None, Melee, Range, Special};
    public tiposDeArmas armaAtual;

    public int damage;
    public int durability;
    public int maxDurability;
    public float cooldown;
    public float range;
    public int ammo;
    public int maxAmmo;
}
