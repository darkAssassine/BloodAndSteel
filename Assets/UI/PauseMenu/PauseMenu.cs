using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;

    void Update()
    {
        if (BasicInput.Pause)
        {
            if (canvas.activeInHierarchy)
            {
                canvas.SetActive(false);
            }
            else
            {
                if (PlayerPrefs.GetInt("isOtherScreenLoaded") == 0)
                    canvas.SetActive(true);
            }
        }
    }

    public void GiveUp()
    {
        canvas.SetActive(false);
        GameEvents.Instance.PlayerDied.Invoke();
    }
}
