using UnityEngine;
using System;
using System.IO;

#region Serializable class position
[Serializable]
public class PositionSave
{
    public Vector3 result = new Vector3(0,0,0);
}
#endregion

public class CheckPoint : MonoBehaviour 
{
   
    #region Public Variables

    /// <summary>
    /// Indicate if the checkpoint is activated
    /// </summary>
    public bool Activated = false;

    #endregion

    #region Private Variables
    private static PositionSave ps = new PositionSave();
    private Animator thisAnimator;
    private string path;

    #endregion

    #region Static Variables

    /// <summary>
    /// List with all checkpoints objects in the scene
    /// </summary>
    public static GameObject[] CheckPointsList;

    #endregion

    #region Static Functions
    
    /// <summary>
    /// Get position of the last activated checkpoint
    /// </summary>
    /// <returns></returns>
    public static PositionSave GetActiveCheckPointPosition()
    {
        // If player die without activate any checkpoint, we will return a default position
        // Vector3  result = new Vector3(0, 0, 0);

          
        if (CheckPointsList != null)
        {
            foreach (GameObject cp in CheckPointsList)
            {
                // We search the activated checkpoint to get its position
                if (cp.GetComponent<CheckPoint>().Activated)
                {
                   // result = cp.transform.position;
                   ps.result = cp.transform.position;
                    Debug.Log("CheckPoint Position" + ps.result);
                    break;
                }
            }
        }

        return ps;
    }

    #endregion

    #region Private Functions

    /// <summary>
    /// Activate the checkpoint
    /// </summary>
    private void ActivateCheckPoint()
    {
        // We deactive all checkpoints in the scene
        foreach (GameObject cp in CheckPointsList)
        {
            cp.GetComponent<CheckPoint>().Activated = false;
            cp.GetComponent<Animator>().SetBool("Active", false);
            
        }

        // We activated the current checkpoint
        Activated = true;
        thisAnimator.SetBool("Active", true);
    }

    #endregion
 
    void Awake()
    {
        thisAnimator = GetComponent<Animator>();
        GameObject player = GameObject.Find("Player");
        // We search all the checkpoints in the current scene
        CheckPointsList = GameObject.FindGameObjectsWithTag("CheckPoint");
        GameObject startpos = GameObject.Find("StartPosition");
        //SaveJSON
        path = Path.Combine(Application.dataPath, "Save.json");
        if (File.Exists(path))
        {
            ps = JsonUtility.FromJson<PositionSave>(File.ReadAllText(path));
            player.transform.position = ps.result;
           
        }
        else
            player.transform.position = startpos.transform.position;

    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Application.Quit();
    }
    void OnTriggerEnter(Collider other)
    {
        // If the player passes through the checkpoint, we activate it
        if (other.tag == "Player")
        {
            ActivateCheckPoint();
            ps.result = transform.position;
            Debug.Log("Trigger Position is" + ps.result);
        }
    }
    private void OnApplicationQuit()
    {
        Debug.Log("Quit Positiont is" + ps.result);
        File.WriteAllText(path, JsonUtility.ToJson(ps));
        Debug.Log("Write all text");

    }
}
