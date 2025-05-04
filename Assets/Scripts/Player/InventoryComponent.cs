using UnityEngine;

[RequireComponent(typeof(Player))]

public class InventoryComponent : MonoBehaviour
{
    Player _player = Player.player;
    private const int _inventorySize = 3;
    private EPowerup[] _inventory = new EPowerup[_inventorySize];
    private int selected = 0;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
