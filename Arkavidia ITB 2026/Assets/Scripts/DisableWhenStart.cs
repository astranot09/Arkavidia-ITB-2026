using UnityEngine;

public class DisableWhenStart : MonoBehaviour
{
    void Start()
    {
        this.gameObject.SetActive(false);
    }

}
