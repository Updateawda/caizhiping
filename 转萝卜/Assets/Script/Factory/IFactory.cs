using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IFactory
{
    public static IcharacterFactory icharacterFactory = null;

    public static IcharacterFactory GetIcharacterFactory()
    {
        if (icharacterFactory==null)
        {
            icharacterFactory = new characterFactory();
        }
        return icharacterFactory;
    }
}
