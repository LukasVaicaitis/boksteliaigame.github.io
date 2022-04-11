using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text text;
    
    // Update is called once per frame
    void Update()
    {
        text.text = PlayerStats.Lives.ToString() + " LIVES";
    }
}
