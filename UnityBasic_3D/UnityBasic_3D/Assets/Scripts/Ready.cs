using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ready : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI readyText;
    //[SerializeField] 스크립트를 직업 넣음

    [SerializeField] int startSecond = 5;
    [SerializeField] float intervalTime = 1f;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        for(int i=0; i< startSecond; i++)
        {
            readyText.SetText((startSecond-i).ToString());
            yield return new WaitForSeconds(intervalTime);
        }
                
        readyText.SetText("Start!");        
        yield return new WaitForSeconds(intervalTime);
        readyText.gameObject.SetActive(false);    
        yield return new WaitForSeconds(intervalTime);
        
        //readyText.text = "5";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
