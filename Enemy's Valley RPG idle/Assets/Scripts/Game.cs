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
    public static int lastHPEnemy = 10; // последний показатель HP у врагов, нужен для того чтобы к нему прибавить процент для нового показателя
    public static int lastHPBoss = 100;

    public static bool CreateEnemies = true; // нужно ли создавать противников

    public GameObject prefab_enemy; // префаб противника. Создаются его копии
    public GameObject prefab_boss; // префаб босса. Создаются его копии

    public GameObject BGFight; // родной фон для префаба противника
    public Slider HPBossSlider; // слайдер здоровья Босса. Включается тогда и только тогда когда появляется на сцене БОСС

    public Sprite[] EnemiesSprite = new Sprite[4]; // массив спрайтов противников
    public Sprite[] BossSprite = new Sprite[2]; // массив спрайтов босса
    void Start()
    {

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
            HPBossSlider.gameObject.SetActive(true);
        }
        else { HPBossSlider.gameObject.SetActive(false); }

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
    /// Метод генерирует случайное количество ХП каждого противника на основе предыдущего показателя хп, к которому прибавляется 10 процентов
    /// </summary>
    /// <param name="lastHP">Сюда вносится последний показатель ХП</param>
    /// <returns></returns>
    public int GenerationHealthEnemy(int lastHP)
    {
        int randHP = Random.Range((lastHP - (lastHP / 100) * 20), (lastHP + (lastHP / 100) * 20)); // Случайное количество ХП показателя от -10% до +10%. Например 100 ХП (от 90 до 110)
        return randHP;
    }
    /// <summary>
    /// Метод генерирует случайное количество ХП каждого Босса на основе предыдущего показателя хп, к которому прибавляется 10 процентов
    /// </summary>
    /// <param name="lastHP">Сюда вносится последний показатель ХП</param>
    /// <returns></returns>
    public int GenerationHealthBoss(int lastHP)
    {
        int randHP = Random.Range((lastHP - (lastHP / 100) * 20), (lastHP + (lastHP / 100) * 20)); // Случайное количество ХП показателя от -10% до +10%. Например 100 ХП (от 90 до 110)
        return randHP;
    }
    /// <summary>
    /// Метод генерации противника
    /// </summary>
    public void GeneratorEnemy()
    {
        
        GameObject enemyObj = Instantiate(prefab_enemy, prefab_enemy.transform.position, Quaternion.identity) as GameObject;
        int hp = GenerationHealthEnemy(lastHPEnemy); // генерируется количество ХП для противника
        enemyObj.GetComponent<Enemy>().setIdEnemy(idEnemy);
        enemyObj.GetComponent<Enemy>().setMaxHealth(hp); // заносится максимальное количество ХП
        enemyObj.GetComponent<Enemy>().setHealth(hp); // заносится количество ХП
        lastHPEnemy = hp; // меняется последний показатель ХП для дальнейших его манипуляций в методе GenerationHealth();
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
        int hp = GenerationHealthBoss(lastHPBoss); // генерируется количество ХП для противника
        enemyObj.GetComponent<Boss>().setIdEnemy(idEnemy);
        enemyObj.GetComponent<Boss>().setMaxHealth(hp);
        enemyObj.GetComponent<Boss>().setHealth(hp);
        int rand = Random.Range(0, 2);
        enemyObj.GetComponent<Image>().sprite = BossSprite[rand];
        enemyObj.transform.SetParent(BGFight.transform);
        enemyObj.transform.localPosition = new Vector3(-140f, 60f, 0f);
        enemyObj.transform.localScale = new Vector3(1f, 1f, 1f);
        enemyObj.GetComponent<Animation>().Play("NewBoss");
    }
}
