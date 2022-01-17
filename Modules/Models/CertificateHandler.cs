using UnityEngine.Networking;

namespace Haru.Modules.Models
{
    /// <summary>
    /// Certificate handler that always returns true
    /// </summary>
    public class CertificateResult : CertificateHandler
    {
        /// <summary>
        /// Validates certificate
        /// </summary>
        protected override bool ValidateCertificate(byte[] certificateData)
        {
            return true;
        }
    }
}