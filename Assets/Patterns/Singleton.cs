/* Simple example of how a singleton can be used in Unity on a pure C# class, it can also be used inside a MonoBehaviour class
 * The point of a singleton is to allow only one instance of a class to be created and it also gives a global access point to it
 * In most of the times, this pattern should be avoided as it couples the classes to the singletons
 * There are however some use cases and can ease the development of prototypes
 * It solves two problems at once which can be bad (global access and single instance)
 * It can also be used as a base class for other classes by using C# templates
 * This example is not thread safe, you can use locks or other methods to make it thread safe
*/

public class SingletonExample {
    public SingletonExample() {
        Singleton.Instance.DoSomething();
        Singleton.Instance.DoSomethingElse();
    }
}

public class Singleton {
    private static Singleton instance;

    public static Singleton Instance {
        get {
            return instance ??= new Singleton();
        }
        private set {
            instance = value;
        }
    }

    // Notice the private constructor, this prevents other classes from creating new instances
    private Singleton() {
    }

    public void DoSomething() {
        UnityEngine.Debug.Log("Doing something...");
    }

    public void DoSomethingElse() {
        UnityEngine.Debug.Log("Doing something else...");
    }
}