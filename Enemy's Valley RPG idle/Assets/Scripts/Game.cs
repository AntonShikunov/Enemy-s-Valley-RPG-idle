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

    public static int WaveEnemy = 9; // волна противников (от 1 до 10, 10-й Босс)
    public static int idEnemy = 0; // id противника для воспроизведения нужной анимации.

    public static bool CreateEnemies = true; // нужно ли создавать противников

    public GameObject prefab_enemy; // префаб противника. Создаются его копии
    public GameObject prefab_boss; // префаб босса. Создаются его копии

    public GameObject BGFight; // родной фон для префаба противника

    public Slider HPBossSlider; // слайдер здоровья Босса. Включается тогда и только тогда когда появляется на сцене БОСС
    public Text HPBossText; // текст в котором отображается уровень здоровья БОССА ТВАРИ

    public Sprite[] EnemiesSprite = new Sprite[4]; // массив спрайтов противников
    public Sprite[] BossSprite = new Sprite[2]; // массив спрайтов босса
    void Start()
    {
        HPBossSlider.GetComponent<GameObject>().SetActive(false);
    }

    
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && GameObject.FindGameObjectsWithTag("Boss").Length == 0)
        {
            //CreateEnemies = true;
            if (WaveEnemy <= 11)
            {
                WaveEnemy += 1;
            }
            else if (WaveEnemy > 11)
            {
                WaveEnemy = 1;
            }
            idEnemy = 0;
            CreateEnemies = true;
        }

        if (GameObject.FindGameObjectsWithTag("Boss").Length > 0)
        {
            HPBossSlider.GetComponent<GameObject>().SetActive(true);
            HPBossSlider.maxValue = GetComponent<Enemy>().getMaxHealth();
            HPBossSlider.value = GetComponent<Enemy>().getHealth();
            HPBossText.text = "" + GetComponent<Enemy>().getHealth().ToString("N0");
        }

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
                case 11:
                    GeneratorBoss(); // один вызов метода генерации БОССОВНОЙ СУЧКИ
                    CreateEnemies = false;
                    break;
                default: break;
            }
        }
    }

    public void Test()
    {
        WaveEnemy = 1;
        CreateEnemies = true;
    }
    /// <summary>
    /// Метод генерации противника
    /// </summary>
    public void GeneratorEnemy()
    {
        
        GameObject enemyObj = Instantiate(prefab_enemy, prefab_enemy.transform.position, Quaternion.identity) as GameObject;
        enemyObj.GetComponent<Enemy>().setIdEnemy(idEnemy);
        enemyObj.GetComponent<Enemy>().setMaxHealth(1);
        enemyObj.GetComponent<Enemy>().setHealth(1);
        int rand = Random.Range(0, 4);
        enemyObj.GetComponent<Image>().sprite = EnemiesSprite[rand];
        enemyObj.transform.SetParent(BGFight.transform);
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
    /// <summary>
    /// Метод генерации босса
    /// </summary>
    public void GeneratorBoss()
    {
        GameObject enemyObj = Instantiate(prefab_boss, prefab_boss.transform.position, Quaternion.identity) as GameObject;
        enemyObj.GetComponent<Enemy>().setIdEnemy(idEnemy);
        enemyObj.GetComponent<Enemy>().setMaxHealth(2);
        enemyObj.GetComponent<Enemy>().setHealth(2);
        int rand = Random.Range(0, 2);
        enemyObj.GetComponent<Image>().sprite = BossSprite[rand];
        enemyObj.transform.SetParent(BGFight.transform);
        enemyObj.transform.localPosition = new Vector3(-140f, 60f, 0f);
        enemyObj.transform.localScale = new Vector3(1f, 1f, 1f);
        enemyObj.GetComponent<Animation>().Play("NewBoss");
    }
}
