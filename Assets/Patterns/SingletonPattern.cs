/* Simple example of how a singleton can be used in Unity on a pute C# class, it can also be used inside a MonoBehaviour class
* It allows only one instance of a class to be created and gives access to that created instance
 * In most of the times, this pattern should be avoided as it couples the classes to the singletons
 * There are however some use cases and can ease the development of prototypes
 * It solves two problems at once which can be bad (global access and single instance)
 * It can also be used as a base class for other classes
*/

public class SingletonPattern {
    private static SingletonPattern instance;
    
    public static SingletonPattern Instance {
        get {
            return instance ??= new SingletonPattern();
        }
        private set {
            instance = value;
        }
    }

    public void DoSomething() {
        UnityEngine.Debug.Log("Doing Something.");
    }

    public void DoAnotherThing() {
    }
}