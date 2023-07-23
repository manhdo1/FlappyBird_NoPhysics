using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;
    public Transform birdTransform; // Tham chiếu tới đối tượng bird
    public List<Transform> pipes; // Tham chiếu tới đối tượng pipe
    public Transform pipesChildUp; // Tham chiếu tới đối tượng pipe
    public Transform pipesChildDown; // Tham chiếu tới đối tượng pipe
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip Eatcoin,Dead, flyclip;
    int point = 0;
    [SerializeField]
    private TextMeshProUGUI textMeshPro;
    [SerializeField]
    private TextMeshProUGUI textMeshProPointED;
    [SerializeField]
    private TextMeshProUGUI textMeshProPointBest;
    public float distanceThreshold; // Ngưỡng khoảng cách, chỉnh sửa giá trị theo nhu cầu
    public float distanceThresholdPoint; // Ngưỡng khoảng cách, chỉnh sửa giá trị theo nhu cầu
    private bool hasGottenPoint = false;
    [SerializeField]
    private GameObject pnEG;
    private float ground;
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        pnEG.SetActive(false);
        isDead = false;
        ground = -3.9f;
        audioSource = GetComponent<AudioSource>();
        Debug.Log("Trên"+pipesChildUp.transform.position + " " + "Dưới "+pipesChildDown.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
           audioSource.PlayOneShot(flyclip);
        }
        
        if (birdTransform.position.y < ground)
        {
            //gọi hàm một lần khi chạm đất
            if (!isDead)
            {
                EndGame();
            }


        }
        foreach (Transform pipeTransform in pipes)
        {
            //vị trí từ chim tới cột
            float distancex = Mathf.Abs(pipeTransform.position.x - birdTransform.position.x);
            //ngưỡng chạm trên và dưới
            float tren = 1.4f + pipeTransform.transform.position.y;
            float duoi = -0.99f + pipeTransform.transform.position.y;
            if (distancex <= distanceThreshold)
            {
                
                if (birdTransform.position.y >= tren || birdTransform.position.y <= duoi)
                {
                    Debug.Log("Đã chạm");
                    if (!isDead)
                    {
                    EndGame();

                    }

                }
                //ngưỡng cộng điểm
                if(distancex <= distanceThresholdPoint)
                {
                    if (!hasGottenPoint)
                    {
                        StartCoroutine(CallGetPointCoroutine());
                    }
                }
                

            }
           

        }
        

    }
    private void GetPoint()
    {
        point++;
        textMeshPro.text = "Point:" + point;
        audioSource.PlayOneShot(Eatcoin);
    }
    IEnumerator CallGetPointCoroutine()
    {
        hasGottenPoint = true;
        GetPoint();
        yield return new WaitForSeconds(1f); // Đợi một khoảng thời gian ngắn trước khi reset biến hasGottenPoint
        hasGottenPoint = false;
    }
    private void EndGame()
    {
        isDead = true;
        Time.timeScale = 0;
        audioSource.PlayOneShot(Dead);
        pnEG.SetActive(true);
        textMeshProPointED.text = "Your Point:" + point;
        if (point > GameManageStart.instance.GetPoint())
        {
            GameManageStart.instance.SetPoint(point);
        }
        textMeshProPointBest.text = "Best Point:" + GameManageStart.instance.GetPoint();
    }
    public void Restart()
    {
         SceneManager.LoadScene(1);
         Time.timeScale = 1;
    }
}
