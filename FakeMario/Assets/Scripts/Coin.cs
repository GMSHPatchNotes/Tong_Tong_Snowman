using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    SpriteRenderer sr;

    [SerializeField] GameObject coin;
    
    Score score;
    Coin_Text coin_text;
    GameObject coinins;
    public bool istouch = false;
    private bool move = false;
    private bool cantouch = true;
    Color coincolor; 

    private void Start()
    {
        score = GameObject.Find("GameSystemManager").GetComponent<Score>();
        coin_text = GameObject.Find("GameSystemManager").GetComponent<Coin_Text>();
        sr = GetComponent<SpriteRenderer>();
        coinins = Instantiate(coin);
        coincolor = coinins.GetComponent<SpriteRenderer>().color;
        coincolor.a = 0;
        coinins.GetComponent<SpriteRenderer>().color = coincolor;
        coinins.transform.position = transform.position;
    }

    void Update()
    {
        if (istouch && cantouch)
        {
            coincolor.a = 1;
            score.score += 100;
            coin_text.coin_amount++;
            coinins.GetComponent<SpriteRenderer>().color = coincolor;
            istouch = false;
            cantouch = false;
            move = true;
        }

        if (move)
        {
            coinins.transform.position += new Vector3(0, 3) * Time.deltaTime;
            if (coinins.transform.position.y >= transform.position.y + 0.6f)
            {
                coincolor.a -= 0.01f;
                coinins.GetComponent<SpriteRenderer>().color = coincolor;
            }
        }
        


        


    }

}
