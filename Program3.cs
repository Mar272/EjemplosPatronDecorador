using System;

// Interfaz base
public interface IEntidad
{
    string Descripcion();
    int Poder();
}

// Clase base
public class Personaje : IEntidad
{
    public string Descripcion()
    {
        return "Personaje ";
    }

    public int Poder()
    {
        return 10;
    }
}

// Decorador base
public abstract class PersonajeMejorado : IEntidad
{
    protected IEntidad _personaje;

    public PersonajeMejorado(IEntidad personaje)
    {
        _personaje = personaje;
    }

    public virtual string Descripcion()
    {
        return _personaje.Descripcion();
    }

    public virtual int Poder()
    {
        return _personaje.Poder();
    }
}

// Decoradores concretos

public class Armadura : PersonajeMejorado
{
    public Armadura(IEntidad personaje) : base(personaje) { }

    public override string Descripcion()
    {
        return base.Descripcion() + ", con armadura";
    }

    public override int Poder()
    {
        return base.Poder() + 15;
    }
}

public class Velocidad : PersonajeMejorado
{
    public Velocidad(IEntidad personaje) : base(personaje) { }

    public override string Descripcion()
    {
        return base.Descripcion() + ", con velocidad";
    }

    public override int Poder()
    {
        return base.Poder() + 10;
    }
}

public class Escudo : PersonajeMejorado
{
    public Escudo(IEntidad personaje) : base(personaje) { }

    public override string Descripcion()
    {
        return base.Descripcion() + ", con escudo";
    }

    public override int Poder()
    {
        return base.Poder() + 20;
    }
}

// Programa principal
class Program
{
    static void Main(string[] args)
    {
        IEntidad personaje = new Personaje();

        personaje = new Escudo(
                        new Velocidad(
                            new Armadura(personaje)));

        Console.WriteLine("Descripción: " + personaje.Descripcion());
        Console.WriteLine("Poder total: " + personaje.Poder());
    }
}
