using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectionSystem : MonoBehaviour
{
    #region Collection Variables
    [Header("Collected Items Bools")]
    [SerializeField] private bool _hasKeycard1;
    [SerializeField] private bool _hasKeycard2;
    [SerializeField] private bool _hasWires;
    [SerializeField] private bool _hasPowerCell;
    [SerializeField] private bool _hasPower;
    [SerializeField] private bool _hasFoodSupply;
    [SerializeField] private bool _hasOxygenTank;
    
    [Header("Finding Items")]
    [SerializeField] private bool _findingKeycard1;
    [SerializeField] private bool _findingKeycard2;
    [SerializeField] private bool _findingWires;
    [SerializeField] private bool _findingPowerCell;
    [SerializeField] private bool _findingPower;
    [SerializeField] private bool _findingFoodSupply;
    [SerializeField] private bool _findingOxygenTank;

    [Header("UI Task UI Objects")]
    [SerializeField] private GameObject _needKeycard1;
    [SerializeField] private GameObject _needKeycard2;
    [SerializeField] private GameObject _needWires;
    [SerializeField] private GameObject _needPowerCell;
    [SerializeField] private GameObject _needPower;
    [SerializeField] private GameObject _needFoodSupply;
    [SerializeField] private GameObject _needOxygenTank;

    [Header("UI Found")]
    [SerializeField] private Image _keycard1;
    [SerializeField] private Image _keycard2;
    [SerializeField] private Image _wires;
    [SerializeField] private Image _powerCell;
    [SerializeField] private Image _power;
    [SerializeField] private Image _foodSupply;
    [SerializeField] private Image _oxygenTank;
    
    [Header("Collection Zones")]
    [SerializeField] Collider _keycard1CollectionZone;
    [SerializeField] Collider _keycard2CollectionZone;
    [SerializeField] Collider _wiresCollectionZone;
    [SerializeField] Collider _powerCellCollectionZone;
    [SerializeField] Collider _powerCollectionZone;
    [SerializeField] Collider _foodSupplyCollectionZone;
    [SerializeField] Collider _oxygenTankCollectionZone;

    [SerializeField] Collider _escapeTasksPopUpZone;

    [Header("Trigger Zones")]
    [SerializeField] private List<Collider> _needPowerTriggerZones;
    [SerializeField] private List<Collider> _needKey1TriggerZones;
    [SerializeField] private List<Collider> _needKey2TriggerZones;
    #endregion

    #region Task Variables

    [SerializeField] private TextMeshProUGUI _currentTaskUI;
    [Range(0f, 4f)] [SerializeField] private int _currentTaskNum;

    [Multiline] [SerializeField] private List<string> _tasks;

    #endregion

    private void Update()
    {
        //I know it's not great to have these in update but it's 1/1000000 of a real game so who cares

        _needKeycard1.SetActive(_findingKeycard1);
        _needKeycard2.SetActive(_findingKeycard2);
        _needWires.SetActive(_findingWires);
        _needPowerCell.SetActive(_findingPowerCell);
        _needPower.SetActive(_findingPower);
        _needFoodSupply.SetActive(_findingFoodSupply);
        _needOxygenTank.SetActive(_findingOxygenTank);

        _keycard1.gameObject.SetActive(_hasKeycard1);
        _keycard2.gameObject.SetActive(_hasKeycard2);
        _wires.gameObject.SetActive(_hasWires);
        _powerCell.gameObject.SetActive(_hasPowerCell);
        _power.gameObject.SetActive(_hasPower);
        _foodSupply.gameObject.SetActive(_hasFoodSupply);
        _oxygenTank.gameObject.SetActive(_hasOxygenTank);

        _currentTaskUI.text = $"CURRENT TASK:\n\n{_tasks[_currentTaskNum]}";
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collided with " + collider.name);
        if (collider == _keycard1CollectionZone)
        {
            _hasKeycard1 = true;
        }
        else if (collider == _keycard2CollectionZone)
        {
            _hasKeycard2 = true;
        }
        else if (collider == _wiresCollectionZone)
        {
            _hasWires = true;
        }
        else if (collider == _powerCellCollectionZone)
        {
            _hasPowerCell = true;
        }
        else if (collider == _powerCollectionZone)
        {
            _hasPower = true;
        }
        else if (collider == _foodSupplyCollectionZone)
        {
            _hasFoodSupply = true;
        }
        else if (collider == _oxygenTankCollectionZone)
        {
            _hasOxygenTank = true;
        }
    }

    private void NextTask()
    {
        _currentTaskNum++;
    }
}
