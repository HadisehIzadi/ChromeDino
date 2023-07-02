using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	CharacterController character;
	Vector3 direction;
	
	public float gravity = 9.81f;
	public float jumpForce = 8f;
	
	void Awake()
	{
		character = GetComponent<CharacterController>();
	}
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	direction += Vector3.down * gravity * Time.deltaTime;
    	
    	if(character.isGrounded){
    		
    		direction = Vector3.down;
    		if(Input.GetButtonDown("Jump"))
    		{
    			direction = Vector3.up * jumpForce;
    			
    		}
    		
    	
    	}
    	character.Move(direction * Time.deltaTime);
    		
    }
    
    
    void OnEnable()
    {
    	direction = Vector3.zero;
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
    
}
