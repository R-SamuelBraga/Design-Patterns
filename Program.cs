﻿using Design_Patterns;

//Exemplo SIngleton Print Spooler
string[] firstDocumentStrings = { "PC1_doc1", "PC1_doc2", "PC1_doc3" };
string[] secondDocumentStrings = { "PC2_doc4", "PC2_doc5", "PC2_doc6" };
var printSpooler1 = PrintSpooler.GetPrintSpooler();
var printSpooler2 = PrintSpooler.GetPrintSpooler();

var task1 = Task.Run(() => printSpooler1.AddPrintJob(firstDocumentStrings));
var task2 = Task.Run(() => printSpooler2.AddPrintJob(secondDocumentStrings));
await Task.WhenAll(task1, task2);

printSpooler1.ProcessPrintJob();
printSpooler2.ProcessPrintJob();

// Lazy Singleton
Singleton s1 = Singleton.GetInstance();
Singleton s2 = Singleton.GetInstance();

if (s1 == s2)
{
    Console.WriteLine("Singleton works, both variables contain the same instance.");
}
else
{
    Console.WriteLine("Singleton failed, variables contain different instances.");
}

//Exemplo DECORATOR Pizza
IPizza pizza = new Pizza();

            Console.WriteLine(pizza.BuscarTipoPizza());
            Console.WriteLine();

            IPizza queijoDecorator = new QueijoDecorator(pizza);
            IPizza baconDecorator = new BaconDecorator(queijoDecorator);
            IPizza cebolaDecorator = new CebolaDecorator(baconDecorator);



            Console.WriteLine(cebolaDecorator.BuscarTipoPizza());
            Console.WriteLine();

//Exemplo Observer

            var subject = new Subject();
            var observerA = new ConcreteObserverA();
            subject.Attach(observerA);

            var observerB = new ConcreteObserverB();
            subject.Attach(observerB);

            subject.SomeBusinessLogic();
            subject.SomeBusinessLogic();

            subject.Detach(observerB);

            subject.SomeBusinessLogic();
