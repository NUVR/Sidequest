using GoogleARCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationTracker : MonoBehaviour
{
    [SerializeField]
    public int MaxLocationServiceWait = 20;

    // Start is called before the first frame update
    void Start()
    {
        RequestLocationPermission();
        StartCoroutine(LocationGetter());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator LocationGetter()
    {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            Debug.LogError("No location service found");
            yield break;
        }
        else if (Input.location.status != LocationServiceStatus.Running)
        {
            Debug.Log("Starting...");
        }

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        while (Input.location.status == LocationServiceStatus.Initializing && MaxLocationServiceWait > 0)
        {
            yield return new WaitForSeconds(1);
            MaxLocationServiceWait--;
        }

        // Service didn't initialize
        if (MaxLocationServiceWait < 1)
        {
            Debug.LogError("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.LogError("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            Debug.Log("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
        }

        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();
    }

    void RequestLocationPermission()
    {
        AndroidPermissionsManager.RequestPermission("android.permission.ACCESS_FINE_LOCATION");
    }
}
