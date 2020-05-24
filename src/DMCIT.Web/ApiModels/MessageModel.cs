using DMCIT.Core.SharedKernel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;

namespace DMCIT.Web.ApiModels
{
    public class MessageModel : BaseModel
    {
        public static readonly string ERROR_TYPE = "danger";
        public static readonly string WARNING_TYPE = "warning";
        public static readonly string SUCCESS_TYPE = "success";
        public string Type { get; set; }
        public string Content { get; set; }
        public string Key { get; set; }

        public MessageModel() { }
        public MessageModel(EntityPropertyReviewResult result)
        {
            Content = result.Message;
            Key = result.Key;
            switch (result.ResultType)
            {
                case EntityPropertyReviewResult.EntityPropertyReviewResultType.ERROR:
                    Type = ERROR_TYPE;
                    return;
                case EntityPropertyReviewResult.EntityPropertyReviewResultType.INFO:
                    Type = SUCCESS_TYPE;
                    return;
                case EntityPropertyReviewResult.EntityPropertyReviewResultType.WARNING:
                    Type = WARNING_TYPE;
                    return;
            }
        }

        public static MessageModel CreateError(string message, string key = "")
        {
            var instance = new MessageModel
            {
                Type = ERROR_TYPE,
                Content = message,
                Key = key
            };
            return instance;
        }

        public static MessageModel CreateWarning(string message, string key = "")
        {
            var instance = new MessageModel
            {
                Type = WARNING_TYPE,
                Content = message,
                Key = key
            };
            return instance;
        }

        public static MessageModel CreateSuccess(string message, string key = "")
        {
            var instance = new MessageModel
            {
                Type = SUCCESS_TYPE,
                Content = message,
                Key = key
            };
            return instance;
        }

        public override string ToString()
        {
            return $"[{Type}] {Key}: {Content}";
        }

    }

    public class InvalidableModel<T> : BaseModel where T : BaseModel
    {
        public List<MessageModel> Message = new List<MessageModel>();
        public T Model { get; set; }

        public InvalidableModel()
        {
            Message = new List<MessageModel>();
        }
        public InvalidableModel(T model) : this()
        {
            Model = model;
        }

        public InvalidableModel(T model, ICollection<MessageModel> message) : this(model)
        {
            Message.AddRange(message);
        }

        public string GetMessage()
        {
            if (Message == null)
                return null;
            var result = "";
            foreach (var item in Message)
            {
                var line = $"[{item.Type}] {item.Key}: {item.Content}";
                if (!string.IsNullOrEmpty(result))
                    result += Environment.NewLine;
                result += line;
            }
            return result;
        }

        public override void RenderExcelCells(IRow row, int colIndex, string[][] headers)
        {
            if (headers == null || headers.Length == 0 || headers[0] == null || headers[0].Length <= colIndex)
                return;
            var headerCell = headers[0][colIndex];
            var header = headerCell.ToLower();
            if (header == "message")
            {
            }
            else
            {
                Model.RenderExcelCells(row, colIndex, headers);
            }
        }

        public override void ReadExcelCells(IRow row, int colIndex, IRow[] headers)
        {
            var headerCell = headers[0].GetCell(colIndex);
            var header = headerCell.StringCellValue.ToLower();
            if (header == "message")
            {
                var cell = row.CreateCell(colIndex);
                cell.SetCellValue(GetMessage());
            }
            else
            {
                base.ReadExcelCells(row, colIndex, headers);
            }
        }
    }
}
