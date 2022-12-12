using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : IPlayer
{
    public Player2(List<GameObject> maplist) : base(maplist)
    {
    }

    public override void Move(int hongfang)
    {
        base.Move(hongfang);
    }

    public override void Triggertrap()
    {
        base.Triggertrap();
    }
}
