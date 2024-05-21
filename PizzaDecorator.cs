using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Design_Patterns
{
    public class PizzaDecorator : IPizza
    {
        private readonly IPizza _pizza;

        public PizzaDecorator(IPizza pizza)
        {
            _pizza = pizza;
        }
        public virtual string BuscarTipoPizza()
        {
            var pizza = _pizza.BuscarTipoPizza();
            return pizza;
        }
    }
}