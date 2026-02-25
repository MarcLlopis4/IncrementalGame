using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CapFPS();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void CapFPS()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 144;
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenPanel(GameObject PanelToOpen)
    {
        PanelToOpen.SetActive(true);
    }

    public void ClosePanel(GameObject PanelToClose)
    {
        PanelToClose.SetActive(false);
    }



}
