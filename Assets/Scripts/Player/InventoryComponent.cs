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
    private EPower[] _inventory = new EPower[_inventorySize];
    private int _selected = 0;
    [SerializeField] private Power[] powers;

    private InputAction _useAction;
    private InputAction _nextAction;
    private InputAction _prevAction;
    private InputAction _slot0Action;
    private InputAction _slot1Action;
    private InputAction _slot2Action;
    [SerializeField] private Image[] _slotsImages;

    private void Awake()
    {
        _inventory = Enumerable.Repeat(EPower.NONE, _inventorySize).ToArray();
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
            if (_inventory[_selected] != EPower.NONE)
            {
                Power power = Instantiate(powers[(int)_inventory[_selected]]);
                Vector3 position = new Vector3(transform.position.x, transform.position.y, power.transform.position.z);
                power.Use(position, transform.eulerAngles.z);
                _inventory[_selected] = EPower.NONE;
                UpdateSlotGraphic();
            }
        }
        if (_nextAction.WasPressedThisFrame())
        {
            if (_selected < _inventorySize - 1)
            {
                _selected++;
            }
            else
            {
                _selected = 0;
            }
            UpdateSlotSelection();
        }
        if (_prevAction.WasPressedThisFrame())
        {
            if (_selected > 0)
            {
                _selected--;
            }
            else
            {
                _selected = _inventorySize - 1;
            }
            UpdateSlotSelection();
        }
        if (_slot0Action.WasPressedThisFrame())
        {
            _selected = 0;
            UpdateSlotSelection();
        }
        if (_slot1Action.WasPressedThisFrame())
        {
            _selected = 1;
            UpdateSlotSelection();
        }
        if (_slot2Action.WasPressedThisFrame())
        {
            _selected = 2;
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
        _slotsImages[_selected].color = new Color(1f, 1f, 1f, 1f);
        _slotsImages[_selected].GetComponentInChildren<TextMeshProUGUI>().color = new Color(0f, 0f, 0f);
    }

    private void UpdateSlotGraphic()
    {
        for (int i = 0; i < _inventorySize; i++)
        {
            _slotsImages[i].GetComponentsInChildren<Image>()[1].sprite =
                PowerPickup.GetSprites()[(int)_inventory[i]];
        }
    }

    public bool PickupPowerPickup(EPower power)
    {
        for (int i = 0; i < _inventorySize; i++)
        {
            if (_inventory[i] == EPower.NONE)
            {
                _inventory[i] = power;
                UpdateSlotGraphic();
                return true;
            }
        }
        return false;
    }
}
