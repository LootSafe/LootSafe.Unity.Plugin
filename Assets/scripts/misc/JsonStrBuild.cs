using System.Collections.Generic;

public class JsonStrBuild {

    /* Method */

    public string buildStr(Dictionary<string, string> dict)
    {
        string jsonStr = "{";

        int count = 0;

        foreach (var kv in dict){
            jsonStr += "\"" + kv.Key + "\":" + "\"" + kv.Value + "\"";

            if ((count + 1) != dict.Count)
                jsonStr += ",";

            ++count;
        }

        jsonStr += "}";

        return jsonStr;
    }

    /* Singleton */

    private static JsonStrBuild instance;
    private JsonStrBuild(){}
    public static JsonStrBuild Instance
    {
        get
        {
            if (instance == null)
                instance = new JsonStrBuild();
            return instance;
        }
    }
}
