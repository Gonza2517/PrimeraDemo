using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;  // Instancia est�tica para asegurar que solo haya una m�sica global
    public AudioClip musicaMenuTutorial;  // M�sica para "Menu" y "Tutorial" (la misma m�sica para ambas escenas)
    public AudioClip musicaSampleScene;  // M�sica para la escena "SampleScene"
    public AudioClip musicaNivel2;  // M�sica para la escena "Nivel2"
    private AudioSource audioSource;  // Fuente de audio para reproducir la m�sica

    void Awake()
    {
        // Verifica si ya existe una instancia de MusicManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // No destruir este objeto cuando se cambie de escena
        }
        else
        {
            Destroy(gameObject);  // Si ya existe, destruye este objeto para evitar duplicados
        }

        audioSource = GetComponent<AudioSource>();  // Obtener la fuente de audio del objeto
        audioSource.loop = true;  // Hacer que la m�sica se repita
    }

    void Start()
    {
        // Asegurarse de que la m�sica se cambie correctamente al inicio
        CambiarMusicaSegunEscena();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Cambiar la m�sica cada vez que se cargue una nueva escena
        CambiarMusicaSegunEscena();
    }

    // M�todo para cambiar la m�sica seg�n la escena
    private void CambiarMusicaSegunEscena()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Menu" || currentScene == "Tutorial")
        {
            // Si estamos en "Menu" o "Tutorial", no cambiar la m�sica si ya se est� reproduciendo
            if (!audioSource.isPlaying)  // Si la m�sica no est� sonando, reproducirla
            {
                audioSource.clip = musicaMenuTutorial;
                audioSource.Play();
            }
        }
        else if (currentScene == "SampleScene")
        {
            if (!audioSource.isPlaying || audioSource.clip != musicaSampleScene)  // Cambiar solo si no se est� reproduciendo o si es otra canci�n
            {
                audioSource.clip = musicaSampleScene;
                audioSource.Play();
            }
        }
        else if (currentScene == "Nivel2")
        {
            if (!audioSource.isPlaying || audioSource.clip != musicaNivel2)  // Cambiar solo si no se est� reproduciendo o si es otra canci�n
            {
                audioSource.clip = musicaNivel2;
                audioSource.Play();
            }
        }
    }

    // M�todo opcional para cambiar la m�sica de manera manual
    public void CambiarMusica(AudioClip nuevoClip)
    {
        audioSource.clip = nuevoClip;
        audioSource.Play();
    }
}