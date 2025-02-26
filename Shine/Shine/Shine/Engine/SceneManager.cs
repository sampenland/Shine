using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossEngine.Engine
{
    class SceneManager
    {
        List<Scene> scenes;
        public Scene CurrentScene;

        public SceneManager()
        {
            scenes = new List<Scene>();
        }

        public void ChangeScene(Scene scene)
        {
            if (CurrentScene != null)
            {
                CurrentScene.End();
                Log.Print("Scene: " + CurrentScene.Name + " ended");
            }

            CurrentScene = scene;
            CurrentScene.Start();
            Log.Print("Started scene: " + scene.Name);
        }

        public void AddScene(Scene scene)
        {
            scenes.Add(scene);
        }

        public void RemoveScene(Scene scene)
        {
            scenes.Remove(scene);
        }

        public void Update()
        {
            foreach(Scene scene in scenes)
            {
                if (CurrentScene == scene) scene.Update();
            }
        }

    }
}
