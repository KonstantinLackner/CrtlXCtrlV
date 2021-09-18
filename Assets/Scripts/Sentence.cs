using System;
using System.Collections.Generic;
using DefaultNamespace;

public class Sentence
{
    public String original { get; }
    public LinkedList<Variation> variations { get; set; }
    
    public Sentence(String original)
    {
        this.original = original;
    }
    public Variation CheckIfStringIsVariation(String potentialVariation)
    {
        Variation returnVariation = null;
        
        foreach (Variation variation in variations)
        {
            if (variation.sentence.Equals(potentialVariation))
            {
                returnVariation = variation;
                break;
            }
        }

        return returnVariation;
    }

    /**
     * Gets the respective level the variation leads to
     * Only called after the String has been approved as variation
     */
    public Level FetchRespectiveLevel(String variationString)
    {
        Level nextLevel = null;
        
        foreach (Variation variation in variations)
        {
            if (variation.sentence.Equals(variationString))
            {
                nextLevel = variation.leadsTo;
            }
        }

        if (nextLevel == null)
        {
            throw new Exception("Couldn't find variation");
        }

        return nextLevel;
    }
}
