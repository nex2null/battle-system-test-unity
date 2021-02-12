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
        // Spawn a prefab for the enemy
        var prefabPath = "Prefabs/Battle/EnemyListRow";
        var enemyListRowGameObject = Resources.Load(prefabPath) as GameObject;

        // Grab the parent panel for our enemy list
        var enemyListPanel = GameObject.Find("EnemyListPanel");

        // Spawn the enemy row
        var enemyListRow = Instantiate(enemyListRowGameObject, transform.position, transform.rotation);
        enemyListRow.transform.SetParent(enemyListPanel.transform);
        enemyListRow.transform.localScale = new Vector3(1f, 1f, 1f);

        // Set the text
        enemyListRow.transform.Find("NameText").GetComponent<Text>().text = enemy.ToString();

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
