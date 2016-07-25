using UnityEngine;
using System.Collections;

public class OrderSpectrum_GUIC : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
