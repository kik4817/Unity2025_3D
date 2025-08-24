using BattleExample;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BattleEntity
{
    public int HP;    
    public int SP;   
    public int ATK;
    public int DEF;   
    public int COIN;   
    public string AttackType;

    public BattleEntity() { }
    public BattleEntity(int hP, int aTK)
    {
        HP = hP;
        ATK = aTK;
    }

    public BattleEntity(int hP, int sP, int aTK, int dEF, int cOIN)
    {
        HP = hP;
        SP = sP;
        ATK = aTK;
        DEF = dEF;
        COIN = cOIN;
    }
}

[System.Serializable]
public class BattleUI
{
    public Image HPBar;
    public Image SPBar;
    public TextMeshProUGUI BattleEntityHPText;
    public TextMeshProUGUI BattleEntitySPText;
    public TextMeshProUGUI BattleEntityATKText;
    public TextMeshProUGUI BattleEntityDEFText;
    public TextMeshProUGUI BattleEntityCoinText;
        
    public void SetBattleUI(BattleEntity battleEntity)
    {
        BattleEntityHPText.SetText($"HP : {battleEntity.HP}");
        BattleEntitySPText.SetText($"SP : {battleEntity.SP}");
        BattleEntityATKText.SetText($"ATK : {battleEntity.ATK}");
        BattleEntityDEFText.SetText($"DEF : {battleEntity.DEF}");   
        BattleEntityCoinText.SetText($"COIN : {battleEntity.COIN}");   
    }

    public void SetHPBar(int current, int max)
    {
        HPBar.fillAmount = (float)current / max;
        BattleEntityHPText.SetText($"HP : {current}");
    }
    
    public void SetSPBar(int current, int max)
    {
        SPBar.fillAmount = (float)current / max;
        BattleEntitySPText.SetText($"SP : {current}");
    }
}

// abstract class : �߻� Ŭ����
// �� Ŭ������ �ν��Ͻ� �� �� ����
// �� Ŭ������ ������Ʈ�� ������Ʈ�� ������� ������
// Player, Monster�� ����ؼ� �� Ŭ������ �����϶�.
// �޼ҵ忡 abstract Ű���带 �߰��� �� �ִ�.

/*
 * abstract vs virtual
 * 
 * abstract �߻� �Լ� : �й��� ���� �� ����. - �ڽ� Ŭ�������� ������ �����Ѵ�.
 * 
 * virtual ���� �Լ� : ������ ���� �� �ֽ��ϴ�. �ڽ� Ŭ�������� �� �ڵ带 ����� ���� ���� �ְ�, baseŰ���带 ����ؼ� ����� �� �ִ�.
 */

[System.Serializable]
public struct BattleResource
{
    public int HP;
    public int SP;

    public BattleResource(int hP, int sP)
    {
        HP = hP;
        SP = sP;
    }
}

public abstract class Battle : MonoBehaviour
{
    
    public BattleEntity battleEntity;
    public BattleUI battleUI;
    //public int playerHP;
    //public int playerATK;
    //public int playerDEF;
    public BattleManager battleManager;

    public int CurrentHP
    {
        get
        {
            if (currentHP <= 0)
            {
                // �ǰ� ���� ȿ����, ����Ʈ, �ִϸ��̼� ... �̺�Ʈ ����
                currentHP = 0;              
            }          
            else { }
            // ��� ���� ȿ����, ����Ʈ, �ִϸ��̼� ... �̺�Ʈ ����
            return currentHP;
        }

        private set 
        { 
            if(value > battleEntity.HP) value = battleEntity.HP;
            currentHP = value;
        } // Battle Ŭ�������� ���� ü�� ������ ������ �� �ִ�.
    }

    public int CurrentSP
    {
        get
        {
            if(currentSP<=0)
            {
                currentSP = 0;
            } 
            else { }
            return currentSP;
        }

        private set 
        {
            if (value > battleEntity.SP) value = battleEntity.SP;
            currentSP = value;
        }
    }

    public bool isDefending = false;

    [SerializeField] private int currentHP;
    [SerializeField] private int currentSP;

