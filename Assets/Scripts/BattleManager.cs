using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    /// <summary>
    /// Keep track of whether we have been initialized
    /// </summary>
    private bool isInitialized;

    /// <summary>
    /// Initialize the battle
    /// </summary>
    public void Initialize(EnemyEnum enemy)
    {
        var text = GameObject.Find("EnemyNameText").GetComponent<Text>();
        text.text = enemy.ToString();

        isInitialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Make sure we have been initialized
        if (!isInitialized)
            return;

        // Handle battle exit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.UnloadSceneAsync("BattleScene");
        }
    }
}
