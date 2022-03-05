using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    bool timerFinished = false;
    int numberOfAttackers = 0;

    // Update is called once per frame
    void Update()
    {
    }

    public void setTimerFinished()
    {
        timerFinished = true;
        StopAttackerSpawners();
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && timerFinished )
        {
            Debug.Log("End Level Now");
        }
    }

    private void StopAttackerSpawners()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }
}
