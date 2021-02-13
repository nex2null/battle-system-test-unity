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
        // Lets just create a basic character
        var battleCharacter = new BattleCharacter
        {
            Name = "Brian",
            MaxHp = 100,
            CurrentHp = 100,
            MaxMp = 20,
            CurrentMp = 20,
            Attack = 10,
            Defense = 5
        };
        
        // Spawn the character's row
        SpawnCharacterRow(battleCharacter);

        // Spawn the enemy
        SpawnEnemy(enemy);

        isInitialized = true;
    }

    /// <summary>
    /// Spawn a character row
    /// </summary>
    void SpawnCharacterRow(BattleCharacter battleCharacter)
    {
        // Spawn a prefab for the character row
        var characterRowPrefabPath = "Prefabs/Battle/CharacterListRow";
        var characterRowGameObject = Resources.Load<GameObject>(characterRowPrefabPath);

        // Grab the parent panel for our character list
        var characterListPanel = GameObject.Find("CharacterListPanel");

        // Spawn the character row
        var characterListRow = Instantiate(characterRowGameObject, characterListPanel.transform);

        // Set the character text
        characterListRow.transform.Find("NameText").GetComponent<Text>().text = battleCharacter.Name;
    }

    /// <summary>
    /// Spawns an enemy sprite
    /// </summary>
    void SpawnEnemy(EnemyEnum enemy)
    {
        // Load enemy assets
        var enemySpriteImagePath = enemy == EnemyEnum.Bat ? "Art/Sprites/Enemies/Bat" : "Art/Sprites/Enemies/Slime";
        var enemyCharacterPrefabPath = "Prefabs/Battle/EnemyCharacter";
        var enemySprite = Resources.Load<Sprite>(enemySpriteImagePath);
        var enemyCharacterGameObject = Resources.Load<GameObject>(enemyCharacterPrefabPath);

        // Grab the container for the battle character
        var battleCharacterContainer = GameObject.Find("BattleCharacters");

        // Spawn the enemy character
        var enemyCharacter = Instantiate(enemyCharacterGameObject, battleCharacterContainer.transform);
        enemyCharacter.GetComponent<Image>().sprite = enemySprite;

        // Move the enemy character a hair to the right
        enemyCharacter.transform.localPosition = new Vector3(enemyCharacter.transform.localPosition.x + 20f, enemyCharacter.transform.localPosition.y);
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
