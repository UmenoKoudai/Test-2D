using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class MathTest : MonoBehaviour
{
    void Start()
    {
        //value�̐�Βl��Ԃ�
        //Mathf.Abs(value)
        var Abs = Mathf.Abs(1);
        Debug.Log($"Abs:{Abs}");

        //2�̒l���r���傫���ق���Ԃ�
        //Mathf.Max(value1, value2�E�E�E);
        var Max = Mathf.Max(0.1f, 0.5f);
        Debug.Log($"Max:{Max}");

        //2�̒l���r���������ق���Ԃ�
        //Mathf.Min(value1, value2�E�E�E);
        var Min = Mathf.Min(0.1f, 0.5f);
        Debug.Log($"Min:{Min}");

        //�l���ŏ��l�`�ő�l�͈̔͂ɐ�������
        //value�̒l��min��菬�������min��Ԃ��Avalue�̒l��max���傫�����max��Ԃ��A�ǂ���ł��Ȃ����value��Ԃ��܂��B
        //Mathf.Clamp(value, min, max);
        var Clamp = Mathf.Clamp(0.1f, 0.5f, 1f);
        Debug.Log($"Clamp:{Clamp}");

        //�؂�̂�(float�^)
        var Ceil = Mathf.Ceil(1.5f);
        Debug.Log($"Ceil:{Ceil}");

        //�؂�̂�(int�^)
        var CeilToInt = Mathf.CeilToInt(1.5f);
        Debug.Log($"Ceil:{CeilToInt}");

        //�؂�グ(float�^)
        var Floor = Mathf.Floor(1.5f);
        Debug.Log($"Floor:{Floor}");

        //�؂�グ(int�^)
        var FloorToInt = Mathf.FloorToInt(1.5f);
        Debug.Log($"Floor:{FloorToInt}");

        //�x���烉�W�A���ɕϊ�
        var Deg2Rad = 60.0f * Mathf.Deg2Rad;
        Debug.Log($"Deg2Rad:{Deg2Rad}");

        //���W�A������x�ɕϊ�
        var Rad2Deg = 1.0f * Mathf.Rad2Deg;
        Debug.Log($"Rad2Deg:{Rad2Deg}");

        //���̖������\��
        var Infinity = Mathf.Infinity;
        Debug.Log($"Infinity:{Infinity}");

        //���̖������\��
        var NegativeInfinity = Mathf.NegativeInfinity;
        Debug.Log($"NegativeInfinity:{NegativeInfinity}");

        //�~����
        var PI = Mathf.PI;
        Debug.Log($"PI:{PI}");

        //�O�p�֐�(�T�C���A�R�T�C���A�^���W�F���g)
        var Sin = Mathf.Sin(1f);
        var Cos = Mathf.Cos(1f);
        var Tan = Mathf.Tan(1f);
        Debug.Log($"Sin:{Sin} Cos:{Cos} Tan:{Tan}");

        //�t�O�p�֐�(�A�[�N�T�C���A�A�[�N�R�T�C���A�A�[�N�^���W�F���g)
        var Asin = Mathf.Asin(1f);
        var Acos = Mathf.Acos(1f);
        var Atan = Mathf.Atan(1f);
        Debug.Log($"Asin:{Asin} Acos:{Acos} Atan:{Atan}");

        //2�_�Ԃ̊p�x
        var Atan2 = Mathf.Atan2(1f, 1f);
        Debug.Log($"Atan2:{Atan2}");

        //�搔
        //value1��value2�悷��
        //Mathf.Pow(value1, value2);
        var Pow = Mathf.Pow(2f, 3f);
        Debug.Log($"Pow:{Pow}");


    }
}
