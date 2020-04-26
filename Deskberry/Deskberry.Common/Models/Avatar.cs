using Deskberry.Common.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deskberry.Common.Models
{
    public class Avatar : ModelBase
    {
        public byte[] Content { get; protected set; }
        public List<Account> Accounts { get; set; }

        public Avatar() : base()
        {
        }

        public Avatar(byte[] content) : base()
        {
            Content = content;
        }

        /// <summary>
        /// Constructor used to populate database with avatar
        /// </summary>
        /// <param name="content"></param>
        /// <param name="id"></param>
        public Avatar(byte[] content, int id) : base()
        {
            Content = content;
            Id = id;
        }
    }
}