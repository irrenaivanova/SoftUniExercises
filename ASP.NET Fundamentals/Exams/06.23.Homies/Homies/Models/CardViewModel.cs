using Homies.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Homies.Models
{
    public class CardViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Start { get; set; }
        public string Type { get; set; }
        public string Organiser { get; set; }
    }
}

