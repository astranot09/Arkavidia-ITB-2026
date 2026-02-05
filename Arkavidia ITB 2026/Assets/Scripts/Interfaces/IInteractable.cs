using UnityEngine;

public interface IInteractable
{
    void OnInteract();
    void OnInteractConfirm();
    void OnFocus();
    void OffFocus();
}
