using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class TaskManager : MonoBehaviour
{

    [SerializeField] private Toggle ClotherTask;
    [SerializeField] private Toggle RatingBookTask;
    [SerializeField] private Toggle KeyTask;
    [SerializeField] private Toggle ClassRoomTask;
    [SerializeField] private Toggle WorkTask;
    [SerializeField] private Canvas endCanvas;

    [SerializeField] private UnityEngine.UI.Text message;

    private Dictionary<string, Toggle> tasks = new Dictionary<string, Toggle>();

    // Start is called before the first frame update
    void Start()
    {
        message.text = "";
        endCanvas.enabled = false;
        tasks.Add("ClotherZone", ClotherTask);
        tasks.Add("RatingBookZone", RatingBookTask);
        tasks.Add("KeyZone", KeyTask);
        tasks.Add("ClassRoomZone", ClassRoomTask);
        tasks.Add("WorkZone", WorkTask);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        message.text = "";
        if (tasks.ContainsKey(other.tag)) 
        {
            if (other.tag == "ClassRoomZone" && tasks.GetValueOrDefault("KeyZone").isOn == false)
            {
                message.text = "Вы не взяли ключ!";
            }
            else if (other.tag == "WorkZone" && tasks.GetValueOrDefault("RatingBookZone").isOn == false)
            {
                message.text = "Вы не взяли журнал!";
            }
            else
            {
                tasks.GetValueOrDefault(other.tag).isOn = true;
            }
        }

        bool isEnd = true;
        foreach (var task in tasks.Values) 
        {
            if (!task.isOn) 
            {
                isEnd = false;
            }
        }

        if (isEnd)
        {
            message.text = "Вы начали урок вовремя!";
            Time.timeScale = 0;
            endCanvas.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        message.text = "";
    }
}
