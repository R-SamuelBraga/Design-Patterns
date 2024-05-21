using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Design_Patterns
{
    public class BaconDecorator : PizzaDecorator
    {
        public BaconDecorator(IPizza pizza)
            : base(pizza)
        {

        }

        public override string BuscarTipoPizza()
        {
            var pizza = base.BuscarTipoPizza();
            pizza += "\r\n com extra de bacon";
            return pizza;
        }
    }
}