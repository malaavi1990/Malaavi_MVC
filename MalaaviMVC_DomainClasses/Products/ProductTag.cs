using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaaviMVC_DomainClasses.Products
{
    public class ProductTag
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        [Display(Name = "نام تگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد ")]
        public string Tag { get; set; }
    }
}
