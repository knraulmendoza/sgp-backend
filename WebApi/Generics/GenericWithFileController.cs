using Dominio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace Controllers.Generics
{
    public abstract class GenericWithFileController<TEntity> where TEntity : BaseEntity
    {
        public virtual ActionResult DownloadFile(string fileName)
        {
            var folderName = Path.Combine("Resources", "Files");
            var pathToOpen = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fullPath = Path.Combine(pathToOpen, fileName);
            var stream = new FileStream(fullPath, FileMode.Open);
            return new FileStreamResult(stream, "application/pdf");
        }
    }
}