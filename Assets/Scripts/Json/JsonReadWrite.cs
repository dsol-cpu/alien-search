using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

public class JsonReadWrite
{
    public static List<UFOSighting> jsonHolder;

    public List<UFOSighting> DeserializeToMap(string fileName){
        string jsonString = File.ReadAllText(fileName);
        jsonHolder = JsonConvert.DeserializeObject<List<UFOSighting>>(jsonString);
        return jsonHolder;
    }

    public void SerializeToJson()
    {
        string jsonFile = "";
        foreach (UFOSighting item in jsonHolder) {
            jsonFile += JsonConvert.SerializeObject(item);
        }
        /*SaveFileDialog saveFileDialog = new SaveFileDialog();

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            File.WriteAllText(saveFileDialog.FileName,jsonFile);
            MessageBox.Show("Save Complete!");
        }*/

    }
}
