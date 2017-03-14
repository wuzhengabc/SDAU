using UnityEngine;
using UnityEngine.SceneManagement;

public class Welcom : MonoBehaviour 
{
	void Awake () 
	{
        SceneManager.LoadScene("Loading");
	}	
}
