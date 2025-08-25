using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyObject : MonoBehaviour
{
    // Ready ��ũ��Ʈ�� Start! �ؽ�Ʈ�� �ۼ��� �Ǹ�, Square ������Ʈ�� ������ ���� ����� �ٸ� ������ �����غ�����
    // Start�Լ��� �ڷ�ƾ���� �����Ͽ��� �����غ�����

    // �ٲٰ� ���� ������Ʈ�� ������ ����

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
