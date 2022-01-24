using UnityEngine;

public class Bullet : MonoBehaviour
{
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

    public void SetSpeed(float speed)
    {
        m_speed = speed;
        Debug.Log("set speed to: " + speed);
    }
}
