using UnityEngine;

public class PaperSpoiler : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject textArea;
    [SerializeField] private GameObject notification;

    public void OffFocus()
    {
        notification.SetActive(false);
        textArea.SetActive(false);
    }

    public void OnFocus()
    {
        notification.SetActive(true);
    }

    public void OnInteract()
    {
        textArea.SetActive(true);
    }
}
