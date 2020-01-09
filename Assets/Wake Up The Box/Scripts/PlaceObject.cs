using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour {

    private Vector3 mousepos;
    public GameObject[] tools;
    private List<GameObject> toolList = new List<GameObject>();
    
    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < tools.Length; i++)
            toolList.Add(tools[i]);


    }

    // Attaches object to mouse
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("UnplacedBox").Length == 0 && toolList.Count > 0 )
        {
            GameObject newObject = Instantiate(toolList[0], Input.mousePosition, Quaternion.identity);
            toolList.RemoveAt(0);
        }

        var objectToMove = GameObject.FindGameObjectWithTag("UnplacedBox");
        if (objectToMove == null) return;
        mousepos = Input.mousePosition;
        mousepos = Camera.main.ScreenToWorldPoint(mousepos);
        mousepos.z = 0;
        objectToMove.transform.position = mousepos;

    }
}
