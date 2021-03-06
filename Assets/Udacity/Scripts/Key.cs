using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
    //Create a reference to the KeyPoofPrefab and Door
	public GameObject KeyPoof;
	public GameObject door;
    public GameObject gameManager;
	//void Update()

		//Not required, but for fun why not try adding a Key Floating Animation here :)


	public void OnKeyClicked()
	{
        // Instatiate the KeyPoof Prefab where this key is located
		Instantiate(KeyPoof, transform.position,Quaternion.Euler(-90,0,0));
        gameManager.GetComponent<GameManager>().hasKey = true;
        Destroy(gameObject);

    }
    // Make sure the poof animates vertically

    //door.GetComponent<Door> ().Unlock ();
    // Call the Unlock() method on the Door
    //void OnKeyClicked(Collider collider){
    //if(collider.gameObject.name=="player"){
    //GameVariables.keyCount+=2;

    // Set the Key Collected Variable to true
    // Destroy the key. Check the Unity documentation on how to use Destroy
    //Destroy(gameObject);
    public bool inTrigger;

    void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

    void Update()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                DoorScript.doorKey = true;
                Destroy(this.gameObject);
            }
        }
    }

    void OnGUI()
    {
        if (inTrigger)
        {
            GUI.Box(new Rect(0, 60, 200, 25), "Press E to take key");
        }
    }
}
