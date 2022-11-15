using TMPro;
using UnityEngine;
using Random = System.Random;

public class Block : MonoBehaviour
{
    public SnakeTail SnakeTail;
    public Snake Snake;
    public TMP_Text TextBlockHealth;
    public Material BlockMaterial;
    public GameObject SmokePrefab;

    Random rnd = new Random();
    private int blockHealth;

    public int MinBlockHealth = 1;
    public int MaxBlockHealth = 25;

    private new Renderer renderer;

    private float updateTime = 0f;

    private new Animation animation;

    private void Start()
    {
        blockHealth = rnd.Next(MinBlockHealth, MaxBlockHealth);
        renderer = GetComponent<Renderer>();
        animation = GetComponent<Animation>();
        
    }

    private void Update()
    {
        TextBlockHealth.text = blockHealth.ToString();
        renderer.material.SetFloat("_GradientColor", blockHealth * 0.04f);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            return;
        }
        animation.Play();
        updateTime -= Time.deltaTime;

        if (updateTime < 0)
        {
            if (blockHealth > 1 && SnakeTail.Health > 1)
            {
                blockHealth--;
                SnakeTail.RemoveSphere();
            }
            else
            {
                if (SnakeTail.Health > 1)
                {
                    SnakeTail.RemoveSphere();                    
                    Destroy(gameObject);
                    GameObject smokePrefab = Instantiate(SmokePrefab, transform.position, transform.rotation);
                    Destroy(smokePrefab, 1f);
                    Snake.Destroy();
                }
                else
                {
                    blockHealth--;
                    collision.gameObject.tag = "Snake";
                    SnakeTail.Die();
                }
            }
            updateTime = 0.15f;
        }
    }
}
