using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class RenderObject : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour trackableBehav;
    public Transform[] myPrefab = new Transform[9];
    private Dictionary<string, int> prefabs;
    private string buttonClicked;
    // Use this for initialization
    void Start () {
        InitPrefabs();
        buttonClicked = PlayerPrefs.GetString("clickedButton");
        trackableBehav = GetComponent<TrackableBehaviour>();
        if (trackableBehav)
        {
            trackableBehav.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
    TrackableBehaviour.Status previousStatus,
    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
    }
    private void OnTrackingFound()
    {
        if (myPrefab[prefabs[buttonClicked]] != null)
        {
            Transform myModelTrf = GameObject.Instantiate(myPrefab[prefabs[buttonClicked]]) as Transform;
            myModelTrf.parent = trackableBehav.transform;
            myModelTrf.localPosition = new Vector3(0f, 0f, 0f);
            myModelTrf.localRotation = Quaternion.identity;
            myModelTrf.localScale = new Vector3(2f, 2f, 2f);
            myModelTrf.gameObject.SetActive(true);
        }
    }
// Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("buttonDemo");
        }

    }

    public void InitPrefabs()
    {
        prefabs = new Dictionary<string, int>();
        prefabs.Add("Armchair", 0);
        prefabs.Add("Bed", 1);
        prefabs.Add("Chair", 2);
        prefabs.Add("Coffee Table", 3);
        prefabs.Add("Door", 4);
        prefabs.Add("Lamp", 5);
        prefabs.Add("Table", 6);
        prefabs.Add("TV", 7);

    }
}
