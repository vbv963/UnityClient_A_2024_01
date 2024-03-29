using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExCharacter : MonoBehaviour
{
    public float speed = 5f;    //캐릭터 이동 속도

    // Update is called once per frame
    void Update()
    {
        Move();         //프레임마다 Move 함수 호출
    }

    protected virtual void Move()        //virtual 키워드를 작성하여 상속
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    public void DestoryCharacter()     //캐릭터 파괴
    {
        Destroy(gameObject);
    }
}
