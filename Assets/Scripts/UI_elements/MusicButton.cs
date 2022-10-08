using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MusicButton : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private GameObject musicSlider;
    [SerializeField] private GameObject musicPanel;

    private bool isActive = false;
    private void Awake()
    {
        musicSource.volume = SaveLoadManager.Load();
        musicSlider.GetComponent<Slider>().value = SaveLoadManager.Load();
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        SaveLoadManager.Save(volume);
    }

    public void SetPanelView()
    {
        isActive = !isActive;
        musicPanel.SetActive(isActive);
    }
}
