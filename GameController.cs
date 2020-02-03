using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //the circle and square Gameobjects (GO)
    public GameObject[] BlueGO;
    public GameObject[] OrangeGO;

    //to instantiate the square and circle
    public float startWait;
    public float spawnWait;
    
    GameObject Blue, Orange;

    public GameObject GameOverCanvas;

    //Random Spawn Point in X position
    float[] XPosition = new float[2] { 3.02f, 1.04f };
    public bool GameOverBool;

    void Start()
    {
        StartCoroutine(SpawnObjects());
        GameOverBool = false;
        Time.timeScale = 1;

        GameOverCanvas.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnObjects()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < 50; i++)
            {
                //choosing the Xposition for Orange 
                float OrangeXpos = XPosition[Random.Range(0, XPosition.Length)];

                //setting the position
                Vector3 OrangePos = new Vector3(OrangeXpos, 10, 0);

                //choosing between square or circle
                Orange = OrangeGO[Random.Range(0, XPosition.Length)] as GameObject;

                //Instantiate now
                Instantiate(Orange, OrangePos, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);



                //choosing the Xposition for Blue
                float BlueXpos = -XPosition[Random.Range(0, XPosition.Length)];

                //setting the position
                Vector3 BluePos = new Vector3(BlueXpos, 10, 0);

                //choosing between square or circle
                Blue = BlueGO[Random.Range(0, XPosition.Length)] as GameObject;

                //Instantiate now
                Instantiate(Blue, BluePos, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
        }
    }
    public void StartGame()
    {
        StartCoroutine(SpawnObjects());
    }
    public void GameOver()
    {
        GameOverBool = true;
        Time.timeScale = 0;
        GameOverCanvas.SetActive(true);

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
