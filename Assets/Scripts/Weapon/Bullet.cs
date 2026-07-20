using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;

    private float liveTime = 2f;

    private void Update()
    {
        liveTime -= Time.deltaTime;

        if (liveTime > 0) 
        {
            Vector2 current = transform.position;
            Vector2 target = transform.position + speed * Time.deltaTime * transform.up;
            float maxDistanceDelta = speed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(current, target, maxDistanceDelta);
        }
        else
        {
            Destroy(transform.gameObject);
        }
    }    
}
