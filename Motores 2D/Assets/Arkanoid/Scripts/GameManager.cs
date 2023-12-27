using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int vidas = 2;
    public int tijolosRestantes;
    

    public GameObject playerPrefab;
    public GameObject ballPrefab;

    public Transform SpawnPointPlayerB;
    public Transform SpawnPointBallB;

    public PlayerB playerAtual;
    public BallB ballAtual;
    public TextMeshProUGUI contador;
    public TextMeshProUGUI msgFinal;
    

    void Awake()
    {
        instance = this;
    }
// Start is called before the first frame update
    void Start()
    {
        SpawnarNovoJogador();
    }

    public void SpawnarNovoJogador()
    {
        GameObject playerObj = 
            Instantiate(playerPrefab, SpawnPointPlayerB.position, Quaternion.identity);
        GameObject ballObj = 
            Instantiate(ballPrefab, SpawnPointBallB.position, Quaternion.identity);
    }
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
