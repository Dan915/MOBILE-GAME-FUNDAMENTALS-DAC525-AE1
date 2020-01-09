using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtachObject : MonoBehaviour {

    private bool colliding = false;
    private GameObject attachingGameObject;
    public Rigidbody2D rbMass;
	// Use this for initialization
	void Start () {
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag.Contains("Attach"))
        {
            colliding = true;
            attachingGameObject = col.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        colliding = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (colliding && Input.GetMouseButtonUp(0) && attachingGameObject != null)
        {
            transform.GetComponent<BoxCollider2D>().isTrigger = false;
            transform.SetParent(attachingGameObject.transform, true);            
            var joint = attachingGameObject.AddComponent<FixedJoint2D>();
            gameObject.AddComponent<Rigidbody2D>();
            rbMass = gameObject.GetComponent<Rigidbody2D>();
            rbMass.mass = 1.5f;
            joint.connectedBody = transform.GetComponent<Rigidbody2D>();
            transform.tag = "Attach";
            // set parent
            //  add new cmponent then set fixed joint

        }
            
    }
}
