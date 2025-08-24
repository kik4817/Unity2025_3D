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

// abstract class : 추상 클래스
// 이 클래스를 인스턴스 할 수 없다
// 이 클래스를 오브젝트의 컴포넌트로 사용하지 마세요
// Player, Monster를 사용해서 이 클래스를 구현하라.
// 메소드에 abstract 키워드를 추가할 수 있다.

/*
 * abstract vs virtual
 * 
 * abstract 추상 함수 : 분문을 가질 수 없다. - 자식 클래스에서 구현을 강제한다.
 * 
 * virtual 가상 함수 : 본문을 가질 수 있습니다. 자식 클래스에서 이 코드를 사용을 안할 수도 있고, base키워드를 사용해서 사용할 수 있다.
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
                // 피격 시의 효과음, 이펙트, 애니메이션 ... 이벤트 실행
                currentHP = 0;              
            }          
            else { }
            // 사망 시의 효과금, 이펙트, 애니메이션 ... 이벤트 실행
            return currentHP;
        }

        private set 
        { 
            if(value > battleEntity.HP) value = battleEntity.HP;
            currentHP = value;
        } // Battle 클래스에서 현재 체력 변수를 수정할 수 있다.
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

    // 상대에게 데미지를 받는다 (TakeDamage) :: CurrentHP - (ATK 방어력에 따라서 감소)
    
    // 데미지를 입었다
    public virtual void TakeDamge(Battle other)
    {
        int FinalDamage = (other.battleEntity.ATK - battleEntity.DEF);
        if (FinalDamage <= 0) FinalDamage = 1;    
        CurrentHP -= FinalDamage; // 상대의 공격력   
        if (CurrentHP <= 0)
        {
            Death();
        }

        //Debug.Log($"최종데미지 : {FinalDamage}, 공격자의 공격력 : {other.battleEntity.ATK}, 공격자의 방어력 : {other.battleEntity.DEF}");

        //// 남은 체력이 0보다 클때
        //// 남은 체력이 0보다 작거나 같을 때
        //if (CurrentHP >0)
        //{
        //    // 피격 시의 효과음, 이펙트, 애니메이션 ... 이벤트 실행
        //}
        //else
        //{
        //    // 사망 시의 효과금, 이펙트, 애니메이션 ... 이벤트 실행
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

    // 죽었을 때 로직 처리하기 Die, Death :: CurrentHP 0보다 작아졌을때
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
