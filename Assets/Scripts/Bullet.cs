using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject m_fighter;
    public float m_speed = 4f;
    void Update()
    {
        transform.Translate(m_speed * Time.deltaTime, 0, 0);
        var sp = Camera.main.WorldToScreenPoint(transform.position);
        if (sp.x > Screen.width)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.tag.Equals("Enemy"))
        {
            m_fighter.SendMessage("IncrScore");
            Destroy(collision.gameObject);
            Destroy(gameObject);
            
        }
    }


    public void SetSpeed(float speed, GameObject fighter)
    {
        m_fighter = fighter;
        m_speed = speed;
        Debug.Log("set speed to: " + speed);
    }
}
