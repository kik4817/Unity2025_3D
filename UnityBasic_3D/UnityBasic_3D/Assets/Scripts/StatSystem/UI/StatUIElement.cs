using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatUIElement : MonoBehaviour
{
    //[SerializeField] Entity_stats playerstats; // 한개씩 넣어줘야함
    [SerializeField] TextMeshProUGUI valueText;

    public void SetUI(float value) // 한번에 여러게를 넣어줌
    {
        valueText.SetText(value.ToString());
    }
}
