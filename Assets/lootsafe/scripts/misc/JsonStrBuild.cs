using System.Collections.Generic;

public class JsonStrBuild {

    /* Method */

    public string buildStr(Dictionary<string, List<string>> dict)
    {
        string jsonStr = "{";

        int count = 0;

        foreach (var kv in dict){

            if (kv.Value.Count == 1)
                jsonStr += " \"" + kv.Key + "\" : " + "\"" + kv.Value[0] + "\"";
            else
                jsonStr += listStr(kv.Key, kv.Value);

            if ((count + 1) != dict.Count)
                jsonStr += " , ";

            ++count;
        }

        jsonStr += "}";

        return jsonStr;
    }

    private string listStr(string key, List<string> val)
    {
        string jsonSnippet = "\"" + key + "\" : [ ";

        for (int i = 0; i < val.Count; i++)
        {
            bool number = isNumber(val[i]);

            if (number)
                jsonSnippet += val[i];
            else
                jsonSnippet += "\"" + val[i] + "\"";

            if (i < val.Count - 1)
                jsonSnippet += " , ";

            if(i == val.Count - 1)
                jsonSnippet += " ";
        }

        jsonSnippet += "]";

        return jsonSnippet;
    }

    private bool isNumber(string val)
    {
        foreach (char c in val)
        {
            if (char.IsNumber(c) == false)
                if(c != '.')
                    return false;
        }

        return true;
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
