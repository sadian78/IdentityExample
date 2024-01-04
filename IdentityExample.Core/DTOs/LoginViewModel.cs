using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityExample.Core.DTOs
{
    public class LoginViewModel
    {
        [MaxLength(30,ErrorMessage ="ایمیل شما بیش از تعداد کارکتر مجاز است")]
        [MinLength(5,ErrorMessage ="ایمیل شما کمتر از تعداد کارکتر مجاز است")]
        [EmailAddress(ErrorMessage = "ایمیل شما معتبر نیست")]
        [Required(ErrorMessage = "لطفا ایمیل را وارد نمایید")]

        public string? EmailAddress { get; set; }

        [Required(ErrorMessage ="لطفا پسورد را وارد نمایید")]
        public string? PassWord { get; set; }
        public bool IsRememberMe { get; set; }
    }
}
