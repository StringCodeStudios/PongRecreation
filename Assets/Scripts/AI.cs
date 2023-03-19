using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] float speed = 15f;
    [SerializeField] float range = 6f;

    Transform theBall;
    Vector3 move = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        theBall = FindObjectOfType<Ball>().GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowBall();
    }

    private void FollowBall()
    {
        float dis = theBall.position.y - transform.position.y;
        if (dis > 0)
        {
            move.y = speed * Mathf.Min(dis, 1.0f);
        }
        if (dis < 0)
        {
            move.y = -speed * Mathf.Min(-dis, 1.0f);
        }

        float yOffset = move.y * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -range, range);

        
        transform.localPosition = new Vector2(transform.localPosition.x, clampedYPos);
    }
}

