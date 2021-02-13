using UnityEngine;

public class BattleCharacter
{
    public string Name { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int MaxHp { get; set; }
    public int CurrentHp { get; set; }
    public int MaxMp { get; set; }
    public int CurrentMp { get; set; }
    public bool IsEnemy { get; set; }
}
