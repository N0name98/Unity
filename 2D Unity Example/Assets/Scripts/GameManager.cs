using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int totalPoint;
    public int stagePoint;
    public int stageIndex;
    public int health = 3;
    public PlayerMove player;
    public GameObject[] Stages;
    public Image[] UIhealth;
    public Text UIPoint;
    public Text UIStage;
    public GameObject UIRestartButton;

    void Update()
    {
        UIPoint.text = (totalPoint + stagePoint).ToString();
    }

    public void NextStage()
    {
        if (stageIndex < Stages.Length - 1)
        {
            Stages[stageIndex].SetActive(false);
            stageIndex++;
            Stages[stageIndex].SetActive(true);
            PlayerReposition();

            UIStage.text = "STAGE " + (stageIndex + 1);
        }
        else
        {
            Time.timeScale = 0;
            UIRestartButton.SetActive(true);
            Text btnText = UIRestartButton.GetComponentInChildren<Text>();
            btnText.text = "Clear!";
            ViewBtn();
        }


        totalPoint += stagePoint;
        stagePoint = 0;
    }
    public void HealthDown()
    {
        if (health > 1)
        {
            health--;
            UIhealth[health].color = new Color(1, 1, 1, 0.2f);
        }
        else
        {
            UIhealth[0].color = new Color(1, 1, 1, 0.2f);

            player.OnDie();
            Debug.Log("Dead");
            UIRestartButton.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (health > 1)
            {
                other.attachedRigidbody.velocity = Vector2.zero;
                other.transform.position = new Vector3(-9.5f, -4.5f, 0);
            }
            HealthDown();
        }
    }
    void PlayerReposition()
    {
        player.transform.position = new Vector3(-9.5f, -4.3f, 0);
        player.VelocityZero();
    }
    void ViewBtn()
    {
        UIRestartButton.SetActive(true);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
