using Domain.Interfaces.Context;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Logic.Services
{
    public class WacthService : IWacthService
    {
        private readonly IMessageService _message;
        private readonly IEnvironmentContext _environment;

        public WacthService(IMessageService message, IEnvironmentContext environment)
        {
            _message = message;
            _environment = environment;
        }

        public string Process()
        {
            var folderData = new System.IO.DirectoryInfo(_environment.ENV_WATCH_FOLDER_DATA);
            var folderTemp = new System.IO.DirectoryInfo(_environment.ENV_WATCH_FOLDER_TEMP);
            var result = new System.Text.StringBuilder();

            if (folderData.Exists == false) folderData.Create();
            if (folderTemp.Exists == false) folderTemp.Create();

            foreach (var fileRaw in folderData.GetFiles())
            {
                var newFileRaw = new System.IO.FileInfo(folderTemp.FullName + @"/" + fileRaw.Name);

                result.AppendLine(string.Format("Found: {0}", fileRaw.Name));

                if (fileRaw.Extension.ToLower().Equals(".xls"))
                {
                    try
                    {
                        if (MoveTo(fileRaw, newFileRaw) && _message.Enqueue(newFileRaw.Name.Replace(newFileRaw.Extension, "")))
                        {
                            result.AppendLine(string.Format("Send: {0}", fileRaw.Name));
                        }
                    }
                    catch (Exception ex)
                    {
                        result.AppendLine(string.Format("File: {0} - Error: {1}", fileRaw.Name, ex.Message));
                    }
                }
            }

            return result.ToString();
        }

        private bool MoveTo(System.IO.FileInfo source, System.IO.FileInfo destiny)
        {
            if (destiny.Exists)
            {
                destiny.Delete();
            }

            source.MoveTo(destiny.FullName);

            return true;
        }
    }
}
