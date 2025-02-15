using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shine.Engine
{
    class SceneManager
    {
        List<Scene> scenes;
        Scene currentScene;

        public SceneManager()
        {
            scenes = new List<Scene>();
        }

        public void ChangeScene(Scene scene)
        {
            currentScene = scene;
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
                if (currentScene == scene) scene.Update();
            }
        }

        public void Render()
        {
            foreach (Scene scene in scenes)
            {
                if (currentScene == scene) scene.Render();
            }
        }

    }
}
