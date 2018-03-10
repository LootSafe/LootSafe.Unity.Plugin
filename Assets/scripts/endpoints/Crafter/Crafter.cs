using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafter {

    private string apiUrl;
    private string apiKey;
    private string ethAcc;

    /* Private Constructor */

    private Crafter(){}

    /* Public Constructor */

    public Crafter(string apiUrl, string apiKey, string ethAcc)
    {
        this.apiUrl = apiUrl;
        this.apiKey = apiKey;
        this.ethAcc = ethAcc;
    }

    /* Methods */

    private string getCraftables()
    {
        return "";
    }

    private string getDeconstructables()
    {
        return "";
    }

    private string getDeconstructionRecipe()
    {
        return "";
    }

    private string getRecipe()
    {
        return "";
    }
}
