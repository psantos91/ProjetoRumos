using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Rumos.Models
{
    public class DadosJoaoStorage
    {
        public string StringBlopService { get; set; }
        public string ContainerName { get; set; }

        public DadosJoaoStorage()
        {
            StringBlopService = "DefaultEndpointsProtocol=https;AccountName=ac2020storage;AccountKey=5fAS2v1hAZnoxilyas06ZvZwd7ehsftjBQkGlhsnW8+qtGiqboSO3UhsMS4+y59mx+DKJhmulzSx4NG2UF78SQ==;EndpointSuffix=core.windows.net";
            ContainerName = "joaomachado";
        }

        public BlobContainerClient OperacaoDeLigaçãoNova()
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(StringBlopService);

            string containername = ContainerName;

            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(containername);

            return blobContainerClient;
        }

        public BlobContainerClient OperacaoDeLigaçãoExistente()
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(StringBlopService);

            string containername = ContainerName;

            BlobContainerClient blobContainerClientExist = blobServiceClient.GetBlobContainerClient(containername);

            return blobContainerClientExist;
        }
    }
}
