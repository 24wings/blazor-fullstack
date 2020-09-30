using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using wings.website.Shared.Models;

namespace wings.website.Client.Services
{
    public class MenuService
    {
        private readonly IConfiguration configuration;
        private readonly HttpClient httpClient;
        public MenuService(HttpClient _httpClient, IConfiguration _configuration) { httpClient = _httpClient; configuration = _configuration; }

        public async Task<List<RbacMenuModel>> load()
        {
            var rtn = await httpClient.GetJsonAsync<List<RbacMenuModel>>(configuration.GetConnectionString("url") + "/api/RbacMenu/load");
            return rtn;
        }

        public async Task<RbacMenuModel> detailById(long id)
        {
            var rtn = await httpClient.GetJsonAsync<RbacMenuModel>(configuration.GetConnectionString("url") + "/api/RbacMenu/detail?id="+id);
            return rtn;
        }

        public async Task<List<TreeNode>> LoadMenuTreeNodes()
        {
            var rtn = await httpClient.GetJsonAsync<List<RbacMenuModel>>(configuration.GetConnectionString("url") + "/api/RbacMenu/load");
            rtn = rtn.Where(item => item != null).ToList();
            var topMenus = rtn.Where(item => item.parentId == 0).Select(item =>
            {
                var children = getMenuChild(item.id, rtn);
                var treeNode = new TreeNode
                {
                    Key = item.id.ToString(),
                    Text = item.text,
                    IsExpanded = true,
                    Nodes = { }
                };
                children.ForEach(child => treeNode.Nodes.Add(child));
                return treeNode;

            }).ToList();
            //topMenus.ForEach(topMenu =>getMenuChild(int.Parse(topMenu.Key), rtn).ForEach(child =>topMenu.Nodes.Add(child)));
            Console.WriteLine(JsonConvert.SerializeObject(topMenus));
            return topMenus;
        }
        public async Task<List<TreeNode>> LoadCurrentCompanyMenuTreeNodes()
        {
            var rtn = await httpClient.GetJsonAsync<List<RbacMenuModel>>(configuration.GetConnectionString("url") + "/api/developer/company/companyMenu");
            rtn = rtn.Where(item => item != null).ToList();
            var topMenus = rtn.Where(item => item.parentId == 0).Select(item =>
            {
                var children = getMenuChild(item.id, rtn);
                var treeNode = new TreeNode
                {
                    Key = item.id.ToString(),
                    Text = item.text,
                    IsExpanded = true,
                    Nodes = { }
                };
                children.ForEach(child => treeNode.Nodes.Add(child));
                return treeNode;

            }).ToList();
            return topMenus;
        }

        public List<TreeNode> getMenuChild(long key, List<RbacMenuModel> menus)
        {
            List<TreeNode> result = new List<TreeNode>();
            var children = menus.Where(m => m.parentId == key).Select(m => new RbacMenuModel { id = m.id, icon = m.icon, text = m.text, link = m.link, parentId = m.parentId }).ToList();

            foreach (var child in children)
            {
                if (child != null)
                {
                    var newTreeNode = new TreeNode
                    {
                        Key = child.id.ToString(),
                        Text = child.text,
                        Nodes = { }
                    };
                    result.Add(newTreeNode);
                }
            }

            result = result.Where(r => r != null).ToList();
            return result;



        }

        public TreeNode GetSelectedTreeNode(List<TreeNode> treeNodes)
        {
            var selectedTreeNode = new getSelected((treeNodes) =>
            {
                return new TreeNode { };
            });
            selectedTreeNode = new getSelected((treeNodes) => {
              
                foreach (var treeNode in treeNodes)
                {
                    if (treeNode.IsSelected)
                    {
                        return treeNode;
                    }
                    else
                    {
                        //return treeNode;
                        if (treeNode.Nodes.Count > 0)
                        {
                            return selectedTreeNode(treeNode.Nodes);
                        }
                     
                    }
                }
                return null;
            });
            return selectedTreeNode(treeNodes);

        }
    }
    
    public delegate TreeNode getSelected(List<TreeNode> nodes);
        
        

   
}
