using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaaviMVC_DomainClasses.Products
{
    public class Category
    {

        public int Id { get; set; }

        [Display(Name = "عنوان دسته بندی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد ")]
        public string Title { get; set; }

        [Display(Name = "نام سر گروه")]
        [ForeignKey(nameof(Categories))]
        public int? ParentId { get; set; }

        public virtual Category Categories { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

    }
}
