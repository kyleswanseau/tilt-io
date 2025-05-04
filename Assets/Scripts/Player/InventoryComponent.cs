using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]

public class InventoryComponent : MonoBehaviour
{
    private Player _player = Player.player;
    private const int _inventorySize = 3;
    private EPowerup[] _inventory = new EPowerup[_inventorySize];
    private int selected = 0;

    private InputAction _useAction;
    private InputAction _nextAction;
    private InputAction _prevAction;
    private InputAction _slot0Action;
    private InputAction _slot1Action;
    private InputAction _slot2Action;
    [SerializeField] private Image[] _slotsImages;

    private void Awake()
    {
        _inventory = Enumerable.Repeat(EPowerup.NONE, _inventorySize).ToArray();
    }

    private void Start()
    {
        Debug.Assert(_slotsImages.Length == _inventorySize && _slotsImages != null, "Bad inventory size");
        _useAction = InputSystem.actions.FindAction("Use");
        _nextAction = InputSystem.actions.FindAction("Next");
        _prevAction = InputSystem.actions.FindAction("Previous");
        _slot0Action = InputSystem.actions.FindAction("Slot0");
        _slot1Action = InputSystem.actions.FindAction("Slot1");
        _slot2Action = InputSystem.actions.FindAction("Slot2");
        UpdateSlotSelection();
    }

    private void Update()
    {
        if (_useAction.WasPressedThisFrame())
        {
            _inventory[selected] = EPowerup.NONE;
            UpdateSlotGraphic();
        }
        if (_nextAction.WasPressedThisFrame())
        {
            if (selected < _inventorySize - 1)
            {
                selected++;
            }
            else
            {
                selected = 0;
            }
            UpdateSlotSelection();
        }
        if (_prevAction.WasPressedThisFrame())
        {
            if (selected > 0)
            {
                selected--;
            }
            else
            {
                selected = _inventorySize - 1;
            }
            UpdateSlotSelection();
        }
        if (_slot0Action.WasPressedThisFrame())
        {
            selected = 0;
            UpdateSlotSelection();
        }
        if (_slot1Action.WasPressedThisFrame())
        {
            selected = 1;
            UpdateSlotSelection();
        }
        if (_slot2Action.WasPressedThisFrame())
        {
            selected = 2;
            UpdateSlotSelection();
        }
    }

    private void UpdateSlotSelection()
    {
        foreach (Image image in _slotsImages)
        {
            image.color = new Color(0.5f, 0.5f, 0.5f, 1f);
            image.GetComponentInChildren<TextMeshProUGUI>().color = new Color(1f, 1f, 1f);
        }
        _slotsImages[selected].color = new Color(1f, 1f, 1f, 1f);
        _slotsImages[selected].GetComponentInChildren<TextMeshProUGUI>().color = new Color(0f, 0f, 0f);
    }

    private void UpdateSlotGraphic()
    {
        for (int i = 0; i < _inventorySize; i++)
        {
            _slotsImages[i].GetComponentsInChildren<Image>()[1].sprite =
                Powerup.GetSprites()[(int)_inventory[i]];
        }
    }

    public bool PickupPowerup(EPowerup powerup)
    {
        for (int i = 0; i < _inventorySize; i++)
        {
            if (_inventory[i] == EPowerup.NONE)
            {
                _inventory[i] = powerup;
                UpdateSlotGraphic();
                return true;
            }
        }
        return false;
    }
}
