using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.WebApi;

namespace DOHProject.Models
{
    public class ViewModelBased : IViewModelBased
    {
        public int Id { get; set; }
        public int PId { get; set; }
        public string Name { get; set; }
    }
}