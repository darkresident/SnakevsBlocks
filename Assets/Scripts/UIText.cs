using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIText : MonoBehaviour
{
    public SnakeTail SnakeTail;
    public TMP_Text BlockCount;
    public TMP_Text CurrentLevel;
    public TMP_Text NextLevel;
    public TMP_Text TextWin;

    private void Start()
    {   
        CurrentLevel.text = SceneManager.GetActiveScene().buildIndex.ToString();
        NextLevel.text = (SceneManager.GetActiveScene().buildIndex +1).ToString();
        TextWin.text = "Level " + SceneManager.GetActiveScene().buildIndex.ToString() + " passed!";
    }
    void Update()
    {
        BlockCount.text = SnakeTail.BlockCount.ToString();
    }
}
