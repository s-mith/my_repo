using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// import stuff to make api calls
using System.Net;
using System.IO;
using System.Text;
using System;





public class leader1 : MonoBehaviour
{
    public InputField nameField;
    public Text scoreText;
    public Text highScoreText;
    public Button submitButton;


    // api key 
    string apiKey = "keyaNmxEUc07T06NJ";
    // get top 10 scores from the airtable api
    public void scores(){
        // create a web request
        // sort it by score in descending order
        WebRequest request = WebRequest.Create("https://api.airtable.com/v0/applMsIlSGEvMgzeZ/Table%201?api_key=keyaNmxEUc07T06NJ&sort%5B0%5D%5Bfield%5D=score&sort%5B0%5D%5Bdirection%5D=desc");
        // set the method to get
        request.Method = "GET";
        // get the response
        WebResponse response = request.GetResponse();
        // get the response stream
        Stream dataStream = response.GetResponseStream();
        // create a reader
        StreamReader reader = new StreamReader(dataStream);
        // read the response
        string responseFromServer = reader.ReadToEnd();
        // print the response
        Debug.Log(responseFromServer);
        // close the reader
        reader.Close();
        // close the response
        response.Close();
        
        // parse the json
        // make a list split on {"score":
        List<string> scoresList = new List<string>(responseFromServer.Split(new string[] {"{\"score\":"}, StringSplitOptions.None));
        //remove the first element
        scoresList.RemoveAt(0);
        // remove everything after "}}
        for (int i = 0; i < scoresList.Count; i++)
        {
            scoresList[i] = scoresList[i].Split(new string[] {"}}"}, StringSplitOptions.None)[0];
        }
        // remove quotes
        for (int i = 0; i < scoresList.Count; i++)
        {
            scoresList[i] = scoresList[i].Replace("\"", "");
        }

        // split on ,Name:
        // list of lists of strings
        for (int i = 0; i < scoresList.Count; i++)
        {
            List<string> temp = new List<string>(scoresList[i].Split(new string[] {",Name:"}, StringSplitOptions.None));
            scoresList[i] = temp[1]+": "+temp[0];
        }

        // add the scores to the high score text in the format "name: score"
        string highScoreString = "";
        for (int i = 0; i < scoresList.Count; i++)
        {
            highScoreString += scoresList[i];
            if (i < scoresList.Count - 1){
                highScoreString += "\n";
            }
        }
        highScoreText.text = highScoreString;





        

        
    }

    public void Start() {
        // get the score from static variable in bulletselfdestroy script
        scoreText.text = BulletSelfDestroy.scoreValue.ToString();
        // call the scores function
        scores();
        // add a listener to the submit button
        submitButton.onClick.AddListener(submit);
    }

    // post a new score to the airtable api
    public void submit(){
        //check if the name only has numbers and letters
        if (System.Text.RegularExpressions.Regex.IsMatch(nameField.text, "^[a-zA-Z0-9]*$"))
        {
            Debug.Log("Name contains invalid characters");
            
        

        // create a web request
        WebRequest request = WebRequest.Create("https://api.airtable.com/v0/applMsIlSGEvMgzeZ/Table%201?api_key=keyaNmxEUc07T06NJ");
        // set the method to post
        request.Method = "POST";
        // set the content type
        request.ContentType = "application/json";
        // get the score from the score text
        string score = scoreText.text;
        // get the name from the name field
        string name = nameField.text;
        // create a json string
        string json = "{\"fields\": {\"Name\": \""+name+"\", \"score\": "+score+"}}";
        // convert the json string to bytes
        byte[] byteArray = Encoding.UTF8.GetBytes(json);
        // set the content length
        request.ContentLength = byteArray.Length;
        // get the request stream
        Stream dataStream = request.GetRequestStream();
        // write the json to the request stream
        dataStream.Write(byteArray, 0, byteArray.Length);
        // close the request stream
        dataStream.Close();
        // get the response
        WebResponse response = request.GetResponse();
        // get the response stream
        dataStream = response.GetResponseStream();
        // create a reader
        StreamReader reader = new StreamReader(dataStream);
        // read the response
        string responseFromServer = reader.ReadToEnd();
        // print the response
        Debug.Log(responseFromServer);
        // close the reader
        reader.Close();
        // close the response
        response.Close();
        // call the scores function
        scores();
        Application.LoadLevel("titleScreen");
        }

        if (nameField.text == ""){
            Application.LoadLevel("titleScreen");
        }
        
    }

}
