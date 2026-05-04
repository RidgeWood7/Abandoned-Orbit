using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectionSystem : MonoBehaviour
{
    #region Collection Variables
    [Header("Collected Items Bools")]
    public List<string> collection;
    
    [Header("Finding Items")]
    [SerializeField] private bool _isFindingKeycard1;
    [SerializeField] private bool _isFindingKeycard2;
    [SerializeField] private bool _isFindingWires;
    [SerializeField] private bool _isFindingPowerCell;
    [SerializeField] private bool _isFindingPower;
    [SerializeField] private bool _isFindingFoodSupply;
    [SerializeField] private bool _isFindingOxygenTank;

    [Header("UI Task UI Objects")]
    [SerializeField] private GameObject ui_needKeycard1;
    [SerializeField] private GameObject ui_needKeycard2;
    [SerializeField] private GameObject ui_needWires;
    [SerializeField] private GameObject ui_needPowerCell;
    [SerializeField] private GameObject ui_needPower;
    [SerializeField] private GameObject ui_needFoodSupply;
    [SerializeField] private GameObject ui_needOxygenTank;

    [Header("UI Found")]
    [SerializeField] private Image ui_keycard1;
    [SerializeField] private Image ui_keycard2;
    [SerializeField] private Image ui_wires;
    [SerializeField] private Image ui_powerCell;
    [SerializeField] private Image ui_power;
    [SerializeField] private Image ui_foodSupply;
    [SerializeField] private Image ui_oxygenTank;

    [Header("Warnings")]
    [SerializeField] private TextMeshProUGUI txt_needKey1;
    [SerializeField] private TextMeshProUGUI txt_needKey2;
    [SerializeField] private TextMeshProUGUI txt_needPwr;

    #endregion

    #region Task Variables

    [SerializeField] private TextMeshProUGUI ui_currentTask;
    [Range(0f, 4f)] [SerializeField] private int _currentTaskNum;

    [Multiline] [SerializeField] private List<string> _tasks;

    #endregion


    private void Update()
    {
        //I know it's not great to have these in update but it's 1/1000000 of a real game so who cares

        ui_needKeycard1.SetActive(_isFindingKeycard1);
        ui_needKeycard2.SetActive(_isFindingKeycard2);
        ui_needWires.SetActive(_isFindingWires);
        ui_needPowerCell.SetActive(_isFindingPowerCell);
        ui_needPower.SetActive(_isFindingPower);
        ui_needFoodSupply.SetActive(_isFindingFoodSupply);
        ui_needOxygenTank.SetActive(_isFindingOxygenTank);

        ui_keycard1.gameObject.SetActive(collection.Contains("Keycard1"));
        ui_keycard2.gameObject.SetActive(collection.Contains("Keycard2"));
        ui_wires.gameObject.SetActive(collection.Contains("Wires"));
        ui_powerCell.gameObject.SetActive(collection.Contains("PowerCell"));
        ui_power.gameObject.SetActive(collection.Contains("Power"));
        ui_foodSupply.gameObject.SetActive(collection.Contains("FoodSupply"));
        ui_oxygenTank.gameObject.SetActive(collection.Contains("OxygenTank"));

        ui_currentTask.text = $"CURRENT TASK:\n\n{_tasks[_currentTaskNum]}";


        if (collection.Contains("Keycard1") && _currentTaskNum == 0)
        {
            _currentTaskNum++;
            ui_keycard1.enabled = true;
        }
        if (collection.Contains("EscapeVisited") && _currentTaskNum == 1)
        {
            _currentTaskNum++;
            ui_needPowerCell.SetActive(true);
            ui_needWires.SetActive(true);
            ui_needFoodSupply.SetActive(true);
            ui_needOxygenTank.SetActive(true);
            ui_needPower.SetActive(true);
            ui_needKeycard2.SetActive(true);
        }
        if (collection.Contains("Wrires") && collection.Contains("Keycard2") && collection.Contains("FoodSupply") && collection.Contains("OxygenTank") && collection.Contains("Power") && collection.Contains("PowerCell") && _currentTaskNum == 2)
        {
            _currentTaskNum++;
            ui_keycard2.enabled = true;
        }

        //finish the game
        if (collection.Contains("Wrires") && collection.Contains("Escaped") && collection.Contains("Keycard2") && collection.Contains("FoodSupply") && collection.Contains("OxygenTank") && collection.Contains("Power") && collection.Contains("PowerCell") && _currentTaskNum == 3)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}