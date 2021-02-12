using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyEnum enemyType;

    /// <summary>
    /// Handle the Collider2D being triggered
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the player collides with the slime, enter the battle
        if (other.gameObject.tag == "Player")
            GameManager.Instance.StartBattle(this);
    }
}