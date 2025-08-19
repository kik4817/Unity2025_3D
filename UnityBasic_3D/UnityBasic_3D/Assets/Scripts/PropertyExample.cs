using System.Collections;
using System.Collections.Generic;

public class PropertyExample
{
    // ��� ����, ��� �Լ�

    private int hp;
    //private int atk;

    // ������Ƽ ��� ���� (1)
    public int HP {  get; set; }
    
    // ������Ƽ ��� ���� (2)
    public int HP2 { 
        get { return hp; } 
        set { hp = value; } }
    public int ATK { get; set; }

    // ������Ƽ ��� ���� (3)
    public int DEF { get; set; } // priavet set �ܺο��� ���� �������� ������.

    public int MaxLevel { get; private set; } // ���� ������ �� �ִ� ������ ����. �ٸ� Ŭ�������� ������ �� ������ �����Ѵ�.


    //public int GetHP() 
    //{
    //    if (hp <= 0)
    //    {
    //        hp = 0;
    //        // �÷��̾ ����߽��ϴ�.
    //    }
    //    return hp; 
    //}
    //public void SetHP(int _hp) { hp = _hp; }
    //public int GetATK() { return atk; }
    //public void SetATK(int _atk) { atk = _atk; }

    /*
     * ������Ƽ(Property)
     * ���� : ���� ���� public (Ÿ��)(���� �̸�) ù���ڸ� �빮�ڷ� �ۼ��ϴ� ���� �̸� ��Ģ�Դϴ�.
     * public int HP {get;set;}
     * 
     */ 


    /// <summary>
    /// hp�� �������� �������ִ� �ڵ��Դϴ�. �ݵ�� �� �Լ��� �̿��ؼ� HP�� �������ּ���.
    /// </summary>
    public void UseThisFunction()
    {
        // hp�� � �ý��ۿ� ���ؼ� ����˴ϴ�.
        hp /= 2;
    }

}
