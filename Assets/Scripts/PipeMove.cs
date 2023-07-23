using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PipeMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed;
    [SerializeField]
    private float oldPos;
    [SerializeField]
    private float screenLimitX;
    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxY;
    // Biến để theo dõi xem đối tượng đã đi qua màn hình hay chưa
    private bool hasPassedScreen;
    void Start()
    {
        minY = -1;
        maxY = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vitriPipe = transform.position;
        vitriPipe.x -= speed * Time.deltaTime;
        transform.position = vitriPipe;
        if (transform.position.x < screenLimitX)
        {
            transform.position = new Vector3(oldPos, Random.Range(minY, maxY + 1), 0);
        }

    }
}
