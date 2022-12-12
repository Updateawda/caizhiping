using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCommand : ICommand
{
    public override void Execute(params object[] date)
    {
        IcharacterFactory icharacterFactory = IFactory.GetIcharacterFactory();
        icharacterFactory.CreatPlay(date);
    }

    
}
