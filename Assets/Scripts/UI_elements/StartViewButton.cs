using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartViewButton : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject gamePanel;

    public void SetPanelView()
    {
        panel.SetActive(false);
        gamePanel.SetActive(true);
    }
}
