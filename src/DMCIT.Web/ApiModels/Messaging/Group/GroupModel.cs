using DMCIT.Core.Entities.Messaging;
using System.Collections.Generic;

namespace DMCIT.Web.ApiModels.Messaging.Group
{
    public class GroupModel : BaseModel<MessageReceiverGroup>
    {
        protected readonly int _minNameLength = 2;
        protected readonly int _maxNameLength = 32;
        public string name { get; set; }
        public bool isPrivate { get; set; }
        public int count { get; set; }
        public List<MessageReceiverModel> members { get; set; }
        public GroupModel()
        {

        }

        public GroupModel(MessageReceiverGroup entity) : base(entity)
        {
            name = entity.Name;
            isPrivate = entity.IsPrivate;
            if (entity.MessageReceiverGroupMessageReceivers != null)
            {
                members = new List<MessageReceiverModel>();
                foreach (var item in entity.MessageReceiverGroupMessageReceivers)
                {
                    if (item.MessageReceiver != null)
                    {
                        members.Add(new MessageReceiverModel(item.MessageReceiver));
                    }
                    else
                    {
                        members.Add(new MessageReceiverModel
                        {
                            id = item.MessageReceiverId
                        });
                    }
                }
            }
        }

        public MessageReceiverGroup ToEntity()
        {
            var entity = new MessageReceiverGroup
            {
                Id = id,
                IsPrivate = false,
                Name = name
            };
            var m = new List<MessageReceiverGroupMessageReceiver>();
            foreach (var r in members)
            {
                var item = new MessageReceiverGroupMessageReceiver
                {
                    MessageReceiverId = r.id,
                    MessageReceiverGroupId = id
                };
                m.Add(item);
            }
            entity.MessageReceiverGroupMessageReceivers = m;
            return entity;
        }
    }
}
