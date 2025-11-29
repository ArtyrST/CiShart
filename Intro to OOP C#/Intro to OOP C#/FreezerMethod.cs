using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_to_OOP_C_
{
    public partial class Freezer
    {
        public void ToString()
        {
            Console.WriteLine($"Model: {this.model}, brand: {this.brand}, price: {this.price}, width: {this.width}, height: {this.height}, length: {this.lenght}");
        }

    }
}
