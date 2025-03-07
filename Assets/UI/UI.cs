using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class UI : MonoBehaviour
{
    [SerializeField]
    private GameObject firstSelected;

    [SerializeField]
    private AudioSource selectedSound;

    [SerializeField]
    private AudioSource buttonPressedSound;
    private void OnEnable()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (GameEvents.Instance != null )   
             GameEvents.Instance.Pause();
        PlayerPrefs.SetInt("isOtherScreenLoaded", 1);
        if (EventSystem.current != null)
            EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }

    private void OnDisable()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (GameEvents.Instance != null)
            GameEvents.Instance.Resume();
        PlayerPrefs.SetInt("isOtherScreenLoaded", 0);
        if (EventSystem.current != null)
            EventSystem.current.SetSelectedGameObject(null);
    }

    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void EndApplication()
    {
        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void Disable(GameObject disableGameObject)
    {
        disableGameObject.SetActive(false);
    }

    public void Enable(GameObject enableGameObject)
    {
        enableGameObject.SetActive(true);
    }

    public void SetNextSelected(GameObject selectedGameObject)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(selectedGameObject);
    }


    public void PlayButtonSelectedSound()
    {
        selectedSound.Play();
    }

    public void PlayButtonPressedSound()
    {
        buttonPressedSound.Play();
    }

}
