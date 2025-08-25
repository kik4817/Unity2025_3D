using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyObject : MonoBehaviour
{
    // Ready 스크립트가 Start! 텍스트가 작성이 되면, Square 오브젝트의 샐깔을 기존 색깔과 다른 색으로 변경해보세요
    // Start함수를 코루틴으로 변경하여서 구현해보세요

    // 바꾸고 싶은 오브젝트를 변수로 선언

    [SerializeField] SpriteRenderer sr;
    [SerializeField] float intervalTime = 1f;
    [SerializeField] GameObject gameObject1; 
    [SerializeField] GameObject gameObject2; 
    [SerializeField] GameObject gameObject3; 


    // Start is called before the first frame update
    IEnumerator Start()
    {
       yield return new WaitForSeconds(intervalTime);
       sr.color = Color.white;
    }

}
