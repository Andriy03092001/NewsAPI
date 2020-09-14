using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace News.DataAccess.Entity
{
    [Table("tblNews")]
    public class tblNews
    {
        [Key]
        public  int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string DatePost { get; set; }
        [Required]
        public string LinkImage { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
