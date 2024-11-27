using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;  // Instancia estática para asegurar que solo haya una música global
    public AudioClip musicaMenuTutorial;  // Música para "Menu" y "Tutorial" (la misma música para ambas escenas)
    public AudioClip musicaSampleScene;  // Música para la escena "SampleScene"
    public AudioClip musicaNivel2;  // Música para la escena "Nivel2"
    private AudioSource audioSource;  // Fuente de audio para reproducir la música

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
        audioSource.loop = true;  // Hacer que la música se repita
    }

    void Start()
    {
        // Asegurarse de que la música se cambie correctamente al inicio
        CambiarMusicaSegunEscena();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Cambiar la música cada vez que se cargue una nueva escena
        CambiarMusicaSegunEscena();
    }

    // Método para cambiar la música según la escena
    private void CambiarMusicaSegunEscena()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Menu" || currentScene == "Tutorial")
        {
            // Si estamos en "Menu" o "Tutorial", no cambiar la música si ya se está reproduciendo
            if (!audioSource.isPlaying)  // Si la música no está sonando, reproducirla
            {
                audioSource.clip = musicaMenuTutorial;
                audioSource.Play();
            }
        }
        else if (currentScene == "SampleScene")
        {
            if (!audioSource.isPlaying || audioSource.clip != musicaSampleScene)  // Cambiar solo si no se está reproduciendo o si es otra canción
            {
                audioSource.clip = musicaSampleScene;
                audioSource.Play();
            }
        }
        else if (currentScene == "Nivel2")
        {
            if (!audioSource.isPlaying || audioSource.clip != musicaNivel2)  // Cambiar solo si no se está reproduciendo o si es otra canción
            {
                audioSource.clip = musicaNivel2;
                audioSource.Play();
            }
        }
    }

    // Método opcional para cambiar la música de manera manual
    public void CambiarMusica(AudioClip nuevoClip)
    {
        audioSource.clip = nuevoClip;
        audioSource.Play();
    }
}