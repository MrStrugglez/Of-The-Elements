using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectState : MonoBehaviour
{
    [SerializeField]
    private int coinNumber;

    [SerializeField]
    private int barrelNumber;

    [SerializeField]
    private int chestNumber;

    [SerializeField]
    private int keyNumber;

    [SerializeField]
    private bool isCrate;

    [SerializeField]
    private bool isPlayer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isCrate)
        {
            LEVEL_DATA_STORE.Level1_3Crate1Pos = transform.position;
        }

        if (isPlayer)
        {
            LEVEL_DATA_STORE.Level1_3PlayerPos = transform.position + new Vector3(0, 1, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (SceneManager.GetActiveScene().name == "Level1_3")
            {
                switch (coinNumber)
                {
                    case 1:
                        LEVEL_DATA_STORE.Level1_3Coin1Taken = true;
                        break;
                    case 2:
                        LEVEL_DATA_STORE.Level1_3Coin2Taken = true;
                        break;
                    case 3:
                        LEVEL_DATA_STORE.Level1_3Coin3Taken = true;
                        break;
                    case 4:
                        LEVEL_DATA_STORE.Level1_3Coin4Taken = true;
                        break;
                    default:
                        break;
                }
            }
            else if (SceneManager.GetActiveScene().name == "Level1_3_Cave")
            {
                if (coinNumber == 1)
                {
                    LEVEL_DATA_STORE.Level1_3_CaveCoin1Taken = true;
                }
                else if (keyNumber == 1)
                {
                    LEVEL_DATA_STORE.Level1_3_CaveKey1Taken = true;
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            switch (barrelNumber)
            {
                case 1:
                    LEVEL_DATA_STORE.Level1_3Barrel1Sprite = GetComponent<SpriteRenderer>().sprite;
                    break;
                case 2:
                    LEVEL_DATA_STORE.Level1_3Barrel2Sprite = GetComponent<SpriteRenderer>().sprite;
                    break;
                default:
                    break;
            }

            switch (chestNumber)
            {
                case 1:
                    LEVEL_DATA_STORE.Level1_3Chest1Sprite = GetComponent<SpriteRenderer>().sprite;
                    break;
                default:
                    break;
            }
        }
    }
}
