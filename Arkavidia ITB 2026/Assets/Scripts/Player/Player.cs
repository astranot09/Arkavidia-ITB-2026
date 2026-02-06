using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currHealth;

    private void Start()
    {
        //transform.position = CheckPointManager.instance.GetLastCheckPoint().position;
        currHealth = maxHealth;
    }

    public void getDamage(float damage)
    {
        currHealth -= damage;
        if(currHealth == 0)
        {
            Debug.Log("Dead");

            TransitionManager.instance.StartReloadScene();
        }
    }

}
