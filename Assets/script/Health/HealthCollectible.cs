using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
     //ผมไม่รู้จะ clean อะไรแล้วครับผมคิดว่ามัน CLEAN แล้วTT ขอโทษครับผมกลัวบัค
}