using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLoader : MonoBehaviour
{
    private bool inExitZone;
    public string levelToLoad;
    public bool isLevelSelectDoor;
    public int doorNumber;

    // Start is called before the first frame update
    void Start()
    {
        inExitZone = false;
        if (isLevelSelectDoor)
        {
            LevelManager levelManager = FindObjectOfType<LevelManager>();
            if (doorNumber==2 && !levelManager.enabledLevel2)
            {
                gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.W) && inExitZone)
        {
            if (!isLevelSelectDoor)
            {
                LevelManager levelManager = FindObjectOfType<LevelManager>();
                if (doorNumber == 1)
                {
                    levelManager.enabledLevel2 = true;
                }
            }
            SceneManager.LoadSceneAsync(levelToLoad);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            inExitZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            inExitZone = false;
        }
    }
}
