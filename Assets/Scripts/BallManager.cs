using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject EnemyPrefab;
    float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        createEnemy();

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1f));
        //    TouchBegan(pos);
        //}

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                TouchBegan(touch);
            }
        }
    }


    private void TouchBegan(Touch touch)
    {
        GameObject newBall = Instantiate(ballPrefab);
        newBall.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
        newBall.transform.position = Camera.main.transform.position + Camera.main.transform.forward;

        Rigidbody rigidbody = newBall.GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(0f, 0f, 0f);
        float force = 600.0f;
        rigidbody.AddForce(Camera.main.transform.forward * force);
    }

    private void createEnemy()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > 2.0f)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-5, 5), Random.Range(0, 3), Random.Range(-5, 5));
            Instantiate(EnemyPrefab, Camera.main.transform.position + Camera.main.transform.forward * 5 + spawnPosition, Quaternion.identity);

            timeElapsed = 0;
        }
    }
}
