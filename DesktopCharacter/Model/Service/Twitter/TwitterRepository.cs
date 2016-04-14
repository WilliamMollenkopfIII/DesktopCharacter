﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopCharacter.Model.Database;
using DesktopCharacter.Model.Database.Domain;

namespace DesktopCharacter.Model.Service.Twitter
{
    class TwitterRepository
    {
        /// <summary>
        /// 保存されているアクセストークンからTwitterを作成
        /// </summary>
        /// <returns>保存されているユーザー全てのTwitter</returns>
        public List<Twitter> Load()
        {
            List<TwitterUser> twitterUsers;
            using (var context = new DatabaseContext())
            {
                twitterUsers = context.TwitterUser.ToList();
            }
            return twitterUsers.Select(CreateTwitter).ToList();
        }

        /// <summary>
        /// ユーザーを保存する
        /// </summary>
        /// <param name="user">保存するユーザー</param>
        public void Save(TwitterUser user)
        {
            using (var context = new DatabaseContext())
            {
                context.TwitterUser.AddOrUpdate(user);
                context.SaveChanges();
            }
        }

        public Twitter CreateTwitter(TwitterUser user)
        {
            return new Twitter(user);
        }
    }
}
