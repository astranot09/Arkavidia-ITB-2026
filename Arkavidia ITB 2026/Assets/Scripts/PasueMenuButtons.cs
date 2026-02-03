using UnityEngine;

public class PasueMenuButtons : MonoBehaviour
{
    public void OpenClosePauseMenu()
    {
        if (this.gameObject.activeInHierarchy)
        {
            this.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            this.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
