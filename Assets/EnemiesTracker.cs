using System.Collections.Generic;
using UnityEngine;

public class EnemiesTracker : MonoBehaviour
{
    // list of enemies
    List<Enemy> enemies = new List<Enemy>();
    public List<Enemy> Enemies => enemies;
    public int EnemyCount => enemies.Count;

    void Start()
    {
        Enemy.OnEnemySpawned += OnEnemySpawned;
        Enemy.OnEnemyDestroyed += OnEnemyDestroyed;
    }

    void OnEnemySpawned(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    void OnEnemyDestroyed(Enemy enemy)
    {
        enemies.Remove(enemy);
    }
}
