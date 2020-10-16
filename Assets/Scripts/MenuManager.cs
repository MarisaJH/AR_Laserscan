using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	public Text ipDisplay;
	public Text numLasersDisplay;
	public Text angleDisplay;
	private string ipkey = "IP";
	private string laserskey = "Lasers";
	private string anglekey = "Angle";
	private int defaultLasers = 13;
	private float defaultAngle = 180.0f;
    
	// Start is called before the first frame update
    void Start()
    {
        ipDisplay.text = PlayerPrefs.GetString(ipkey, "None");
		numLasersDisplay.text = (PlayerPrefs.GetInt(laserskey, defaultLasers)).ToString();
		angleDisplay.text = (PlayerPrefs.GetFloat(anglekey, defaultAngle)).ToString();
    }
	
	public void SetIP(string newip) {
		ipDisplay.text = newip;
		PlayerPrefs.SetString(ipkey, newip);
	}
	
	public void SetLaserNum(string newNum) {
		numLasersDisplay.text = newNum;
		PlayerPrefs.SetInt(laserskey, int.Parse(newNum));
	}
	
	public void SetAngle(string newAngle) {
		angleDisplay.text = newAngle;
		PlayerPrefs.SetFloat(anglekey, float.Parse(newAngle));
	}
	
	public void ChangeScene() {
		SceneManager.LoadScene(1);
	}
}
