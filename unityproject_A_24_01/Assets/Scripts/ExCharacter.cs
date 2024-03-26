using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExCharacter : MonoBehaviour
{
    public float speed = 5f;    //ĳ���� �̵� �ӵ�

    // Update is called once per frame
    void Update()
    {
        Move();         //�����Ӹ��� Move �Լ� ȣ��
    }

    protected virtual void Move()        //virtual Ű���带 �ۼ��Ͽ� ���
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    public void DestoryCharacter()     //ĳ���� �ı�
    {
        Destroy(gameObject);
    }
}
