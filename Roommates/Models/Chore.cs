using System;
using System.Collections.Generic;
using System.Text;

namespace Roommates.Models
{
    public class Chore : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
