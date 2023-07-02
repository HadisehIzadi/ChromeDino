using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	
	[System.Serializable]
	public struct SpawnableObject
	{
		[Range(0f,1f)] public float spawnChance;
		public GameObject prefab;
	}
	
	
	public SpawnableObject[] objects;
	public float minspawnrate = 2f;
	public float maxSpawnRate = 3f;
	
	void OnEnable()
	{
		Invoke(nameof(Spawn), Random.Range(minspawnrate , maxSpawnRate));
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Spawn()
    {
    	float spawnChance = Random.value;
    	
    	foreach(var obj in objects)
    	{
    		if(spawnChance < obj.spawnChance)
    		{
    			GameObject obstacle = Instantiate(obj.prefab);
    			obstacle.transform.position += transform.position;
    			break;
    		}
    		
    		spawnChance -= obj.spawnChance;
    		
    	}
    	
    	Invoke(nameof(Spawn), Random.Range(minspawnrate , maxSpawnRate));
    }
    
    void OnDisable()
    {
    	CancelInvoke();
    }
}
