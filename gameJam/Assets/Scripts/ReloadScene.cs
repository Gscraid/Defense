using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReloadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Reload()
    {
    	SceneManager.LoadScene("MainScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
