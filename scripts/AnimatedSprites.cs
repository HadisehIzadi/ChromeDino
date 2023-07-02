using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSprites : MonoBehaviour
{
	public Sprite[] sprites;
	SpriteRenderer spriteRendere;
	int frame = 0 ;
	
	
	void Awake()
	{
		spriteRendere = GetComponent<SpriteRenderer>();
	}
	
	void OnEnable()
	{
		Invoke(nameof(Animate), 0f);
	}
	
	void OnDisable()
	{
		CancelInvoke();
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    void Animate()
    {
    	frame++;
    	if(frame > sprites.Length)
    	{
    		frame = 0 ;
    	}
    	
    	if(frame >= 0 && frame < sprites.Length)
    	{
    		spriteRendere.sprite = sprites[frame];
    	}
    	Invoke(nameof(Animate), 1f / GameManager.Instance.gameSpeed);

    }
        
    

}
