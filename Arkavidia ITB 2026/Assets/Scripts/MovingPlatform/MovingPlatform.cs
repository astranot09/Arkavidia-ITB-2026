using NUnit.Framework;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] points;
    [SerializeField] private GameObject containerPoints;
    [SerializeField] private float speed;
    private int currentIndex;
    private Transform currentPos;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        int childPoints = containerPoints.transform.childCount;
        points = new GameObject[childPoints];
        for (int i = 0; i < childPoints; i++)
        {
            points[i] = containerPoints.transform.GetChild(i).gameObject;
        }
        currentPos = points[0].transform;
    }

    private void FixedUpdate()
    {
        Vector2 direction = (points[currentIndex].transform.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
        if (Vector2.Distance(transform.position, points[currentIndex].transform.position) < 0.5f)
        {
            currentIndex++;
            if (currentIndex >= points.Length)
            {
                currentIndex = 0;
            }
        }
    }
}
