using System;
using System.IO;
using System.Threading.Tasks;

namespace Gadz.Roteiro.Web {
    public class Logger {

        private const string DATEFORMAT = "dd/MM/yyyy HH:mm:ss";

        public static void WriteError(string error) {
            Task.Factory.StartNew(()=> {

                using (var file = new StreamWriter("c:\\roteiro\\error.txt", true, System.Text.Encoding.UTF8)) {
                    file.WriteLine($"{DateTime.Now.ToString(DATEFORMAT)} - {error}");
                }

            });
        }

        public static void WriteLog(string text) {
            Task.Factory.StartNew(()=> {

                using (var file = new StreamWriter("c:\\roteiro\\log.txt", true, System.Text.Encoding.UTF8)) {
                    file.WriteLine($"{DateTime.Now.ToString(DATEFORMAT)} - {text}");
                }

            });
        }

        public static void WriteInfo(string info) {
            Task.Factory.StartNew(()=> {

                using (var file = new StreamWriter("c:\\roteiro\\info.txt", true, System.Text.Encoding.UTF8)) {
                    file.WriteLine($"{DateTime.Now.ToString(DATEFORMAT)} - {info}");
                }

            });
        }

        public static void WriteRequest(string sessionId, string ip, string user, string url) {
            Task.Factory.StartNew(()=> {

                using (var file = new StreamWriter("c:\\roteiro\\requests.txt", true, System.Text.Encoding.UTF8)) {
                    file.WriteLine($"{DateTime.Now.ToString(DATEFORMAT)}\t{sessionId}\t{ip}\t{user}\t{url}");
                }

            });
        }
    }
}