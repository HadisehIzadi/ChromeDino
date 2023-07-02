using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
	MeshRenderer meshRedndere;
	
	void Awake()
	{
		meshRedndere = GetComponent<MeshRenderer>();
	}
	
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	float speed = GameManager.Instance.gameSpeed / transform.localScale.x;
    	
    	meshRedndere.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
    }
}
