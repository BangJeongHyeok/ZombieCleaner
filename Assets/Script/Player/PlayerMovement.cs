using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    GameObject Sound;
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    bool isJumped = false;
    private Vector3 moveDirection = Vector3.zero;

    public static CharacterController controller;

    //마우스래
    public float upDownRange = 90;
    public float mouseSensitivity = 2f;
    private float rotLeftRight;
    private float rotUpDown;
    private float verticalRotation = 0f;
    private float verticalVelocity = 0f;
    public GameObject flashLight;
    private GameObject Body;
    private int A = 0;

    // Start is called before the first frame update
    void Start()
    {
        Sound = GameObject.Find("SFXPlayer");
        Body = gameObject.transform.GetChild(0).transform.GetChild(0).gameObject;
        //Cursor.lockState = CursorLockMode.Locked;//커서를 중앙으로 잠금
        Cursor.visible = false;//커서를 보이게 함
        controller = GetComponent<CharacterController>();
        //flashLight = gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(4).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        FPRotate();//마우스회전
        Move();
        Flash();

        if(moveDirection.x != 0 && moveDirection.y != 0)
        {
            if (!Sound.GetComponent<AudioSource>().isPlaying && controller.isGrounded)
                Sound.GetComponent<SFXManager>().SoundManager_F("FootStep");

            StartCoroutine("moving");
        }
            
    }

    void FPRotate()
    {
        //좌우 회전
        rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0f, rotLeftRight, 0f);

        //상하 회전
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }


    void Move()
    {

        if (Input.GetKeyDown(KeyCode.Escape))//ESC누르면
            SceneManager.LoadScene("Title");//타이틀화면으로 돌아옴
        
        if (controller.isGrounded)
        {
            if (isJumped)
            {
                Sound.GetComponent<SFXManager>().SoundManager_F("Jump");
                //Debug.Log("1");
                isJumped = false;
            }
                

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetKeyDown(KeyCode.LeftShift))
                moveDirection *= speed * 3f;//스프린트
            else
                moveDirection *= speed;//걍 달리기

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
                isJumped = true;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void Flash()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!flashLight.activeSelf)
                flashLight.SetActive(true);
            else if (flashLight.activeSelf)
                flashLight.SetActive(false);
        }
    }

    IEnumerator moving()//걷기 애니메이션
    {

        if (A <= 9)
        {
            Body.transform.localPosition = Vector3.down * 0.01f + Body.transform.localPosition;
            A++;
        }
        else if (19 >= A && A >= 10)
        {
            Body.transform.localPosition = Vector3.up * 0.01f + Body.transform.localPosition;
            A++;
        }
        else if (A >= 20)
        {
            A = 0;
        }
        yield return null;
    }
}