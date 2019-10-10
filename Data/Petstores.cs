using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dogs1.Data
{
    public class Petstores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PSID { get; set; }

        [Display(Name = "Petstore Location")]
        public string PSLocation { get; set; }

        [Display(Name = "PSName")]
        public string PSName { get; set; }


    }
}
