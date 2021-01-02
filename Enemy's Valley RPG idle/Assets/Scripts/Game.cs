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

    public static int WaveEnemy = 1; // волна противников (от 1 до 10, 10-й Босс)
    public static int idEnemy = 0;

    public static bool CreateEnemies = false; // нужно ли создавать противников

    public GameObject prefab_enemy; // префаб противника. Создаются его копии

    public GameObject BGFight; // родной фон для префаба противника

    public Sprite[] EnemiesSprite = new Sprite[4]; // массив спрайтов противников
    void Start()
    {
        
    }

    
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            //CreateEnemies = true;
            idEnemy = 0;
        }
        //else CreateEnemies = false;

        if (CreateEnemies == true)
        {
            switch (WaveEnemy)
            {
                case 1:
                case 2:
                    idEnemy += 1;
                    GeneratorEnemy();
                    CreateEnemies = false;
                    break;
                case 3:
                case 4:
                    for (int i = 1; i <= 2; i++)
                    {
                        idEnemy += 1;
                        GeneratorEnemy();
                    }
                    CreateEnemies = false;
                    break;
                case 5:
                case 6:
                    for (int i = 1; i <= 3; i++)
                    {
                        idEnemy += 1;
                        GeneratorEnemy();
                    }
                    CreateEnemies = false;
                    break;
                case 7:
                case 8:
                    for (int i = 1; i <= 4; i++)
                    {
                        idEnemy += 1;
                        GeneratorEnemy();
                    }
                    CreateEnemies = false;
                    break;
                case 9:
                case 10:
                    for (int i = 1; i <= 5; i++)
                    {
                        idEnemy += 1;
                        GeneratorEnemy();
                    }
                    CreateEnemies = false;
                    break;
                default: break;
            }
        }
    }

    public void Test()
    {
        WaveEnemy = 5;
        CreateEnemies = true;
    }
    /// <summary>
    /// Генерация противника
    /// </summary>
    public void GeneratorEnemy()
    {
        
        GameObject enemyObj = Instantiate(prefab_enemy, prefab_enemy.transform.position, Quaternion.identity) as GameObject;
        enemyObj.GetComponent<Enemy>().idEnemy = idEnemy;
        enemyObj.GetComponent<Enemy>().maxHealth= 100;
        enemyObj.GetComponent<Enemy>().health = 100;
        int rand = Random.Range(0, 4);
        enemyObj.GetComponent<Image>().sprite = EnemiesSprite[rand];
        enemyObj.transform.SetParent(BGFight.transform);
        //enemyObj.transform.localPosition = new Vector3(Random.Range(-290, 210), Random.Range(370, -210), 0);
        enemyObj.transform.localScale = new Vector3(1f, 1f, 1f);
        switch (idEnemy)
        {
            case 1: enemyObj.GetComponent<Animation>().Play("NewEnemy"); break;
            case 2: enemyObj.GetComponent<Animation>().Play("NewEnemy2"); break;
            case 3: enemyObj.GetComponent<Animation>().Play("NewEnemy3"); break;
            case 4: enemyObj.GetComponent<Animation>().Play("NewEnemy4"); break;
            case 5: enemyObj.GetComponent<Animation>().Play("NewEnemy5"); break;
            default: break;
        }

    }
}
