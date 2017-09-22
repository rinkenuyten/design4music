using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using LitJson;

public class FireBaseController : MonoBehaviour
{

    public GameManager gm;

    // Get the root reference location of the database.
    private DatabaseReference reference;

    // Use this for initialization
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://design4music-b0ca8.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        //Rood
        FirebaseDatabase.DefaultInstance.GetReference("users/00ffff")
            .ValueChanged += HandleValueChangedBlauw;

        FirebaseDatabase.DefaultInstance.GetReference("users/ff2640")
            .ValueChanged += HandleValueChangedRood;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void HandleValueChangedBlauw(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        //Debug.Log("args: " + args.Snapshot.GetRawJsonValue());

        string rawJSON = args.Snapshot.GetRawJsonValue();

        //string json = JsonUtility.ToJson(rawJSON);

        ProcessjsonBlauw(rawJSON);
        //if (JsonUtility.)
        // Do something with the data in args.Snapshot
    }

    void HandleValueChangedRood(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        //Debug.Log("args: " + args.Snapshot.GetRawJsonValue());

        string rawJSON = args.Snapshot.GetRawJsonValue();

        //string json = JsonUtility.ToJson(rawJSON);

        ProcessjsonRood(rawJSON);
        //if (JsonUtility.)
        // Do something with the data in args.Snapshot
    }

    void ProcessjsonBlauw(string jsonString)
    {

        JsonData jsonvale = JsonMapper.ToObject(jsonString);
        /* parsejson = new JSONDing();
         parsejson.rood = new kleur();
         parsejson.rood.Kleur = jsonvale["00ffff"].ToString();
         parsejson.rood.id = new id();

         parsejson.rood.id.waarde = new waarde();
         */

        //Blauw
        int blauw = 0;
        for (int i = 0; i < jsonvale.Count; i++)
        {
            if(jsonvale[i]["Waarden"].ToString() == "1")
            {
                blauw++;
            }
        }
        Debug.Log("blauw " + blauw);
        if (blauw > 0)
        {
           
            gm.JumpPlayer1(jsonvale.Count);
            blauw = 0;
        }

        //Rood
       


    }

    void ProcessjsonRood(string jsonString)
    {

        JsonData jsonvale = JsonMapper.ToObject(jsonString);
        /* parsejson = new JSONDing();
         parsejson.rood = new kleur();
         parsejson.rood.Kleur = jsonvale["00ffff"].ToString();
         parsejson.rood.id = new id();

         parsejson.rood.id.waarde = new waarde();
         */

        //Blauw
        int rood = 0;
        for (int j = 0; j < jsonvale.Count; j++)
        {
            if (jsonvale[j]["Waarden"].ToString() == "1")
            {
                rood++;
            }
        }
        Debug.Log("rood " + rood);
        if (rood > 0)
        {
            gm.JumpPlayer2(jsonvale.Count);
            rood = 0;


        }
    }


    /*
        {"00ffff":
        {"9":
        {"Waarden":0}},"ff2640":{"5":{"Waarden":0},"7":{"Waarden":0},"8":{"Waarden":0}}}
   */
}
