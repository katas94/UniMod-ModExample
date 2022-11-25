using Cysharp.Threading.Tasks;
using Katas.UniMod.HostExample;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Katas.UniMod.ModExample
{
    /// <summary>
    /// Startup script called by the host when loading the example mod.
    /// </summary>
    [CreateAssetMenu(menuName = "UniMod Mod Example/Example Mod Startup", fileName = "ExampleModStartup")]
    public class ExampleModStartup : ModStartup
    {
        public string myName;
        public string mainSceneAddress;
        
        public override async UniTask StartAsync(IMod mod)
        {
            // load the main scene from Addressables
            await Addressables.LoadSceneAsync(mainSceneAddress, LoadSceneMode.Additive);
            
            // use the Host Example API
            HostExampleApi.SayHello(myName);
        }
    }
}