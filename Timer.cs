using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using TMPro;
public class Timer : MonoBehaviour
{
    public int minutesNum;
    public float secondsNum;
    public bool gamefinished = false;
    public TextMeshProUGUI TextTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gamefinished==false) {
            if (secondsNum<0) {
                minutesNum = minutesNum-1;
                if(minutesNum<0) {
                    EditorSceneManager.LoadScene("Level_1");
                }
                secondsNum = 59f;

            }
            else{
                secondsNum = secondsNum-0.01f;
            }
            TextTimer.text = "0"+minutesNum+":"+Mathf.Round(secondsNum * 10.0f) * 0.1f;
            }
    }
}
