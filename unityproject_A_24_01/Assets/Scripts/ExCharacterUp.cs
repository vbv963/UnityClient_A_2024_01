using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExCharacterUp : ExCharacter
{
    //override Ű���带 ����Ͽ� �Լ� �ٽ� ����

    protected override void Move() 
     {
         base.Move();
         transform.Translate(
           Vector3.forward * speed * 2
           * Time.deltaTime);
     }
}
