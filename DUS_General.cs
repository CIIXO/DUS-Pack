using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.SceneManagement;
/*COMMITING CHANGES TO THE SCRIPT MIGHT CAUSE INSTABLITY, BUT FEEL FREE TO DO SO!*/
public class DUS_General : MonoBehaviour
{
    public enum OpsDeclare { Destroy, Spawn, FindComponent, LoadScene, SetParent, DestroyParent, SetActive };
    public enum ActiveState { True, False};
    public enum CallMethod { OnRuntime, ExternalCall, Tick}

    public OpsDeclare operation;
    public ActiveState activeState;
    public CallMethod callMethod;
    public GameObject objectToApply;
    public GameObject[] array;
    public GameObject secondObj;
    public string ComponentName = "";
    public int sceneIndex;
    public float generalFloat;
    public int generalInt;
    public Component component;
    public Vector3 spawnPos;
    public Vector3 spawnRot;


    private void Start()
    {
        if(callMethod == CallMethod.OnRuntime)
        {
            StartCoroutine(operation.ToString());
        }
        else if(callMethod == CallMethod.Tick)
        {
            StartCoroutine(Tick());
        }
    }


    public void ExternalCall()
    {
        if(callMethod == CallMethod.ExternalCall && operation != OpsDeclare.FindComponent)
        {
            StartCoroutine(operation.ToString());
        }
    }

    public Component ComponentCall()
    {
        component = objectToApply.GetComponent(ComponentName);
        if (component != null)
        {
            return component;
        }
        else
        {
            return null;      
        }
    }

    IEnumerator Tick()
    {
        while (true)
        {
            StartCoroutine(operation.ToString());
            yield return null;
        }        
    }


    #region coroutines
    // Coroutines will be executed during RunTime and they can be executed with a certain amount of delay
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(generalFloat);
        foreach (GameObject obj in array)
        {
            Destroy(obj);
        }

    }
    IEnumerator DestroyParent()
    {
        yield return new WaitForSeconds(generalFloat);
        foreach (GameObject obj in array)
        {
            Destroy(obj.transform.parent.gameObject);
        }
    }

    IEnumerator FindComponent()
    {
        yield return new WaitForSeconds(generalFloat);
        component = objectToApply.GetComponent(ComponentName);
    }
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(generalFloat);
        SceneManager.LoadScene(sceneIndex);
    }
    IEnumerator SetActive()
    {
        yield return new WaitForSeconds(generalFloat);
        if(activeState == 0)
        {
            foreach (GameObject obj in array)
            {
                obj.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject obj in array)
            {
                obj.SetActive(false);
            }
        }

    }
    IEnumerator SetParent()
    {
        yield return new WaitForSeconds(generalFloat);
        foreach(GameObject child in array)
        {
            child.transform.parent = secondObj.transform;
        }
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(generalFloat);
        foreach(GameObject obj in array)
        {
            Instantiate(obj, spawnPos, Quaternion.Euler(spawnRot));
        }
    }
    #endregion
}

[CustomEditor(typeof(DUS_General))]
public class DUGS_General_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        DUS_General general = target as DUS_General;
        var childs = serializedObject.FindProperty("array");
        general.operation = (DUS_General.OpsDeclare)EditorGUILayout.EnumPopup("Operation", general.operation);
        GUILayout.Space(4);
        general.callMethod = (DUS_General.CallMethod)EditorGUILayout.EnumPopup("Call Method", general.callMethod);
        if(general.callMethod == DUS_General.CallMethod.ExternalCall)
        {
            EditorGUILayout.LabelField("Use ExternalCall() function in your other scripts \n to execute an operation, useful for Triggers, Raycast, etc...", GUILayout.Height(40));
        }

        switch (general.operation)
        {
            case DUS_General.OpsDeclare.Destroy:
                GUILayout.Space(50);
                EditorGUILayout.LabelField("Object To Destroy");
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(childs);
                if (EditorGUI.EndChangeCheck())
                {
                    serializedObject.ApplyModifiedProperties();
                }
                general.generalFloat = EditorGUILayout.FloatField("Delay Time: ", general.generalFloat);
                break;
            case DUS_General.OpsDeclare.DestroyParent:
                GUILayout.Space(50);
                EditorGUILayout.LabelField("Orphans To Be");
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(childs);
                if (EditorGUI.EndChangeCheck())
                {
                    serializedObject.ApplyModifiedProperties();
                }
                general.generalFloat = EditorGUILayout.FloatField("Delay Time: ", general.generalFloat);
                break;
            case DUS_General.OpsDeclare.FindComponent:
                GUILayout.Space(50);
                general.objectToApply = (GameObject)EditorGUILayout.ObjectField("Component Holder", general.objectToApply, typeof(GameObject), true);
                general.ComponentName = EditorGUILayout.TextField("Component Name: ", general.ComponentName);
                general.generalFloat = EditorGUILayout.FloatField("Delay Time: ", general.generalFloat);
                general.component = (Component)EditorGUILayout.ObjectField("Component", general.component, typeof(Component), true);
                break;
            case DUS_General.OpsDeclare.LoadScene:
                GUILayout.Space(50);
                GUILayout.BeginHorizontal();
                GUILayout.Label("Scene Index");
                general.sceneIndex = EditorGUILayout.IntField(general.sceneIndex);
                GUILayout.EndHorizontal();
                general.generalFloat = EditorGUILayout.FloatField("Delay Time: ", general.generalFloat);
                break;
            case DUS_General.OpsDeclare.SetActive:
                GUILayout.Space(50);
                EditorGUILayout.LabelField("Objects Te Be Activated");
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(childs);
                if (EditorGUI.EndChangeCheck())
                {
                    serializedObject.ApplyModifiedProperties();
                }
                general.activeState = (DUS_General.ActiveState)EditorGUILayout.EnumPopup("State", general.activeState);
                general.generalFloat = EditorGUILayout.FloatField("Delay Time: ", general.generalFloat);
                break;
            case DUS_General.OpsDeclare.SetParent:
                GUILayout.Space(50);
                EditorGUILayout.LabelField("Childs To Be( ;| )");
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(childs);
                if (EditorGUI.EndChangeCheck())
                {
                    serializedObject.ApplyModifiedProperties();
                }
                general.secondObj = (GameObject)EditorGUILayout.ObjectField("Parent To Be", general.secondObj, typeof(GameObject), true);
                general.generalFloat = EditorGUILayout.FloatField("Delay Time: ", general.generalFloat);
                break;
            case DUS_General.OpsDeclare.Spawn:
                GUILayout.Space(50);
                EditorGUILayout.LabelField("Objects To Spawn");
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(childs);
                if (EditorGUI.EndChangeCheck())
                {
                    serializedObject.ApplyModifiedProperties();
                }
                general.spawnPos = EditorGUILayout.Vector3Field("Spawn Position", general.spawnPos);
                general.spawnRot = EditorGUILayout.Vector3Field("Spawn Rotation", general.spawnRot);
                general.generalFloat = EditorGUILayout.FloatField("Delay Time: ", general.generalFloat);
                break;
        }

    }
}
