using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _closingMenuButton;
    [SerializeField] private GameObject _menu;
    [SerializeField] private string _playerName;
    [SerializeField] private TMP_InputField _inputField;


    private void Start()
    {
        _menu.SetActive(false);
        Time.timeScale = 1f;
    }

    private void OnEnable()

    {
        _inputField.onEndEdit.AddListener(SaveName);
        _closingMenuButton.onClick.AddListener(OnClosingClick);
        _settingsButton.onClick.AddListener(OnSettingsClick);
    }


    private void OnDisable()
    {
        _closingMenuButton.onClick.RemoveListener(OnClosingClick);
        _settingsButton.onClick.RemoveListener(OnSettingsClick);
        _inputField.onEndEdit.RemoveListener(SaveName);
    }

    private void OnSettingsClick()
    {
        _menu.SetActive(!_menu.activeSelf);
        _menu.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Pause");
    }
    private void OnClosingClick()
    {
        _menu.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("Resume");
    }


    private void SaveName(string input)
    {
        _playerName = input;
        Debug.Log($"Your name: {_playerName}");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void ReastartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}