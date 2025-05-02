using System;

class Program
{
    // Clase base: Mensaje
    public class Mensaje
    {
        public virtual string Enviar()
        {
            return "(Mensaje original";
        }
    }

    // Decorador base: DecoradorMensaje
    public abstract class DecoradorMensaje : Mensaje
    {
        protected Mensaje mensaje;

        public DecoradorMensaje(Mensaje mensaje)
        {
            this.mensaje = mensaje;
        }

        public override string Enviar()
        {
            return mensaje.Enviar();
        }
    }

    // Decorador concreto: MensajeCifrado
    public class MensajeCifrado : DecoradorMensaje
    {
        public MensajeCifrado(Mensaje mensaje) : base(mensaje) { }

        public override string Enviar()
        {
            return "Cifrado(" + base.Enviar() + ")";  
        }
    }

    // Decorador concreto: MensajeFirmado
    public class MensajeFirmado : DecoradorMensaje
    {
        public MensajeFirmado(Mensaje mensaje) : base(mensaje) { }

        public override string Enviar()
        {
            return base.Enviar() + " [Firmado])"; 
        }
    }

    // Decorador concreto: MensajeCompreso
    public class MensajeCompreso : DecoradorMensaje
    {
        public MensajeCompreso(Mensaje mensaje) : base(mensaje) { }

        public override string Enviar()
        {
            return "(Compreso" + base.Enviar() + ")";  
        }
    }

    static void Main(string[] args)
    {
        Mensaje mensaje = new Mensaje();

        mensaje = new MensajeCifrado(
             new MensajeCompreso(
                 new MensajeFirmado(mensaje)));


        Console.WriteLine(mensaje.Enviar());
    }
}

