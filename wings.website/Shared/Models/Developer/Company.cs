using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;
using wings.website.Shared.Attributes;

namespace wings.website.Shared.Models.Developer
{

    [DataGrid(Title ="公司管理")]
   public class Company
    {
        [Key]
        public long id { get; set; }
        [DisplayName("公司名称")]
        public string name { get; set; }
        [DisplayName("公司描述")]
        public string description { get; set; }
        [Required]
        [DisplayName("公司代码")]
        public string code { get; set; }
        [DisplayName("公司头像")]
        public string avatarUrl { get; set; }
        [DisplayName("公司状态")]
        public CompanyStatus status { get; set; } = CompanyStatus.Approve;
        [DisplayName("创建日期")]
        public DateTime createAt { get; set; } = DateTime.Now;

        public string menuIds { get; set; }




    }
    public enum CompanyStatus
    {
        Submit,
        
        Approve,
        Disabled
    }
}
