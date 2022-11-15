using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Snake Snake;
    public Transform Finish;
    public Slider Slider;
    private float startZ;
    private float finishZ;
    private float maximumReachedZ;
    private float acceptableFinishPLayerDistance = 0.96f;

    private void Start()
    {
        startZ = Snake.transform.position.z;
        finishZ = Finish.position.z;
    }

    private void Update()
    {
        float currentZ = Snake.transform.position.z;
        maximumReachedZ = Mathf.Max(maximumReachedZ, currentZ);
        float t = Mathf.InverseLerp(startZ, finishZ - acceptableFinishPLayerDistance, maximumReachedZ);
        Slider.value = t;
    }
}
