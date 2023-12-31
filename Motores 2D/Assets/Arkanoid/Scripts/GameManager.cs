using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public bool segurando;
    private Vector3 offset;

    private void Awake()
    {
        instance = this;
    }
// Start is called before the first frame update
    void Start()
    {
        SpawnarNovoJogador();
        AtualizarContador();
        tijolosRestantes = GameObject.FindGameObjectsWithTag("Tijolo").Length;
    }

    public void AtualizarContador()
    {
        contador.text = $"Vidas: {vidas}";
    }
    public void SpawnarNovoJogador()
    {
        GameObject playerObj = Instantiate(playerPrefab, SpawnPointPlayerB.position, Quaternion.identity);
        GameObject ballObj = Instantiate(ballPrefab, SpawnPointBallB.position, Quaternion.identity);

        playerAtual = playerObj.GetComponent<PlayerB>();
        ballAtual = ballObj.GetComponent<BallB>();

        segurando = true;
        offset = playerAtual.transform.position - ballAtual.transform.position;
    }

    public void SubtrairTijolo()
    {
        tijolosRestantes--;
        
        if (tijolosRestantes <= 0)
        {
            Vitoria();
        }
    }
    public void SubtrairVida()
    {
        vidas--;
        AtualizarContador();
        Destroy(playerAtual.gameObject);
        Destroy(ballAtual.gameObject);

        if (vidas <= 0)
        {
            GameOver();
        }

        else
        {
            Invoke(nameof(SpawnarNovoJogador),2);
        }
    }

    public void Vitoria()
    {
        msgFinal.text = "Parabéns";
        Destroy(ballAtual.gameObject);
        Invoke(nameof(ReiniciarCena), 2);
    }

    public void GameOver()
    {
        msgFinal.text = "Game Over";
        Invoke(nameof(ReiniciarCena),2);
    }

    public void ReiniciarCena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if (segurando)
        {
            ballAtual.transform.position = playerAtual.transform.position - offset;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ballAtual.DispararBolinha(playerAtual.inputX);
                segurando = false;
            }
        }
    }
}
