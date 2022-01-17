using UnityEngine.Networking;

namespace Haru.Modules.Models
{
    /// <summary>
    /// Certificate handler that always returns true
    /// </summary>
    public class CertificateResult : CertificateHandler
    {
        // Singleton pattern to ensure only one instance always exists
        private static CertificateResult _instance;
        public static CertificateResult Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CertificateResult();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        static CertificateResult()
        {
            _instance = null;
        }

        /// <summary>
        /// Validates certificate
        /// </summary>
        protected override bool ValidateCertificate(byte[] certificateData)
        {
            return true;
        }
    }
}