    // Start is called before the first frame update
    void Start()
    {
        //battleEntity = new BattleEntity(playerHP, playerATK, playerDEF);

        Debug.Log($"HP : {battleEntity.HP}, SP : {battleEntity.SP}, ATK : {battleEntity.ATK}, DEF : {battleEntity.DEF}");
        battleUI.SetBattleUI(battleEntity);
        CurrentHP = battleEntity.HP;
        CurrentSP = battleEntity.SP;
    }

    // Update is called once per frame
    void Update()
    {
        battleUI.SetHPBar(CurrentHP, battleEntity.HP);
        battleUI.SetSPBar(CurrentSP, battleEntity.SP);

    }

    // ��뿡�� �������� �޴´� (TakeDamage) :: CurrentHP - (ATK ���¿� ���� ����)
    
    // �������� �Ծ���
    public virtual void TakeDamge(Battle other)
    {
        int FinalDamage = (other.battleEntity.ATK - battleEntity.DEF);
        if (FinalDamage <= 0) FinalDamage = 1;    
        CurrentHP -= FinalDamage; // ����� ���ݷ�   
        if (CurrentHP <= 0)
        {
            Death();
        }

        //Debug.Log($"���������� : {FinalDamage}, �������� ���ݷ� : {other.battleEntity.ATK}, �������� ���� : {other.battleEntity.DEF}");

        //// ���� ü���� 0���� Ŭ��
        //// ���� ü���� 0���� �۰ų� ���� ��
        //if (CurrentHP >0)
        //{
        //    // �ǰ� ���� ȿ����, ����Ʈ, �ִϸ��̼� ... �̺�Ʈ ����
        //}
        //else
        //{
        //    // ��� ���� ȿ����, ����Ʈ, �ִϸ��̼� ... �̺�Ʈ ����
        //}
    }

    private void UsingSP(int amount)
    {        
        CurrentSP -= amount;
    }

    private void GetCoin(int amount)
    {
        battleEntity.COIN += amount;
        battleUI.SetBattleUI(battleEntity);
    }

    private bool UsingCoin(int amount)
    {
        if(battleEntity.COIN >= amount)
        {
            battleEntity.COIN -= amount;
            return true;
        }
        else
        {
            return false;
        }       
    }

    // �׾��� �� ���� ó���ϱ� Die, Death :: CurrentHP 0���� �۾�������
    public void Death()
    {
        GetCoin(10);

        gameObject.SetActive(false);     

        Invoke(nameof(Respawn), 2f);
    }



    private void Respawn()
    {
        CurrentHP = battleEntity.HP;
        CurrentSP = battleEntity.SP;
        gameObject.SetActive(true);

    } 

    public abstract void Attack(Battle other);

    public virtual void AttackSP(Battle other)
    {
        UsingSP(10);
        int FinalDamage = (battleEntity.ATK*2 - other.battleEntity.DEF);
        if (FinalDamage <= 0) FinalDamage = 1;
        other.CurrentHP -= FinalDamage;
        if (CurrentHP <= 0)
        {
            Death();
        }
    }

    public virtual void Defend(int amount)
    {
        battleEntity.DEF = amount * 2;
        isDefending = true;
    }

    public virtual void Recover()
    {
        BattleResource recoverAmount = new BattleResource(30, 5);

        CurrentHP += recoverAmount.HP;
        CurrentSP += recoverAmount.SP;
    }

    public virtual void HpUp(int amount)
    {
        battleEntity.HP += amount;
        battleUI.SetBattleUI(battleEntity);
    }

    public virtual void SpUp(int amount)
    {
        battleEntity.SP += amount;
        battleUI.SetBattleUI(battleEntity);
    }

    public virtual void AttackUp(int amount)
    {
        battleEntity.ATK += amount;
        battleUI.SetBattleUI(battleEntity);
    }

    public virtual void ShieldUP(int amount)
    {
        UsingCoin(10);
        battleEntity.DEF += amount;
        battleUI.SetBattleUI(battleEntity);
    }
}
