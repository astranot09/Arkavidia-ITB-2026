using UnityEngine;

public class FinishScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            TransitionManager.instance.StartLoadScene(1);
    }
}
