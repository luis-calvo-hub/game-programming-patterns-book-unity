/* Simple example of how a service locator can be used in Unity on a pure C# class, it can also be used inside a MonoBehaviour class
 * The main purpose of a service locator is to provide a point of access to a service which is usually multiple parts of the code
 * In this example we are avoiding global access, because of that, the service locator should be accessed by using D.I (Dependency Injection)
 * However service locator can also be used along with the singleton pattern or a static class
 * We are also showing how a service locator can be used with interfaces to decouple the code from the class that implements it
 * Because of that, we can have a different implementation of the AudioService depending on the target platform for example
 * Here we are also adding a safe layer of protection to avoid null references by creating a NullAudioService that does nothing if a proper service is not defined
 * This can be useful if there's a chance of a service not being defined, but often times it is preferible to fail fast
 * Here We are also using a decorator pattern to log the AudioService, to use it declare the ServiceLocator::audioService as LoggedAudioService
 * Another advantage of a service locator is that a service can be changed while the game is running, however it's usually only used during development
 * The biggest disvantage is that it depend on the outside code, any code accessing presumes some code somewhere has already registered it
*/

using UnityEngine;

public class ServiceLocatorExample {
    public ServiceLocatorExample() {
        ServiceLocator serviceLocator = new() {
            audioService = new AudioService(),
        };
        // Use this if you want to log the audio service or add it inside precompilers or other conditions
        // serviceLocator.audioService = new LoggedAudioService(serviceLocator.audioService);

        Jukebox jukebox = new(serviceLocator);
        jukebox.PlayMusic();
    }
}

public class Jukebox {
    private readonly ServiceLocator serviceLocator;

    public Jukebox(ServiceLocator serviceLocator) {
        this.serviceLocator = serviceLocator;
    }

    public void PlayMusic() {
        serviceLocator.audioService.Play(0);
    }
}

public class ServiceLocator {
    public IAudioService audioService = new NullAudioService();
    // Other services...
    // ...
}

public class AudioService : IAudioService {
    public void Play(int id) {
        // Play a sound...
    }
    public void Stop(int id) {
        // Stop a sound...
    }
}

public class LoggedAudioService : IAudioService {
    private readonly IAudioService audioService;
    public LoggedAudioService(IAudioService audioService) {
        this.audioService = audioService;
    }

    public void Play(int id) {
        Debug.Log($"Play audio {id}");
        audioService.Play(id);
    }
    public void Stop(int id) {
        Debug.Log($"Stop audio {id}");
        audioService.Stop(id);
    }
}

public class NullAudioService : IAudioService {
    public void Play(int id) { /* Do nothing. */ }
    public void Stop(int id) { /* Do nothing. */ }
}

public interface IAudioService {
    public void Play(int id);
    public void Stop(int id);
}