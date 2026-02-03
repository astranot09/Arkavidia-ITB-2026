using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    private GameObject pauseMenu;

    private void Awake()
    {
        pauseMenu = GameObject.Find("PausePanel").gameObject;
    }

    public void OpenClosePauseMenu(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (pauseMenu.activeInHierarchy)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}
