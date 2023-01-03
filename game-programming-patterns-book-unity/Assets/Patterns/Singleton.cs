// Using a singleton only on the Game class reduces the number of global classes by piggybacking on existing ones like that.
// Instead of making singletons out of Log, FileSytem and AudioPlayer, do this instead.
// If later architecture is changed to support multiple instanes of some type, the existing ones won't be affected.
// The downside of this approach is that more code gets ends up coupled to Game.
// Alternativelly you can use the Service Locator pattern, in that case the class serves as a global access point to the objects.

using UnityEngine;

public class Singleton : MonoBehaviour {
    private readonly Log log;
    private readonly FileSystem fileSystem;
    private readonly AudioPlayer audioPlayer;

    public static Singleton Instance { get; private set; }

    public Singleton() {
        Instance = this;
        log = new Log();
        fileSystem = new FileSystem();
        audioPlayer = new AudioPlayer();
    }
    public Log GetLog() {
        return log;
    }
    public FileSystem GetFileSystem() {
        return fileSystem;
    }
    public AudioPlayer GetAudioPlayer() {
        return audioPlayer;
    }
}

public class Log {
}
public class FileSystem {
}
public class AudioPlayer {
}
