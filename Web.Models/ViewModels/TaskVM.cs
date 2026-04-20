using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Models.ViewModels
{
    public class TaskVM
    {
        public TaskManager tasks {  get; set; }
        [ValidateNever]
        public IEnumerable<Category> CategoryList { get; set; }
    }
}
