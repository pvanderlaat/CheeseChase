using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthRespawn : MonoBehaviour
{

	public bool isHidden = false;
	private GameObject respawn1;
	private GameObject respawn2; 

	void Start()
	{
		//If your player starts in cover, change this to true. Shouldn't be too big of an issue though.
		isHidden = false;
		respawn1 = GameObject.FindGameObjectWithTag("Respawn1");
		respawn2 = GameObject.FindGameObjectWithTag("Respawn2");
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Cover"))
		{
			isHidden = true;
		}
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		// I couldn't think of a better tag name than GuardView. Feel free to change it if you come up with a better name
		if (collision.CompareTag("GuardView1"))
		{
			if (!isHidden)
			{
				// transform.position = respawn1.transform.position;
				Debug.Log(transform.position.z);
				transform.position = new Vector3(respawn1.transform.position.x, respawn1.transform.position.y, 0);
				Debug.Log(transform.position.z);
				Debug.Log("----");
			}
		}
		if (collision.CompareTag("GuardView2"))
		{
			if (!isHidden)
			{
				// transform.position = respawn2.transform.position;
				Debug.Log(transform.position.z);
				transform.position = new Vector3(respawn2.transform.position.x, respawn2.transform.position.y, 0);
				Debug.Log(transform.position.z);
				Debug.Log("----");
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Cover"))
		{
			isHidden = false;
		}
	}
}
