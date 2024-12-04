using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalApp.Domain.Models
{
    public class ClientModel
    {
        public int ClientId { get; set; }
        public string? Name { get; set; }
        public string? NoDocument { get; set; }
        public string? Direction { get; set; }
        public string? Email { get; set; }
    }
}
