using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{

    public GameObject ActiveLeader;
    public GameObject TargetSeat;
    public GameObject MainMenuUI;
    public GameObject LevelCompleteUI;
    public GameObject ActivatedCapsule;
    private GameObject[] blueArray; private GameObject[] greenArray; private GameObject[] orangeArray; private GameObject[] capsuleArray; private GameObject[] redArray; private GameObject[] purpleArray;
    private GameObject[] pinkArray;
    private int capsulesDone;
    private int capsulesNeededDone;
    private bool LevelCompleted;
    public Text leveltext;
    public AudioSource levelCompleteSound;
    private bool isLevelCompleteSoundPlayed;

    // . . game loading functions
    public void startActivescene()
    {
        MainMenuUI.SetActive(false);
        LevelCompleteUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    private void levelCompleted()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            LevelCompleteUI.SetActive(true);
            if (!isLevelCompleteSoundPlayed)
            {
                levelCompleteSound.Play();
                isLevelCompleteSoundPlayed = true;
            }
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }


    // . . level complete trigger

    private void Start()
    {
        capsuleArray = GameObject.FindGameObjectsWithTag("Tiles");
        capsulesNeed();
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            leveltext.text = SceneManager.GetActiveScene().name;
        }
        isLevelCompleteSoundPlayed = false;
    }

    private void Update()
    {
        capsulesCompleted(capsuleArray);
    }

    private void capsulesNeed()
    {
        // . . this function calculates how many capsules needs to be done in order to trigger levelcompleted
        capsulesNeededDone = 0;
        blueArray = GameObject.FindGameObjectsWithTag("BlueGuys");
        if (blueArray.Length > 0)
        {
            capsulesNeededDone++;
        }
        greenArray = GameObject.FindGameObjectsWithTag("GreenGuys");
        if (greenArray.Length > 0)
        {
            capsulesNeededDone++;
        }
        orangeArray = GameObject.FindGameObjectsWithTag("OrangeGuys");
        if (orangeArray.Length > 0)
        {
            capsulesNeededDone++;
        }
        redArray = GameObject.FindGameObjectsWithTag("RedGuys");
        if (redArray.Length > 0)
        {
            capsulesNeededDone++;
        }
        purpleArray = GameObject.FindGameObjectsWithTag("PurpleGuys");
        if (purpleArray.Length > 0)
        {
            capsulesNeededDone++;
        }
        pinkArray = GameObject.FindGameObjectsWithTag("PinkGuys");
        if (pinkArray.Length > 0)
        {
            capsulesNeededDone++;
        }
    }

    private void capsulesCompleted(GameObject[] capsuleArr)
    {
        foreach (GameObject obj in capsuleArr)
        {
            if (obj.GetComponent<CapsuleController>().capsuleDone)
            {
                capsulesDone++;
            }
        }
        
        if (capsulesDone == capsulesNeededDone)
        {
            levelCompleted();
        }else
        {
            capsulesDone = 0;
        }
    }

    // . . game variable functions.

    public void Set_Leader(GameObject obj)
    {
        ActiveLeader = obj;
    }

    public GameObject Get_Leader()
    {
        return ActiveLeader;
    }

    public void Reset_Leader()
    {
        ActiveLeader = null;
    }


    public GameObject Set_ActivatedCapsule(GameObject obj)
    {
        ActivatedCapsule = obj;
        return ActivatedCapsule;
    }

    public GameObject Get_ActivatedCapsule()
    {
        return ActivatedCapsule;
    }

    public void Reset_ActivatedCapsule()
    {
        ActivatedCapsule = null;
    }

    public GameObject Set_Target(GameObject obj)
    {
        TargetSeat = obj;
        return TargetSeat;
    }

    public void Reset_Target()
    {
        TargetSeat = null;
    }

}
