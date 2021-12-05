using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
	public int score = 0;
	public static Score inst;
	public TextMeshProUGUI text;
	public void Awake(){
		inst = this;
	}
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        text.text = score.ToString();
    }
}
