using UnityEngine;

public class PaperSpoiler : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject textArea;

    public void OffFocus()
    {
        Debug.Log("Off focus");
    }

    public void OnFocus()
    {
        Debug.Log("On focus");
    }

    public void OnInteract()
    {
        textArea.SetActive(true);
    }
}
