using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dogs1.Data
{
    public class Dogs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DID { get; set; }
        public string DSL { get; set; }
        public string DSN { get; set; }



        //foreign key
        public int PSID { get; set; }

        [ForeignKey("PSID")]
        public Petstores Petss { get; set; }
    }
}
