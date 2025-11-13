using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.InputSystem.Controls;

public class PlayerMov : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    [SerializeField] public int Item = 0;
    [SerializeField] public int Vida = 100;
    [SerializeField] public float posX = 0;
    [SerializeField] public float posY = 0;
    [SerializeField] public float posZ = 0;
    [SerializeField] public float timer = 5f;
    [SerializeField] public bool timerActive = false;
    public GameObject autoSave;
    public TextMeshProUGUI textoVida;
    public TextMeshProUGUI textoItem;
    public TextMeshProUGUI textoPosx;
    public TextMeshProUGUI textoPosy;
    public TextMeshProUGUI textoPosz;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(horizontal, vertical);

        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;

        //if (Input.GetKeyDown(KeyCode.Escape) && UI)
        //{
        //    UI.SetActive(true);
        //}

        //if (Input.GetKeyUp(KeyCode.Escape) && UI == true)
        //{
        //    UI.SetActive(false);
        //}

        #region UI
        if (textoVida)
        {
            textoVida.text = Vida.ToString();
        }

        if (textoItem)
        {
            textoItem.text = Item.ToString();
        }

        if (textoPosx)
        {
            textoPosx.text = posX.ToString();
        }

        if (textoPosy)
        {
            textoPosy.text = posY.ToString();
        }

        if (textoPosz)
        {
            textoPosz.text = posZ.ToString();
        }

        if (timerActive == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                autoSave.SetActive(false);
                timerActive = false;
                timer = 5;
            }
        }

        #endregion


    }
    private void FixedUpdate()
    {
        Vector3 movePosition = (speed * Time.fixedDeltaTime * moveDirection.normalized) + rb.position;
        rb.MovePosition(movePosition);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            Item++;
            Vida -= 5;


            Object.Destroy(collision.gameObject);

            autoSave.SetActive(true);
            timerActive = true;
        }
        

    }

    
}
