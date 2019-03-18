using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    public Animator animator;
    public static int sceneToLoad;
    public static bool change = false;

    private void Start()
    {
        sceneToLoad = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update () {
        if (change)
        {
            FadeToLevel(sceneToLoad);
        }
        change = false;
	}

    public void FadeToLevel (int levelIndex)
    {
        sceneToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void onFadeComplete()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
