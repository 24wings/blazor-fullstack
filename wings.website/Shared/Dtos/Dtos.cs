﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace wings.website.Shared.Dtos
{
    public class RegisterResult
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
    public class RegisterModel
    {
        [Required]
        [Display(Name = "邮箱")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = " {0} 必须最少 {2} 且 最大 {1} 字符长度.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "两次输入的密码不一致")]
        public string ConfirmPassword { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        [Required]
        [Display( Name = "验证码")]
        public string Code { get; set; }
    }
    public class LoginResult
    {
        public bool Successful { get; set; }
        public string Error { get; set; }
        public string Token { get; set; }
    }
    public class LoginModel
    {
        [Display(Name = "用户名")]
        [Required(ErrorMessage="用户名必填")]
        public string Email { get; set; }
        [Display(Name = "密码")]
        [Required( ErrorMessage = "{0} 必填")]
        public string Password { get; set; }
        [Display(Name = "记住我")]
        public bool RememberMe { get; set; }
    }
}
