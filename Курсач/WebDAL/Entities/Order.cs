namespace TestApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  

    [Table("Order")]
    public partial class Order
    {
        public int Id { get; set; }

        public int User { get; set; }

        [Required]
        public string OrderedItems { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [StringLength(15)]
        public string Status { get; set; }
    }
}
