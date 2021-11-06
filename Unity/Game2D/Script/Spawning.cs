using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public Enemies[] enemies;
    public Transform[] edge_position;
    public Items[] items;

    private float next_spawn_eagle = 0.0f;
    private float next_spawn_opossum = 0.0f;
    private float next_spawn_frog = 0.0f;
    private float next_spawn_gem = 0.0f;
    private float next_spawn_cherry = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        SpawningEagle();

        SpawningOpossum();

        SpawningFrog();

        SpawningGem();

        SpawningCherry();
    }

    private void SpawningEagle()
    {
        Enemies e = Array.Find(enemies, enemy => enemy.name == "Eagle");
        
        if (Time.time > next_spawn_eagle)
        {
            float randX = UnityEngine.Random.Range(-21, 21);
    
            next_spawn_eagle = Time.time + e.spawn_rate;
            
            Vector2 spawning_position = new Vector2(randX, 10f);
    
            Instantiate(e.enemies_position , spawning_position, Quaternion.identity);
        }
    }

    private void SpawningOpossum()
    {
        Enemies e = Array.Find(enemies, enemy => enemy.name == "Opossum");
        
        if (Time.time > next_spawn_opossum)
        {
            int randX = UnityEngine.Random.Range(0, edge_position.Length);
            
            next_spawn_opossum = Time.time + e.spawn_rate;
            
            Instantiate(e.enemies_position, edge_position[randX].position, Quaternion.identity);
        }
    }

    private void SpawningFrog()
    {
        Enemies e = Array.Find(enemies, enemy => enemy.name == "Frog");

        if (Time.time > next_spawn_frog)
        {
            float randX = UnityEngine.Random.Range(-12, 12.7f);

            next_spawn_frog = Time.time + e.spawn_rate;
            
            Vector2 frog_position = new Vector2(randX, -3);

            Instantiate(e.enemies_position, frog_position, Quaternion.identity);
        }
    
    
    }

    private void SpawningGem()
    {
        Items it = Array.Find(items, item => item.name == "Gem");

        if (Time.time > next_spawn_gem)
        {
            float randX = UnityEngine.Random.Range(-12, 12.7f);

            next_spawn_gem = Time.time + it.spawn_rate;

            Vector2 gem_position = new Vector2(randX, 5f);

            Instantiate(it.item_game_object, gem_position, Quaternion.identity);
        }
    }

    private void SpawningCherry()
    {
        Items it = Array.Find(items, item => item.name == "Cherry");

        if (Time.time > next_spawn_cherry)
        {
            float randX = UnityEngine.Random.Range(-12, 12.7f);

            next_spawn_cherry = Time.time + it.spawn_rate;

            Vector2 cherry_position = new Vector2(randX, 5f);

            Instantiate(it.item_game_object, cherry_position, Quaternion.identity);
        }
    }
     
}