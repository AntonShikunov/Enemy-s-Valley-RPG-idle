using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int h;
    public int maxHealth;
    public int idEnemy, health; /* id считывается для того чтоб воспроизводилась нужная анимация появления
    (всего 5 id. Для idEnemy = 1 воспроизводится анимация NewEnemy, для idEnemy = 2 анимация NewEnemy2 и т.д... health - здоровье*/
    public Slider HPSlider; // слайдер здоровья противника

    public Enemy(int idEnemy, int maxHealth, int health) // конструктор противника
    {
        this.idEnemy = idEnemy;
        this.maxHealth = maxHealth;
        this.health = health;

    }

    public int getIdEnemy() { return idEnemy; }
    public void setIdEnemy(int id) { idEnemy = id; }
    public int getMaxHealth() { return maxHealth; }
    public void setMaxHealth(int maxHP) { maxHealth = maxHP; }
    public int getHealth() { return health; }
    public void setHealth(int hp) { health = hp; }

    void OnMouseDown()
    {
        transform.localScale = new Vector3(0.990f, 0.990f, 0.990f);
        gameObject.GetComponent<Image>().color = new Color(235 / 255.0f, 36 / 255.0f, 36 / 255.0f);

    }
    void OnMouseUp()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        gameObject.GetComponent<Image>().color = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f);
        HPSlider.maxValue = getMaxHealth();
        hit_enemy();
        HPSlider.value = getHealth();

        //Destroy(gameObject);
    }

    /// <summary>
    /// Метод, который вызывается всякий раз когда бьёшь противника
    /// </summary>
    public void hit_enemy()
    {
        setHealth(getHealth() - Skills.baseDamage);
        
    }

}
