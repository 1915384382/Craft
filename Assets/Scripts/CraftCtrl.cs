using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftCtrl : MonoBehaviour
{
    [HideInInspector]
    public string path;
    public PoolPathType pooltype;
    private int hp;
    public int HP { get { return hp; }
        set { hp = value;
            GameManager.Instance?.actionHpChange?.Invoke(this, hp);
        }
    }
    public int MaxHP;
    public int moveSpeed;
    public int damageValue;
    public float ShootCd;
    [HideInInspector]
    public bool IsDie { get { return HP <= 0; } }
    public void FixHP() 
    {
        HP = Mathf.Clamp(HP, 0, MaxHP);
    }
    public virtual void OnDamage(int value) 
    {
        HP -= value;
        HP = Mathf.Clamp(HP, 0, MaxHP);
        BeHit(value);
    }
    public virtual void BeHit(int value)
    {

    }
    public virtual void SetLevel(int addLevel) 
    {

    }
    public virtual void OnReset() 
    {

    }
    public void Setaction() 
    {
        GameManager.Instance.actionResetGame += OnGameReset;
    }
    public void OnGameReset(int a) 
    {
        OnReset();
        AirCraftPool.Instance.RevertCraft(this.gameObject);
        GameManager.Instance.actionResetGame -= OnGameReset;
    }
}
