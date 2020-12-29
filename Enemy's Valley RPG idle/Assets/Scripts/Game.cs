using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
//using System.Xml;
//using GooglePlayGames;
//using UnityEngine.SocialPlatforms;
//using GooglePlayGames.BasicApi;
using UnityEngine.Advertisements;
public class Game : MonoBehaviour
{
    public GameObject prefab_enemy; // префаб противника. Создаются его копии

    public GameObject BGFight; // родной фон для префаба противника

    public Sprite[] EnemiesSprite = new Sprite[4]; // массив спрайтов противников
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void GeneratorEnemy()
    {
        GameObject enemyObj = Instantiate(prefab_enemy, prefab_enemy.transform.position, Quaternion.identity) as GameObject;
        int rand = Random.Range(0, 4);
        enemyObj.GetComponent<Image>().sprite = EnemiesSprite[rand];
        enemyObj.transform.SetParent(BGFight.transform);
        enemyObj.transform.localPosition = new Vector3(Random.Range(-290, 210), Random.Range(370, -210), 0);
        enemyObj.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
