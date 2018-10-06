using MalaaviMVC_DomainClasses.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MalaaviMVC_DomainClasses.Products
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "عنوان محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(350, MinimumLength = 4, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد ")]
        public string Title { get; set; }

        [Display(Name = "توضیحات مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(500, MinimumLength = 4, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد ")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "متن کامل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Text { get; set; }

        [Display(Name = "تاریخ ثبت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        public DateTime Date { get; set; }

        [Display(Name = "قیمت محصول")]
        public int Price { get; set; }

        [Display(Name = "تصویر محصول")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "{0} باید بین {2} و {1} کاراکتر باشد ")]
        public string ImageName { get; set; }

        public virtual ICollection<ProductTag> ProductTags { get; set; }
        public virtual ICollection<ProductGallery> ProductGalleries { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

    }
}
