using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneMoreButton : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Cube cube;

    public void SetPanelView()
    {
        panel.SetActive(false);
        cube.RestartCube();
    }
}
