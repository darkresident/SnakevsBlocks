using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public Transform SnakeHead;
    public GameObject PanelRestart;
    private Snake snake;
    private Control control;
    public float SphereDiameter;
    public int Health = 1;
    public static int BlockCount;
    public TMP_Text HealthText;
    private Vector3 offset;
    private AudioSource RemoveSound;

    private List<Transform> snakeSpheres = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();

    private void Awake()
    {
        positions.Add(SnakeHead.position);
        offset = SnakeHead.transform.position - HealthText.rectTransform.position;
        RemoveSound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        snake = GameObject.FindWithTag("Player").GetComponent<Snake>();
        control = snake.GetComponent<Control>();
        AddSphere();
        AddSphere();
    }

    private void Update()
    {
        HealthText.text = Health.ToString();
        HealthText.rectTransform.position = SnakeHead.position - offset;        
        
        float distance = (SnakeHead.position - positions[0]).magnitude;

        if (distance > SphereDiameter)
        {   
            Vector3 direction = (SnakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * SphereDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= SphereDiameter;
        }

        for (int i = 0; i < snakeSpheres.Count; i++)
        {
            snakeSpheres[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / SphereDiameter);
        }
    }

    public void AddSphere()
    {
        Transform sphere = Instantiate(SnakeHead, positions[positions.Count - 1], Quaternion.identity, transform);
        sphere.tag = "Snake";
        snakeSpheres.Add(sphere);
        positions.Add(sphere.position);
        Health++;
    }

    public void RemoveSphere()
    {
        RemoveSound.Play();
        snake.Blood();
        Destroy(snakeSpheres[snakeSpheres.Count - 1].gameObject); // Удаление последнего элемента в массиве
        snakeSpheres.RemoveAt(snakeSpheres.Count - 1);
        positions.RemoveAt(positions.Count - 1);
        //Destroy(snakeCircles[0].gameObject); // Удаление первого элемента в массиве
        //snakeCircles.RemoveAt(0);
        //positions.RemoveAt(1);
        Health--;
        BlockCount++;
    }

    public void Die()
    {
        Health = 0;
        control.enabled = false;
        snake.Die = true;
        Invoke("Pause", 5f);
    }
    private void Pause()
    {
        PanelRestart.SetActive(true);
        Time.timeScale = 0f;
    }
}
