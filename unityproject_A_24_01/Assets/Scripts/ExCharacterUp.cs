using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExCharacterUp : ExCharacter
{
    //override 키워드를 사용하여 함수 다시 정의

    protected override void Move() 
     {
         base.Move();
         transform.Translate(
           Vector3.forward * speed * 2
           * Time.deltaTime);
     }
}
