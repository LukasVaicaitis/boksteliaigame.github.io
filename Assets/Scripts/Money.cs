using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text moneyText;

    void Start()
    {

    }

    void Update()
    {
        moneyText.text = "$" + PlayerStats.Money.ToString();
    }
}
