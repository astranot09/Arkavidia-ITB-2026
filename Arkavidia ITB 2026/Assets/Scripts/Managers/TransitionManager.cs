using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager instance;
    [SerializeField] private Animator animator;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ReloadScene()
    {
        animator.SetTrigger("In");
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        animator.SetTrigger("Out");
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        animator.SetTrigger("In");
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(sceneIndex);
        animator.SetTrigger("Out");
    }

    public void StartReloadScene()
    {
        StartCoroutine(ReloadScene());
    }

    public void StartLoadScene(int sceneIndex)
    {
        StartCoroutine(LoadScene(sceneIndex));
    }
}
