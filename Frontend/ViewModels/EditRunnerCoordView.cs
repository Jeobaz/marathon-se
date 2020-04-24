using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.ViewModels
{
    public class EditRunnerCoordView : EditRunnerView
    {
        [Required]
        public string RegStatus { get; set; }
    }
}
