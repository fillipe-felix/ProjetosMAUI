using AppJogoForca.Models;

namespace AppJogoForca.Repositories;

public class WordRepository
{
    private List<Word> _words;
    
    public WordRepository()
    {
        _words = new List<Word>();
        
        _words.Add(new Word("Nome", "Maria"));
        _words.Add(new Word("Vegetal", "Cenoura"));
        _words.Add(new Word("Fruta", "Abacate"));
        _words.Add(new Word("Tempero", "Baiano"));
        _words.Add(new Word("Animal", "Burro"));
        _words.Add(new Word("Carro", "Pneu"));
    }

    public Word GetRandomWord()
    {
        var random = new Random().Next(0, _words.Count);
        return _words[random];
    }
}
