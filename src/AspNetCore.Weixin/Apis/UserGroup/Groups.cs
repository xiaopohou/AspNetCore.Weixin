﻿using System.Threading.Tasks;

namespace AspNetCore.Weixin
{
    /// <summary>
    /// 用户组接口
    /// </summary>
    public static class Groups
    {

        /// <summary>
        /// 创建分组
        /// </summary>
        /// <returns></returns>
        public static async Task<CreateGroupResult> Create(string accessToken, string name)
        {
            var urlFormat = "https://api.weixin.qq.com/cgi-bin/groups/create?access_token={0}";
            var data = new
            {
                group = new
                {
                    name = name
                }
            };
            return await MessageSend.Send<CreateGroupResult>(accessToken, urlFormat, data);
        }

        /// <summary>
        /// 发送文本信息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static async Task<GroupsJson> Get(string accessToken)
        {
            var urlFormat = "https://api.weixin.qq.com/cgi-bin/groups/get?access_token={0}";
            var url = string.Format(urlFormat, accessToken);
            return await HttpUtility.GetJson<GroupsJson>(url);
        }

        /// <summary>
        /// 获取用户分组
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId"></param>
        /// <returns></returns>
        public static async Task<GetGroupIdResult> GetId(string accessToken, string openId)
        {
            var urlFormat = "https://api.weixin.qq.com/cgi-bin/groups/getid?access_token={0}";
            var data = new { openid = openId };
            return await MessageSend.Send<GetGroupIdResult>(accessToken, urlFormat, data);
        }

        /// <summary>
        /// 创建分组
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="id"></param>
        /// <param name="name">分组名字（30个字符以内）</param>
        /// <returns></returns>
        public static async Task<WeixinErrorJson> Update(string accessToken, int id, string name)
        {
            var urlFormat = "https://api.weixin.qq.com/cgi-bin/groups/update?access_token={0}";
            var data = new
            {
                group = new
                {
                    id = id,
                    name = name
                }
            };
            return await MessageSend.Send(accessToken, urlFormat, data);
        }

        /// <summary>
        /// 移动用户分组
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId"></param>
        /// <param name="toGroupId"></param>
        /// <returns></returns>
        public static async Task<WeixinErrorJson> MemberUpdate(string accessToken, string openId, int toGroupId)
        {
            var urlFormat = "https://api.weixin.qq.com/cgi-bin/groups/members/update?access_token={0}";
            var data = new
            {
                openid = openId,
                to_groupid = toGroupId
            };
            return await MessageSend.Send(accessToken, urlFormat, data);
        }
    }
}
