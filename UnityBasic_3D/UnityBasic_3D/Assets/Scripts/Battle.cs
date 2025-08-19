using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BattleEntity
{
    public int HP;
    public int ATK;
    public int DEF;
    public string AttackType;

    public BattleEntity() { }
    public BattleEntity(int hP, int aTK)
    {
        HP = hP;
        ATK = aTK;
    }

    public BattleEntity(int hP, int aTK, int dEF)
    {
        HP = hP;
        ATK = aTK;
        DEF = dEF;
    }
}

[System.Serializable]
public class BattleUI
{
    public Image HPBar;
    public TextMeshProUGUI BattleEntityHPText;
    public TextMeshProUGUI BattleEntityATKText;
    public TextMeshProUGUI BattleEntityDEFText;
        
    public void SetBattleUI(BattleEntity battleEntity)
    {
        BattleEntityHPText.SetText($"HP : {battleEntity.HP}");
        BattleEntityATKText.SetText($"ATK : {battleEntity.ATK}");
        BattleEntityDEFText.SetText($"DEF : {battleEntity.DEF}");       
    }

    public void SetHPBar(int current, int max)
    {
        HPBar.fillAmount = (float)current / max;
                
    }
}
public class Battle : MonoBehaviour
{
    public BattleEntity battleEntity;
    public BattleUI battleUI;

    //public int playerHP;
    //public int playerATK;
    //public int playerDEF;
    public BattleManager battleManager;
    public bool IsPlayer;
   
    public int CurrentHP
    {
        get
        {
            if (currentHP <= 0)
            {
                // �ǰ� ���� ȿ����, ����Ʈ, �ִϸ��̼� ... �̺�Ʈ ����
                currentHP = 0;
                Death();
            }
            else
            { 

            }
            // ��� ���� ȿ����, ����Ʈ, �ִϸ��̼� ... �̺�Ʈ ����
            return currentHP;
        }

        private set 
        { 
            if(value > battleEntity.HP) value = battleEntity.HP;
            currentHP = value; 
        } // Battle Ŭ�������� ���� ü�� ������ ������ �� �ִ�.
    }

    [SerializeField] private int currentHP;  

    // Start is called before the first frame update
    void Start()
    {
        //battleEntity = new BattleEntity(playerHP, playerATK, playerDEF);

        Debug.Log($"HP : {battleEntity.HP}, ATK : {battleEntity.ATK}, DEF : {battleEntity.DEF}");
        battleUI.SetBattleUI(battleEntity);
        CurrentHP = battleEntity.HP;
    }

    // Update is called once per frame
    void Update()
    {
        battleUI.SetHPBar(CurrentHP, battleEntity.HP);
    }

    // ��뿡�� �������� �޴´� (TakeDamage) :: CurrentHP - (ATK ���¿� ���� ����)
    
    // �������� �Ծ���
    public void TakeDamge(Battle other)
    {
        int FinalDamage = (other.battleEntity.ATK - battleEntity.DEF);
        if (FinalDamage <= 0) FinalDamage = 1;
        CurrentHP -= FinalDamage; // ����� ���ݷ�

        Debug.Log($"���������� : {FinalDamage}, �������� ���ݷ� : {other.battleEntity.ATK}, �������� ���� : {other.battleEntity.DEF}");

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

    // �׾��� �� ���� ó���ϱ� Die, Death :: CurrentHP 0���� �۾�������
    public void Death()
    {
        // ���
        Debug.Log($"����߽��ϴ�. ���� ü�� : {currentHP}");
    }

    public void Attack()
    {

    }
    public void Recover(int amount)
    {
        if (IsPlayer && !battleManager.playerTurn) return;

        CurrentHP += amount;
        //battleManager.TurnChange();
    }

    public void ShieldUP(int amount)
    {
        if (IsPlayer && !battleManager.playerTurn) return;

        battleEntity.DEF += amount;
        battleUI.SetBattleUI(battleEntity);
        //battleManager.TurnChange();
    }

}
