using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public float gameSpeed {get; private set;}
	public float initialGameSpeed = 5f;
	public float gameSpeedIncrease = 0.1f;
	
	public static GameManager Instance{get; private set;}
	
	public GameObject panel;
	
	
	Player player;
	Spawner spawner;
	
	void Awake()
	{
		if(Instance == null)
			Instance = this;
		else
			DestroyImmediate(gameObject);
	}
    // Start is called before the first frame update
    void Start()
    {
    	NewGame();
    	player = FindObjectOfType<Player>();
    	spawner = FindObjectOfType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
    	gameSpeed += gameSpeedIncrease * Time.deltaTime;
    }
    
    
    void OnDestroy()
    {
    	if(Instance == this)
    		Instance = null;
    }
    
    
    public void GameOver()
    {
    	panel.gameObject.SetActive(true);
    	gameSpeed = 0f;
    	enabled = false;
    	player.gameObject.SetActive(false);
    	spawner.gameObject.SetActive(false);
    	
    }
    
    
    void NewGame()
    {
    	Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        foreach (var obstacle in obstacles) {
            Destroy(obstacle.gameObject);
        }
    	        
    	gameSpeed = initialGameSpeed;
    	enabled = true;
    	player.gameObject.SetActive(true);
    	spawner.gameObject.SetActive(true);

    }
}
