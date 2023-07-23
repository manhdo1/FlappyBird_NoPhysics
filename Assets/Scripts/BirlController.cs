
using UnityEngine;

public class BirlController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float downBird;
    [SerializeField]
    //private AudioClip flyclip;
    //private AudioSource audioSource;
 
    bool isFlying = false; // Biến cờ kiểm tra xem chim đang bay hay không
    float targetY; // Vị trí y mục tiêu khi bay
    [SerializeField]
    private float flySpeed; // Tốc độ bay của chim
    [SerializeField]
    private float location; // vị trí cuối
    GameObject obj;
    void Start()
    {
        obj = gameObject;
        //audioSource = obj.GetComponent<AudioSource>();
        //audioSource.clip = flyclip;
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("bay");
                StartFlying();
            }

        if (isFlying == false)
        {
        _DownBird();
        _FaceUpDown();
        }
        _FlyBird();
    

    }
    
    void _DownBird() 
    {
        Vector3 posdown = transform.position;
        posdown.y -= downBird * Time.deltaTime ;
        transform.position = posdown;
      
    }
    void _FlyBird() 
    {
        if (isFlying) // Nếu chim đang bay
        {
            // Nếu vị trí y của chim vẫn chưa đạt được vị trí cần đến (targetY)
            if (transform.position.y < targetY)
            {
                // Tính toán vị trí mới của chim dựa vào tốc độ bay
                Vector3 pos = transform.position;
                pos.y += flySpeed * Time.deltaTime;
                transform.position = pos;
            }
            else
            {
                // Nếu đã đạt được vị trí cần đến, dừng việc bay và đặt lại biến
                isFlying = false;
            }
        }

        //Vector3 pos = transform.position;
        //pos.y += flyBird * Time.deltaTime;
        //transform.position = pos;
    }
    void StartFlying()
    {
        if (!isFlying)
        {
            isFlying = true;
            targetY = transform.position.y + location ; // Đặt vị trí cần đến
        }
        
    }
    void _FaceUpDown()
    {
        if (transform.position.y > 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, 90, transform.position.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);

        }
        else if (transform.position.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (transform.position.y < 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, -45, -transform.position.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
    }
   
}
