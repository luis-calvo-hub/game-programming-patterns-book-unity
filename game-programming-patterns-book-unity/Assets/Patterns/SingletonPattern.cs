/* It allows only one instance of a class to be created and gives access to that created instance
 * In most of the times, this pattern should be avoided as it couples the classes to the singletons
 * There are however some use cases and can ease the development of prototypes
 * It solves two problems at once which can be bad (global access and single instance)
 * It can be used as a base class for other classes
*/

public class SingletonPattern {
    public static SingletonPattern Instance { get; private set; }

    public SingletonPattern() {
        if (Instance == null) {
            Instance = new();
        }
        else {
            UnityEngine.Debug.LogError("There can only be one instance of SingletonPattern.");
        }
    }

    public void DoSomething() {
    }

    public void DoAnotherThing() {
    }
}