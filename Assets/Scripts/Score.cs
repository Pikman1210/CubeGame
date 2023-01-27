using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

    public Transform player;
    public TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.SetText(player.position.z.ToString("0"));
    }
}
