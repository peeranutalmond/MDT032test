using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealth;
    [SerializeField] private Image currenthealth;

    private void Start()
    {
        totalhealth.fillAmount = playerHealth.currentHealth / 10;
    }
    private void Update()
    {
        currenthealth.fillAmount = playerHealth.currentHealth / 10;
    }
        //ผมไม่รู้จะ clean อะไรแล้วครับผมคิดว่ามัน CLEAN แล้วTT ขอโทษครับ
}