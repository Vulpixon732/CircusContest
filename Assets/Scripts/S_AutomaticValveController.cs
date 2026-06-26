using TMPro;
using UnityEngine;

public class S_AutomaticValveController : S_ValveController
{
    public TextMeshPro powerText;
    public TextMeshPro duckText;

    public float secondsPerRotation = 60.0f;
    private float powerLeft = 0f;

    public float secondsPerDuck = 10.0f;
    private float duckCooldown;

    protected override void Start()
    {
        base.Start();
        duckCooldown = secondsPerDuck;
        UpdateTimer();
    }

    protected override void Update()
    {
        base.Start();
        if (powerLeft > 0f)
        {
            duckCooldown -= Time.deltaTime;
            if(duckCooldown <= 0f)
            {
                duckCooldown = secondsPerDuck - duckCooldown;
                spawner.GetComponent<S_DuckSpawn>().Spawn();
            }
            powerLeft -= Time.deltaTime;
            if (powerLeft < 0f)
            {
                powerLeft = 0f;
            }

            UpdateTimer();
        }
    }

    protected override void RotationTrigger()
    {
        travelDistance.y = travelDistance.y - 360;
        //Debug.Log("Debug: Override succesfull");
        powerLeft += secondsPerRotation;
    }

    private void UpdateTimer()
    {
        int powerMinutes = (int)(powerLeft / 60f);
        string powerMinutesText = powerMinutes.ToString();
        if(powerMinutes < 10)
        {
            powerMinutesText = "0" + powerMinutesText;
        }
        int powerSeconds = (int)(powerLeft - (powerMinutes * 60f));
        string powerSecondsText = powerSeconds.ToString();
        if (powerSeconds < 10)
        {
            powerSecondsText = "0" + powerSecondsText;
        }
        string power = powerMinutesText + ":" + powerSecondsText;

        int cdMinutes = (int)(duckCooldown / 60f);
        string cdMinutesText = cdMinutes.ToString();
        if (cdMinutes < 10)
        {
            cdMinutesText = "0" + cdMinutesText;
        }
        int cdSeconds = (int)(duckCooldown - (cdMinutes * 60f));
        string cdSecondsText = cdSeconds.ToString();
        if (cdSeconds < 10)
        {
            cdSecondsText = "0" + cdSecondsText;
        }
        string cooldown = cdMinutesText + ":" + cdSecondsText;

        powerText.text = "[P] " + power;
        duckText.text = "[D] " + cooldown;
    }
}
