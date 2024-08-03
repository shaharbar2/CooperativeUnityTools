using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Cooperative.Tools
{
        public class COPComponentsEditTools
    {
        [MenuItem("GameObject/COP/SplitComponents", false, -9)]
        private static void SplitComponents()
        {
            var go = Selection.activeGameObject;
            var goName = go.name;
            go.name = $"{go.name}Holder";
            
            var components = go.GetComponents<Component>();

            foreach (var component in components)
            {
                if (component is Transform) continue;

                var child = new GameObject($"{goName}{component.GetType().Name.Split('.').Last()}")
                {
                    transform =
                    {
                        parent = go.transform,
                        localScale = Vector3.one,
                        position = Vector3.zero
                    }
                };

                EditorUtility.CopySerialized(component, child.AddComponent(component.GetType()));

                Object.DestroyImmediate(component);
            }
        }
        
        [MenuItem("CONTEXT/Component/COP/MoveToNewChild")]
        private static void MoveComponentToNewChild(MenuCommand command)
        {
            var component = (Component)command.context;
            var parent = component.gameObject;

            if (component is Transform) return; 

            var child = new GameObject($"{parent.name}{component.GetType().Name.Split('.').Last()}")
            {
                transform =
                {
                    parent = parent.transform,
                    localScale = Vector3.one,
                    localPosition = Vector3.zero
                }
            };

            EditorUtility.CopySerialized(component, child.AddComponent(component.GetType()));

            Object.DestroyImmediate(component);
        }
        
        [MenuItem("GameObject/COP/MergeComponents", false, -8)]
        private static void MergeComponentsIntoFirst()
        {
            var selectedObjects = Selection.gameObjects;

            if (selectedObjects.Length < 2) return;
            
            var targetObject = selectedObjects[0];

            for (var i = 1; i < selectedObjects.Length; i++)
            {
                try
                {
                    var go = selectedObjects[i];
                    var components = go.GetComponents<Component>();
                
                    foreach (var component in components)
                    {
                        if (component is Transform) continue;

                        EditorUtility.CopySerialized(component, targetObject.AddComponent(component.GetType()));
                    }

                    Object.DestroyImmediate(go);
                }
                catch
                {
                    // ignored
                }
            }
        }
    }

}