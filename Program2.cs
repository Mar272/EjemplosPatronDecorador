using System;

namespace PatronDecoradorPizza
{
    // Interfaz común
    public interface IPizza
    {
        string Descripcion();
        int Costo();
    }

    // Clase base concreta
    public class PizzaBase : IPizza
    {
        public string Descripcion() => "Masa de pizza";
        public int Costo() => 5000;
    }

    // Clase abstracta decorador
    public abstract class PizzaDecorador : IPizza
    {
        protected IPizza _pizza;

        public PizzaDecorador(IPizza pizza)
        {
            _pizza = pizza;
        }

        public virtual string Descripcion() => _pizza.Descripcion();
        public virtual int Costo() => _pizza.Costo();
    }

    // Decoradores de ingredientes
    public class Queso : PizzaDecorador
    {
        public Queso(IPizza pizza) : base(pizza) { }

        public override string Descripcion() => _pizza.Descripcion() + ", Queso extra";
        public override int Costo() => _pizza.Costo() + 1500;
    }

    public class Pepperoni : PizzaDecorador
    {
        public Pepperoni(IPizza pizza) : base(pizza) { }

        public override string Descripcion() => _pizza.Descripcion() + ", Pepperoni";
        public override int Costo() => _pizza.Costo() + 2000;
    }

    public class Champiñones : PizzaDecorador
    {
        public Champiñones(IPizza pizza) : base(pizza) { }

        public override string Descripcion() => _pizza.Descripcion() + ", Champiñones";
        public override int Costo() => _pizza.Costo() + 1000;
    }

    // Decoradores de tamaño
    public class Pequeña : PizzaDecorador
    {
        public Pequeña(IPizza pizza) : base(pizza) { }

        public override string Descripcion() => "Pequeña - " + _pizza.Descripcion();
        public override int Costo() => _pizza.Costo() + 1000;
    }

    public class Mediana : PizzaDecorador
    {
        public Mediana(IPizza pizza) : base(pizza) { }

        public override string Descripcion() => "Mediana - " + _pizza.Descripcion();
        public override int Costo() => _pizza.Costo() + 2000;
    }

    public class Grande : PizzaDecorador
    {
        public Grande(IPizza pizza) : base(pizza) { }

        public override string Descripcion() => "Grande - " + _pizza.Descripcion();
        public override int Costo() => _pizza.Costo() + 4000;
    }

    // Programa principal
    class Program
    {
        static void Main(string[] args)
        {
            IPizza Pizza = new PizzaBase();

            // Seleccionar tamaño primero
            Pizza = new Grande(Pizza);

            // Agregar ingredientes
            Pizza = new Queso(Pizza);
            Pizza = new Pepperoni(Pizza);
            Pizza = new Champiñones(Pizza);

            Console.WriteLine("Pizza: " + Pizza.Descripcion());
            Console.WriteLine("Costo total: $" + Pizza.Costo());
        }
    }
}
