using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform birdTransform; // Tham chiếu tới đối tượng bird
    public Transform pipeTransform; // Tham chiếu tới đối tượng pipe
    public float distanceThreshold = 2f; // Ngưỡng khoảng cách, chỉnh sửa giá trị theo nhu cầu

    void Update()
    {
        float distanceX = Mathf.Abs(pipeTransform.position.x - birdTransform.position.x);

        if (distanceX <= distanceThreshold)
        {
            Debug.Log("da den");
        }
    }
}
