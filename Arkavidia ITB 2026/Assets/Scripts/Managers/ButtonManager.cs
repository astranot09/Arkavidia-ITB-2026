using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject settings;
    public GameObject mainMenu;

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void LoadScene(int index)
    {
        TransitionManager.instance.StartLoadScene(index);
    }

    public void Settings()
    {
        settings.SetActive(!settings.activeInHierarchy);
        mainMenu.SetActive(!mainMenu.activeInHierarchy);
    }

    public void RegisterMenu(GameObject menu)
    {
        mainMenu = menu;
    }

    public void RegisterSetting(GameObject setting)
    {
        settings = setting;
    }
}
