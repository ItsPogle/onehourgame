using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    public GameObject player;
    public List<GameObject> enemies = new List<GameObject>();
    public TextMeshProUGUI text;
    public AudioSource AS;
    public AudioClip hitmark;
    public Transform[] spawns;
    public GameObject enemy;

    void Awake()
    {
        instance = this;
        StartCoroutine(SpawnEnemies());
    }

    public void GameOver()
    {
        score = 0;
        player.transform.position = new Vector3(0, 0, 0);
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }

    public void Update()
    {
        text.text = score.ToString();
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            for (int i = 0; i < spawns.Length; i++)
            {
                GameObject GO = Instantiate(enemy, spawns[i]);
                enemies.Add(GO);
            }
        }
    }
}
