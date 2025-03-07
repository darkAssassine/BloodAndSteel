using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviourSingleton<LevelManager>
{
    public int CurrentLevel { get ; private set; }

    [SerializeField]
    private int minLevel;

    [SerializeField]
    private int maxLevel;
    
    private void Start()
    {
        CurrentLevel = 1;
        GameEvents.Instance.LevelCleared += LoadNextScene;
    }

    public void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextLevel= Random.Range(minLevel, maxLevel+1);
        //if (currentScene == nextLevel)
        //{
        //    LoadNextScene();
        //}
        //else
        {
            SceneManager.LoadScene(nextLevel);
            PlayerPrefs.SetInt("LevelsCleared", PlayerPrefs.GetInt("LevelsCleared") + 1);
        }
    }
}
