using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExParentClass : MonoBehaviour  //��� : ����Ƽ ������Ʈ���� �����ϰ�
{
    //protected�� ����� ������ ���� Ŭ���� �� �Ļ� Ŭ�������� ���� ����
    protected int protectedValue;
}

public class ExChildClass : ExParentClass  //ExParentClass�� ���
{
    void Start()
    {
        //ExparentClass�� Protected ������ ���� ����
        Debug.Log("Protected Value from Child Class : " + protectedValue);
    }
}
