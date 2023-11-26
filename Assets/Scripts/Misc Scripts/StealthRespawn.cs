using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StealthRespawn : MonoBehaviour
{

	public bool isHidden = false;
	private GameObject respawn1;
	private GameObject respawn2; 

	void Start()
	{
		//If your player starts in cover, change this to true. Shouldn't be too big of an issue though.
		isHidden = false;
		if (SceneManager.GetActiveScene().buildIndex == 4) {
			isHidden = true;
		}
		respawn1 = GameObject.FindGameObjectWithTag("Respawn1");
		respawn2 = GameObject.FindGameObjectWithTag("Respawn2");
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Cover"))
		{
			isHidden = true;
			// Debug.Log("Started hiding");
		}
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		// I couldn't think of a better tag name than GuardView. Feel free to change it if you come up with a better name
		if (collision.CompareTag("GuardView1") || collision.CompareTag("Tentacles"))
		{
			if (!isHidden)
			{
				// transform.position = respawn1.transform.position;
				// // debug.log(transform.position.z);
				transform.position = new Vector3(respawn1.transform.position.x, respawn1.transform.position.y, 0);
				// // debug.log(transform.position.z);
				// // debug.log("----");
			}
		}
		if (collision.CompareTag("GuardView2") || collision.CompareTag("Tentacles"))
		{
			if (!isHidden)
			{
				// transform.position = respawn2.transform.position;
				// // debug.log(transform.position.z);
				transform.position = new Vector3(respawn2.transform.position.x, respawn2.transform.position.y, 0);
				// // debug.log(transform.position.z);
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Cover"))
		{
			if (SceneManager.GetActiveScene().buildIndex != 4 || transform.position.y > -4.4) {
				isHidden = false;
				// Debug.Log("NO LONGER HIDDEN");
			}
			else {
				// Debug.Log("Still hidden. " + transform.position.y);
			}
			// Debug.Log("NO LONGER HIDDEN");
		}
	}
}
