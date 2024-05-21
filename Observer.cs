using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Design_Patterns
{
    public interface IObserver
    {
        // Recebe atualizacao do assunto
        void Update(ISubject subject);
    }

    public interface ISubject
    {
        // Anexa um observador ao assunto.
        void Attach(IObserver observer);

        // Separa um observador do assunto.
        void Detach(IObserver observer);

        // Notifique todos os observadores sobre um evento.
        void Notify();
    }

    // O Assunto possui algum estado importante e notifica os observadores quando o
    //estado muda.
    public class Subject : ISubject
    {
    // Por uma questão de simplicidade, o estado do assunto, essencial para todos
    // assinantes, é armazenado nesta variável.
        public int State { get; set; } = -0;

        // Lista de assinantes. Na vida real, a lista de assinantes pode ser
        // armazenado de forma mais abrangente (categorizado por tipo de evento, etc.).
        private List<IObserver> _observers = new List<IObserver>();

        // metodos de gerenciamento de inscricão
        public void Attach(IObserver observer)
        {
            Console.WriteLine("Assunto: anexado um obsever.");
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine("Assunto: desanexado um observer.");
        }

        public void Notify()
        {
            Console.WriteLine("Assunto: notificando observers...");

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public void SomeBusinessLogic()
        {
            Console.WriteLine("\nSubject: I'm doing something important.");
            this.State = new Random().Next(0, 10);

            Thread.Sleep(15);

            Console.WriteLine("Subject: My state has just changed to: " + this.State);
            this.Notify();
        }
    }

    class ConcreteObserverA : IObserver
    {
        public void Update(ISubject subject)
        {            
            if ((subject as Subject).State < 3)
            {
                Console.WriteLine("ConcreteObserverA: Reacted to the event.");
            }
        }
    }

    class ConcreteObserverB : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as Subject).State == 0 || (subject as Subject).State >= 2)
            {
                Console.WriteLine("ConcreteObserverB: Reacted to the event.");
            }
        }
    }
}