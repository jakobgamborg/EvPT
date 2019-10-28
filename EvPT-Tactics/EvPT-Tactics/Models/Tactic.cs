using EvPT_Tactics.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EvPT_Tactics.Models
{
    public class Tactic
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [EnumDataType(typeof(Map))]
        public IEnumerable<SelectListItem> Maps { get; set; }
        public bool IsTerrorist { get; set; }
        public bool IsAggresive { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

    }
    public enum Map
    {
        Overpass,
        Nuke,
        Inferno,
        Train,
        Mirage,
        Vertigo,
        Dust2,
        Cache
    }


}

