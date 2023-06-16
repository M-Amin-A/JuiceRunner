using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private float speed = 10f;
    public Transform cameraTransform;
    public Transform sampleGroundTransform;
    public GameObject sampleParticleSystem;
    public AudioSource audioSource;

    public GameObject gameDataObject;
    private GameData gameData;

    public float leftLimit;
    public float rightLimit;

    private bool isBlinking = false;

    void Start()
    {
        leftLimit = -sampleGroundTransform.localScale.x / 2f + 1f;
        rightLimit = sampleGroundTransform.localScale.x / 2f - 1f;

        gameData = gameDataObject.GetComponent<GameData>();
    }

    void Update()
    {
        if (gameData.gameFinished) return;

        checkKeyPress();
        checkTouchInput();

        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        cameraTransform.position += new Vector3(0, 0, speed * Time.deltaTime);
    }

    private void checkTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 characterNewPosition = new Vector3(touch.deltaPosition.x / 100.0f, 0, 0) + transform.position;
                if (characterNewPosition.x < leftLimit)
                    transform.position = new Vector3(leftLimit, transform.position.y, transform.position.z);
                else if (characterNewPosition.x > rightLimit)
                    transform.position = new Vector3(rightLimit, transform.position.y, transform.position.z);
                else
                    transform.position = characterNewPosition;
            }
        }
    }

    private void checkKeyPress()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-0.5f, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(0.5f, 0, 0));
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Fruit")
        {
            if (isBlinking)
                return;

            audioSource.Play();

            if (gameData.fruitClaim(collider.gameObject.GetComponent<SampleFruitsType>().fruitType))
            {
                GameObject particleSystem = Instantiate(sampleParticleSystem, cameraTransform);
                ParticleSystem.MainModule main = particleSystem.GetComponent<ParticleSystem>().main;
                main.startColor = FruitGenerator.getColorOfFruitType(collider.gameObject.GetComponent<SampleFruitsType>().fruitType);

                particleSystem.SetActive(true);

                collider.gameObject.SetActive(false);
            }
            else
            {
                isBlinking = true;
                GetComponent<Animator>().SetTrigger("startBlinking");
                Handheld.Vibrate();
                StartCoroutine(stopBlinking(3f)) ;
            }
        }
    }

    private IEnumerator stopBlinking(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isBlinking = false;
        GetComponent<Animator>().SetTrigger("pauseBlinking");
        Material material = GetComponent<MeshRenderer>().material;
        GetComponent<MeshRenderer>().material.color = new Color(material.color.r, material.color.g, material.color.b, 1);
    }
}
