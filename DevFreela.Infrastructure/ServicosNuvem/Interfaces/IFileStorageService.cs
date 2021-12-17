using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.ServicosNuvem.Interfaces
{
    public interface IFileStorageService
    {
        void UploadFile(byte[] bytes, string filename);
    }
}
