using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour {

    public GameObject[] Train;
    // クリックした位置座標
    private Vector3 clickPosition;
    private int number;
    private int count;
    void Start()
    {
        count = 0;
        SoundManager.Instance.PlayBGM(0);
    }
    void Awake()
    {
        Application.targetFrameRate = 60;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
         {
            clickPosition = Input.mousePosition;
            clickPosition.y = 0f;
            clickPosition.z = 10f;
            //number = Random.Range(0, Train.Length); ランダム処理
            Instantiate(Train[count], transform.position, transform.rotation);
            StartCoroutine("Firework_SE");
            if (count >= Train.Length - 1)
                {
                    count = 0;
                }
            else
                {
                    count++;
                }
            //Instantiate(Train[number], Camera.main.ScreenToWorldPoint(clickPosition), Train[number].transform.rotation);
         }

    }

    // コルーチン  
    private IEnumerator Firework_SE()
    {
        yield return new WaitForSeconds(3.0f);
        // コルーチンの処理  
        //SoundManager.Instance.PlayBGM(0);
        Debug.Log("2");
        SoundManager.Instance.PlaySE(0);
    }



}
