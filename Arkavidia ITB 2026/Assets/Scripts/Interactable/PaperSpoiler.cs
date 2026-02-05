using TMPro;
using UnityEngine;

public class PaperSpoiler : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject textArea;
    [SerializeField] private GameObject notification;
    [SerializeField] private TMP_Text textPlaceholder;
    [SerializeField, TextArea(3, 10)] private string text;

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

    public void OnInteractConfirm()
    {
        textArea.SetActive(true);
        Debug.Log("paper confirm");
        textPlaceholder.text = text;
        PaperEffect();
    }

    protected virtual void PaperEffect()
    {
        
    }
}
