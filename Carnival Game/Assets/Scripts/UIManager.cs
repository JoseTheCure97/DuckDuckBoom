using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region duckCounter
    private int ducksTotal;
    private int ducksGoal = 11;
    [SerializeField] private TMP_Text ducksText;
    [SerializeField] private GameObject panelDucks;
    #endregion

    #region wonAndGameOver
    [SerializeField] private GameObject wonUI;
    [SerializeField] private GameObject defeatUI;
    private PlayerMotor playerMotor;
    #endregion

    #region healthBar
    [SerializeField] private HealthBar healthBar;
    #endregion

    private void Awake()
    {
        wonUI.SetActive(false);
        defeatUI.SetActive(false);
        panelDucks.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        Ammo.duckSum += DucksSum;
    }

    private void ShowWonLevelMessage()
    {
        Time.timeScale = 0f;
        wonUI.SetActive(true);
    }

    public void ShowLostLevelMessage()
    {
        Time.timeScale = 0f;
        defeatUI.SetActive(true);
    }

    public void ShowDuckCounter()
    {
        panelDucks.SetActive(true);
    }

    private void DucksSum()
    {
        ducksTotal += 1;
        ducksText.text = ducksTotal.ToString();
        if (ducksTotal == ducksGoal)
        {
            ShowWonLevelMessage();
        }
    }

    public void SetMaxHealth(int maxHealth)
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    public void DamagedHealthBar(int damage)
    {
        healthBar.SetHealth(damage);
    }
}
