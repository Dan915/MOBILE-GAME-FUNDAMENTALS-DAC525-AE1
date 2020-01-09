using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovementScript: MonoBehaviour {

   public float Speed;
    public float jumpStrength;
    public float rayLength;
	int hurtCount;
	public GameObject LoseScreen;

    private Rigidbody2D heroRigid;
    private Animator heroAnim;
	// Use this for initialization
	void Start () 
	{
		heroRigid = gameObject.GetComponent<Rigidbody2D>();
		heroAnim = gameObject.GetComponent<Animator>();		
	}
	
	// Update is called once per frame
	void Update () 
	{
		heroRigid.velocity = new Vector2(
            Input.GetAxisRaw("Horizontal") * Speed, 
            heroRigid.velocity.y);

        heroAnim.SetFloat("Movement", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

		        if(Input.GetButtonDown("Jump"))
        {
            if(Physics2D.Linecast(transform.position,
                transform.position + new Vector3(0,rayLength,0),
                1 << LayerMask.NameToLayer("Ground")))
            {
                heroRigid.AddForce(new Vector2(0, jumpStrength));
                AudioManager.TheAudioManager.PlaySFX("Jump");
			    heroAnim.SetBool("Jump", true);
		    }			
        }
			if (Input.GetButtonUp("Jump"))
			{
				heroAnim.SetBool("Jump", false);
				heroAnim.SetBool("isFalling", true);
			} 

			if(Physics2D.Linecast(transform.position,
                transform.position + new Vector3(0,rayLength,0),
                1 << LayerMask.NameToLayer("Ground")))
				{
					heroAnim.SetBool("isFalling", false);
				}
				else heroAnim.SetBool("isFalling", true);
		if (Input.GetButtonDown("Fire1"))
		{
			heroAnim.SetTrigger("Attack");
			AudioManager.TheAudioManager.PlaySFX("Attack");
		}
		if (Input.GetKeyDown(KeyCode.Z))
		{
			heroAnim.SetTrigger("Damage");
			gameObject.GetComponent<HeroMovementScript>().enabled = false;
			StartCoroutine(TempDisable());
			hurtCount++;
		}
		if (hurtCount == 3)
		{
		heroAnim.SetBool("isDying", true);
		LoseScreen.SetActive(true);
		gameObject.GetComponent<HeroMovementScript>().enabled = false;
		}
		FlipMovement();

	}
		public void Footstep()
    {
        if (Physics2D.Linecast(transform.position,
                transform.position + new Vector3(0, rayLength, 0),
                1 << LayerMask.NameToLayer("Ground")))
        {
			Debug.Log("play sound");
            AudioManager.TheAudioManager.PlaySFX("Footsteps");
        }
    }

	IEnumerator TempDisable()
	{
		yield return new WaitForSeconds(0.5f);
		gameObject.GetComponent<HeroMovementScript>().enabled = true;
	}

	 private void FlipMovement()
    {
       if(heroRigid.velocity.x > 0 && transform.localScale.x < 0 ||
            heroRigid.velocity.x < 0 && transform.localScale.x > 0)
        {
            Flip();
        }
    }

	private void Flip()
    {
        Vector2 VEC = transform.localScale;
        VEC.x *= -1;
        transform.localScale = VEC;
    }
}
