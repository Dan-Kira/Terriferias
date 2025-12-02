using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public PlayerController player;
    public WeaponData weaponData;

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && player.isPickingItem)
        {
            player.weapon = weaponData; 
            player.haveAnItemEquipped = true;

            string itemName = weaponData.weaponName;

            if(itemName == "Axe") { player.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow; }
            else if(itemName == "Knife") { player.gameObject.GetComponent<SpriteRenderer>().color = Color.purple; }
            else if(itemName == "Pistol") { player.gameObject.GetComponent<SpriteRenderer>().color = Color.brown; }
            else if(itemName == "Shotgun") { player.gameObject.GetComponent<SpriteRenderer>().color = Color.pink; }
            else if(itemName == "Grenade") { player.gameObject.GetComponent<SpriteRenderer>().color = Color.gray; }
            else if(itemName == "Molotov") { player.gameObject.GetComponent<SpriteRenderer>().color = Color.orange; }

            player.isPickingItem = false;
            Destroy(gameObject);
        }
    }
}
