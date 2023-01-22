using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public enum ProjectileTypes {HomingProj=0, StraightLineProj};

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public PlayerController player;
    public int howManyEnemies = 0;
    public int maxEnemies;
    public int gameScore = 0;
    public TextMeshProUGUI scoreText;

    [SerializeField, Tooltip("The upper bound of the game's position")]
    public Vector2 maxPosition;

    public GameObject[] enemyTypes = new GameObject[2];

    public GameObject[] projectileTypes; 

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        if (howManyEnemies < maxEnemies)
        {
            int diff = maxEnemies - howManyEnemies;
            for(int i = 0; i < diff; i++)
            {
                int whichEnemy = Random.Range(0, 2);
                GameObject newEnemy = Instantiate(enemyTypes[whichEnemy]) as GameObject;
                newEnemy.transform.position = new Vector2(Random.Range(maxPosition.x * -1, maxPosition.x), Random.Range(maxPosition.y * 0.8f, maxPosition.y));
                howManyEnemies++;
            }
            Debug.Log(gameScore);
            scoreText.text = gameScore.ToString();
        }
        
    }


}
