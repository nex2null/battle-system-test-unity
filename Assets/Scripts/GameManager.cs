using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Singleton instance
    /// </summary>
    public static GameManager Instance = null;

    /// <summary>
    /// The overworld map root object
    /// </summary>
    GameObject _mapRoot;

    /// <summary>
    /// Handle script load
    /// </summary>
    private void Awake()
    {
        Instance = Instance ?? this;
    }

    /// <summary>
    /// Handle initialization
    /// </summary>
    private void Start()
    {
        _mapRoot = GameObject.Find("MapSceneRoot");
    }

    /// <summary>
    /// Start the battle
    /// </summary>
    public void StartBattle(EnemySpawner spawner)
    {
        StartCoroutine(BeginBattle(spawner));
    }

    /// <summary>
    /// End the current battle
    /// </summary>
    private void EndBattle()
    {
        _mapRoot.SetActive(true);
    }

    /// <summary>
    /// Start the battle
    /// </summary>
    private IEnumerator BeginBattle(EnemySpawner spawner)
    {
        // Load the scene and wait for it to continue
        var sceneLoad = SceneManager.LoadSceneAsync("BattleScene", LoadSceneMode.Additive);
        while (!sceneLoad.isDone)
            yield return null;

        // Kill the enemy
        Destroy(spawner.gameObject);

        // When the battle scene is unloaded, process it
        SceneManager.sceneUnloaded += HandleSceneUnloaded;

        // Hide the map scene
        _mapRoot.SetActive(false);

        // Grab the battle manager and initialize
        var battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        battleManager.Initialize(spawner.enemyType);
    }

    /// <summary>
    /// Handle battle scene being unloaded
    /// </summary>
    private void HandleSceneUnloaded(Scene scene)
    {
        SceneManager.sceneUnloaded -= HandleSceneUnloaded;
        EndBattle();
    }
}
