using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : IPlayer
{
    public Player1(List<GameObject> maplist) : base(maplist)
    {
    }

    public override void Move(int lanfang)
    {
        base.Move(lanfang);
    }

    public override void Triggertrap()
    {
        base.Triggertrap();
    }
}
