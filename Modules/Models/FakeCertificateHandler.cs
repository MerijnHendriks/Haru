using UnityEngine.Networking;

namespace Haru.Modules.Models
{
    public class FakeCertificateHandler : CertificateHandler
    {
        protected override bool ValidateCertificate(byte[] certificateData)
        {
            return true;
        }
    }
}