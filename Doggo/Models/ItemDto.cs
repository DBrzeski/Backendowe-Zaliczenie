using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Doggo.Models
{
    public class ItemDto
    {
        public ItemDto()
        {
            Count = 1;
        }
        public int Id { get; set; }
        //Basic information-----------------------------------
        public string PictureUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        [Range(1,100)]
        public int Count { get; set; }
        //Basic information-----------------------------------

    }
}
